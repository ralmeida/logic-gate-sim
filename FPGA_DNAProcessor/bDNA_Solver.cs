using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using FPGA;

namespace FPGA_DNAProcessor
{
    public partial class bDNA_Solver : Form
    {
        protected static string TimeOutputText = "{0:000} Week{1} {2} Day{3} {4:00}:{5:00}:{6:00}";

        protected Stopwatch ElaspedTime = new Stopwatch();        
        DateTime TestStartTime = DateTime.MinValue;

        MainForm parentForm;
        public bDNA_Test_Request TestRequest { get; set; }

        Hashtable Population;
        Hashtable PopulationTmp = new Hashtable();

        bool HasAnswer = false;
        int Generations = 0;


        CancellationTokenSource ts;
        CancellationToken ct;

        string[] TestLines;
        string OutputText { get; set; }

        string subDir = null;

        public double FitnessHigh = 0.0;
        public List<double> FitnessHighs = new List<double>();
        public List<double> FitnessLows = new List<double>();
        public List<double> FitnessAvgs = new List<double>();
        public List<double> FitnessCorrect = new List<double>();
        public List<double> FitnessMaxCorrect = new List<double>();

        bDNA_FitnessGraph graph = null;

        public bDNA_Solver(MainForm p, bDNA_Test_Request req)
        {
            try
            {
                parentForm = p;
                HasAnswer = false;
                
                //Verify we have a non-null TestRequest
                if (req == null)
                    throw new ArgumentNullException("TestRequest", "Test Reuqest is requried to run the Solver Process");

                //Set the Test Request
                TestRequest = req;

                //Check out InputsFile isn't null or empty
                if (TestRequest.TestInputsFileData == null && string.IsNullOrEmpty(TestRequest.TestInputsFile))
                    throw new ArgumentNullException("TestInputsFile", "Test file is required");

                //Make sure it's there
                if (TestRequest.TestInputsFileData == null && !File.Exists(TestRequest.TestInputsFile))
                    throw new FileNotFoundException("Test Input File", string.Format("Could not find File: {0}", TestRequest.TestInputsFile));
            }
            catch(Exception ex)
            {
                DialogResult rslt = MessageBox.Show(ex.Message);
                Close();
            }

            //Init form
            InitializeComponent();

            //Read Our Tests in (raw data)
            if (TestRequest.TestInputsFileData != null)
                TestLines = TestRequest.TestInputsFileData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //Read Our Tests in (input file)
            else
                TestLines = File.ReadAllLines(TestRequest.TestInputsFile);

            //Set our Test Start Time
            TestStartTime = DateTime.Now;

            //Start our Timer
            ElaspedTime.Start();
            
            //Create our empty population
            Population = new Hashtable();

            //Check if we are resumeing and then set the Population on the Resume
            if (TestRequest.Resume)
            {
                #region Try to Resume Test

                int lastHigh = 0;
                string highDir = null;
                foreach (string subdir in Directory.GetDirectories(OutputDNADir))
                {
                    DirectoryInfo fi1 = new DirectoryInfo(subdir);
                    int dirNum = 0;
                    int.TryParse(fi1.Name, out dirNum);

                    if (dirNum >= lastHigh)
                    {
                        highDir = subdir;
                        lastHigh = dirNum;
                    }
                }

                if (highDir != null)
                {
                    string[] pS = highDir.Split('\\');
                    string genNumStr = pS[pS.Length - 1];
                    int genNum = 0;
                    int.TryParse(genNumStr, out genNum);

                    //Set the generation number to the current Generation we are resumeing
                    Generations = genNum;

                    foreach (string bDNAFileName in Directory.GetFiles(highDir))
                    {
                        string PersonID = Path.GetFileName(bDNAFileName).Replace(".bDNA", string.Empty);
                        List<List<List<BitArray>>> PersonData = File.ReadAllBytes(bDNAFileName).ToBitArrayTable(FPGAConfig.BytesPerCell, TestRequest.SquareSize);
                        Population.Add(PersonID, new FPGAPerson()
                        {
                            ID = PersonID,
                            Data = PersonData,
                            Results = new List<string>(),
                            Weight = 0
                        });
                    }

                    //try to load in the Fitness History
                    string[] fitnessHistoryFiles = Directory.GetFiles(OutputDir, "*.fit");
                    foreach(string fitnessHistoryFile in fitnessHistoryFiles)
                    {
                        if(!string.IsNullOrEmpty(fitnessHistoryFile) && File.Exists(fitnessHistoryFile))
                        {
                            using (Stream stream = File.Open(fitnessHistoryFile, FileMode.Open))
                            {
                                BinaryFormatter bin = new BinaryFormatter();

                                var fitnessHistory = (FitnessHistory)bin.Deserialize(stream);
                                if (fitnessHistory.Highs != null) FitnessHighs = fitnessHistory.Highs;
                                if (fitnessHistory.Lows != null) FitnessLows = fitnessHistory.Lows;
                                if (fitnessHistory.Avgs != null) FitnessAvgs = fitnessHistory.Avgs;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    DialogResult rslt = MessageBox.Show(string.Format("Cannot Resume from {0}, No bDNA Directorys found", OutputDNADir), "Resume Error", MessageBoxButtons.OK);
                    if(rslt == DialogResult.OK)
                        this.Close();
                }

                #endregion
            }

            string mutMethod = string.Format("{0}{1}", TestRequest.MutationMethod, TestRequest.MutationMethod != GeneticMutationMethod.RMethod ? string.Format("({0})", TestRequest.MutationN) : "");
            toolStripStatusLabelMutationMethod.Text = mutMethod;
            toolStripStatusLabelSwapMethod.Text = TestRequest.SwapMethod.ToString();
            toolStripStatusLabelCullHerd.Text = TestRequest.CullHerd.ToString();

            //Start the Worker to begin the Processing Loop
            bwSolver.RunWorkerAsync();

            //Show our Fitness Graph
            if(TestRequest.ShowFitnessGraph)
                ShowFitnessGraph();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            TimeSpan tickTime = ElaspedTime.Elapsed;
            long milSec = tickTime.Milliseconds,
                 sec = tickTime.Seconds,
                 min = tickTime.Minutes,
                 hr = tickTime.Hours;

            double day = Math.Floor(tickTime.TotalDays),
                   week = Math.Floor(tickTime.TotalDays/7);
            
            lbTimeToSolve.Text = string.Format(TimeOutputText, week, week == 1 ? "" : "s", day, day == 1 ? "" : "s", hr, min, sec);

            toolStripStatusGeneration.Text = string.Format("Generation {0}", Generations);
            
            //if (OutputText.Length > 20000) OutputText = OutputText.Substring(OutputText.Length - 20000);
            //txtOutput.Text = OutputText;
            //txtOutput.SelectionStart = txtOutput.Text.Length;
            //txtOutput.ScrollToCaret();

            if (HasAnswer) timerTick.Stop();
        }

        #region Solver Background Work

        private void bwSolver_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            if (backgroundWorker != null)
            {
                if (!HasAnswer)
                {
                    backgroundWorker.ReportProgress(0, "");
                    backgroundWorker.ReportProgress(0, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ");
                    backgroundWorker.ReportProgress(0, string.Format(" * Generation {0} Starting *", Generations));
                    backgroundWorker.ReportProgress(0, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ");

                    //Generate the Population if needed
                    ProcessGenerationStart(backgroundWorker);

                    //Process the I/O Tests
                    ProcessTests(backgroundWorker);

                    //Run the Fitness Testing and get the Results
                    List<FitnessResult> Results = ProcessFitnessTests(backgroundWorker);

                    //If we don't have an answer then lets keep going
                    if (!HasAnswer)
                    {
                        //Sort our Fitness Results
                        ProcessFitnessSorting(Results, backgroundWorker);

                        //Create the next Generation
                        ProcessGeneticMixing(Results, backgroundWorker);
                    }
                }
                else
                {
                    WriteLogFile();
                    WriteFitnessHistoryFile();
                    backgroundWorker.ReportProgress(100, string.Format("Solved! Check {0} for the .bDNA File", TestRequest.OutputDirectory));
                }
            }
        }
        
        private void bwProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Make srue we have an Object
            if (txtOutput != null && !txtOutput.IsDisposed)
            {
                //if we sent progress 0 or 100 then add a line
                if (e.ProgressPercentage == 0 || e.ProgressPercentage == 100)
                    txtOutput.AppendText((string.IsNullOrEmpty(txtOutput.Text) ? string.Empty : Environment.NewLine) + e.UserState.ToString());
                //if we sent progress 1 then we add to the line
                else if (e.ProgressPercentage == 1)
                    txtOutput.AppendText(e.UserState.ToString());
            }
        }

        private void bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If we don't have an answer lets re-run the Worker (keep the loop going)
            if(!HasAnswer)
                bwSolver.RunWorkerAsync();
        }

        #endregion

        #region Process Methods (TODO: logic needs to be moved to FPGA Library)

        protected void ProcessGenerationStart(BackgroundWorker backgroundWorker)
        {
            //If we do not have any Data we need to generate a round one population
            if (Population.Count <= 0)
            {
                backgroundWorker.ReportProgress(0, "Generating a Random Population");

                for (int i = 0; i < TestRequest.PopulationSize; i++)
                {
                    backgroundWorker.ReportProgress(1, ".");

                    string PersionID = Guid.NewGuid().ToString();

                    FPGAPerson PersonData = new FPGAPerson()
                    {
                        ID = PersionID,
                        Data = FPGABoard.RandomConfig(TestRequest.SquareSize).ToBitArrayTable(FPGAConfig.BytesPerCell, TestRequest.SquareSize),
                        Results = new List<string>(),
                        Weight = 0
                    };

                    Population.Add(PersionID, PersonData);
                }

                backgroundWorker.ReportProgress(1, "done");
            }
            else
                backgroundWorker.ReportProgress(0, "Using existing Population");  
                        
            if(Generations % FPGAConfig.GenerationsToArchive == 0)
            {
                //Backup the Fitness History
                WriteFitnessHistoryFile();

                //Save our Log Output
                WriteLogFile();
            }
        }

        protected void ProcessTests(BackgroundWorker backgroundWorker)
        {
            #region Start Tests

            backgroundWorker.ReportProgress(0, "- Running I/O Tests ");
            
            List<Task> testsRunning = new List<Task>();

            int secondsWait = 0;

            ts = new CancellationTokenSource();
            ct = ts.Token;

            Task rpTask = Task.Run(() =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested) break;
                    backgroundWorker.ReportProgress(1, ".");
                    Thread.Sleep(1000);
                    secondsWait++;
                }

            }, ct);

            int boards = 0;
            foreach (DictionaryEntry person in Population)
            {
                FPGATestConfig testRunConfig = new FPGATestConfig()
                {
                    PersionID = (string)person.Key,
                    InputCount = TestRequest.InputCount,
                    OutputCount = TestRequest.OutputCount,
                    TestFile = TestRequest.TestInputsFile
                };

                //Console.WriteLine("Task Test for {0} started...", person.Key);
                try
                {
                    testsRunning.Add(Task.Factory.StartNew(() => ProcessTestRun(testRunConfig), ct));
                }
                catch
                {

                }
                //Task.WaitAll(new Task[] { Task.Factory.StartNew(() => ProcessTestRun(testRunConfig)) });
                //Console.WriteLine("...Task Test for {0} ended", person.Key);

                //File.AppendAllLines(@"C:\apps\io.txt", new string[] { "--------------------------------------------", string.Format("---- Board [{0}] Done -----", boards++), "--------------------------------------------" });
            }

            #endregion

            #region Wait for Tests to complete

            //Console.WriteLine("Test...");
            try
            {
                Task.WaitAll(testsRunning.ToArray(), ct);
            }
            catch(OperationCanceledException oEx)
            {
                Console.WriteLine(oEx.Message);
            }
            //Console.WriteLine("...Done");

            //stop main wait task
            ts.Cancel();
            
            backgroundWorker.ReportProgress(1, "done");

            double mins = Math.Floor((double)secondsWait / 60);
            backgroundWorker.ReportProgress(1, string.Format(" took {0:00} mins {1:00} seconds", mins, secondsWait-(mins*60)));

            #endregion
        }

        protected void ProcessTestRun(FPGATestConfig testReq)
        {
            FPGAPerson personData = GetPersonFromPopulation(testReq.PersionID);

            //Setup FPGA Board
            FPGABoard testBoard = new FPGABoard(personData.Data, testReq.InputCount, testReq.OutputCount)
            {
                ID = personData.ID
            };

            //Log this board to a file if we are on a Generation To Archive (evefy {n} [n=FPGAConfig.GenerationsToArchive]
            if (Generations % FPGAConfig.GenerationsToArchive == 0)
            {
                string bDNAGenerationDir = string.Format("{0}\\{1}", OutputDNADir, Generations);
                Directory.CreateDirectory(bDNAGenerationDir);
                string personFile = string.Format("{0}\\{1}.bDNA", bDNAGenerationDir, personData.ID);
                FileHelper.ByteArrayToFile(personFile, testBoard.Byes);
            }

            Thread.Sleep(5);

            int totalCount = TestLines.Length;
            int totalProcessed = 0;
            int percentComplete = (100 * totalProcessed) / totalCount;

            int testCount = 0;
            foreach (string inputLine in TestLines)
            {
                DateTime timeoutTime = DateTime.Now;
                //int intTimeout = 45;
                bool done = false;
                bool looped = false;

                while (!done)
                //while ((timeoutTime - DateTime.Now).Seconds < intTimeout && !done)
                {
                    percentComplete = (100 * totalProcessed) / totalCount;

                    string[] inputOutputText = inputLine.Split(' ');
                    if (inputOutputText.Length > 1)
                    {
                        if (!looped)
                        {
                            //Set the Input values 
                            string inputValue = inputOutputText[0];

                            //Converting Inputs to bool values
                            bool[] inputVals = new bool[inputValue.Length];
                            for (int i = 0; i < inputValue.Length; i++)
                            {
                                inputVals[i] = false;
                                if (inputValue[i] == '1') inputVals[i] = true;
                            }

                            Array.Reverse(inputVals);

                            try
                            {
                                //Send Inputs to the Board
                                testBoard.SendInputs(inputVals);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("bDNA_Solver Process Test -> Send Inputs Error: {0}", ex.Message);
                            }

                            looped = true;
                        }

                        //assign the board to be ready                      
                        done = testBoard.Ready;
                    }

                    //Convert the output
                    string outOutStr = string.Empty;
                    for (int v = testBoard.OutputCount - 1; v > -1; v--)
                    {
                        outOutStr += (testBoard.Outputs[v].Value ? "1" : "0");
                    }

                    //Capture the output
                    personData.Results.Add(outOutStr);

                    //File.AppendAllLines(@"C:\apps\io.txt", new string[] { "--------------------------------------------", string.Format("---- Test Run [{0}] Done -----", testCount++), "--------------------------------------------" });
                }

                //make sure we do the test next loop
                looped = false;
            }

            //DEBUG: write to file the test results
            //string[] results = new string[personData.Results.Count];
            //for(int i=0; i<personData.Results.Count; i++)
            //{
            //    results[i] = personData.Results[i];
            //}
            //string fileToWrite = string.Format(@"{0}\{1}.txt", OutputDNADir, testReq.PersionID);
            //File.WriteAllLines(fileToWrite, results);

            //Console.WriteLine("{0} Tests: {1}", personData.ID, TestLines.Count());
        }
        
        double factorZ = 0.5;
        double factorO = 0.5;
        string maxCorrectKeeper = string.Empty;

        protected List<FitnessResult> ProcessFitnessTests(BackgroundWorker backgroundWorker)
        {
            #region Set fitness factor

            if (FitnessHigh > 0.65)
            {
                //if (factorZ > factorO)
                //{
                    if (factorZ < 0.5)
                        factorZ += 0.01;

                    if (factorO > 0.5)
                        factorO -= 0.01;
                //}
            }

            backgroundWorker.ReportProgress(0, "-------------------------");
            Thread.Sleep(5);
            backgroundWorker.ReportProgress(0, "- Factor[Z]: " + factorZ.ToString());
            Thread.Sleep(5);
            backgroundWorker.ReportProgress(0, "- Factor[O]: " + factorO.ToString());
            Thread.Sleep(5);
            backgroundWorker.ReportProgress(0, "-------------------------");
            Thread.Sleep(5);

            #endregion

            backgroundWorker.ReportProgress(0, "- Running Fitness Tests");
            Thread.Sleep(5);

            //What is the max number of tests that went over 0.8 for all
            int testRunMaxOver8 = 0;

            //Track the number of Max right answers for all
            int testMaxCorrect = 0;

            //Track the Score of the current Max
            double testMaxCorrectScore = -100.0;

            //Keep track of the number of times we have a person that recieved 50% over 0.8
            List<int> numOver8Most = new List<int>();

            //Make a list of our results
            List<FitnessResult> Results = new List<FitnessResult>();

            //Loop through the Popluation for each Person
            foreach (DictionaryEntry person in Population)
            {
                //What is the max number of tests that went over 0.8 for this 'person'
                int _testRunMaxOver8 = 0;
                
                backgroundWorker.ReportProgress(1, ".");
                Thread.Sleep(5);

                //Create our result for this Person
                FitnessResult result = new FitnessResult()
                {
                    PersonID = (string)person.Key,
                    Value = 0
                };

                //Get our Person Data
                FPGAPerson personData = (FPGAPerson)person.Value;
                if (personData != null)
                {
                    //how many correct do we have?
                    int correctAnswers = 0;

                    int weightTotal = TestRequest.OutputCount * TestLines.Count();

                    //TODO: fix this code so quiting debug won't thow an exception
                    try
                    {
                        #region Score Each Testline

                        List<double> lineVals = new List<double>();
                        for (int i = 0; i < TestLines.Count(); i++)
                        {
                            string testLine = TestLines[i];
                            string outputLine = personData.Results[i];

                            string testLineString = testLine.Split(' ')[1].Substring(0, TestRequest.OutputCount);

                            if (testLineString == outputLine)
                            {
                                correctAnswers++;
                                lineVals.Add(1);
                            }
                            else
                            {
                                int zero = 0;
                                int one = 0;
                                int zeroH = 0;
                                int oneH = 0;
                                for (int x = 0; x < testLineString.Count(); x++)
                                {
                                    char tc = testLineString[x];
                                    if (tc == '1') one++;
                                    else zero++;

                                    char oc = outputLine[x];
                                    if (tc == oc)
                                    {
                                        if (oc == '1') oneH++;
                                        else zeroH++;
                                    }
                                }

                                double dZero = zero == 0 ? 0 : (zeroH / zero) * factorZ;
                                double dOne = one == 0 ? 0 : (oneH / one) * factorO;
                                double lineVal = dZero + dOne;
                                lineVals.Add(lineVal);
                            }
                        }

                        #endregion

                        /*
                         * We need to weigh more than just the Average of the totals 
                        */
                        double lineValFactor = 0.0;
                        foreach(double lineVal in lineVals)
                        {
                            if (lineVal > 0.8)
                            {
                                lineValFactor += 0.01;
                                _testRunMaxOver8++;
                            }
                            if (lineVal < 0.1) lineValFactor -= 0.01;
                        }

                        result.Value = lineVals.Average() + lineValFactor;     

                        //if we have more over 8 than the current max set ours to the max
                        if (_testRunMaxOver8 > testRunMaxOver8) testRunMaxOver8 = _testRunMaxOver8;

                        //if we have more right than the current max set ours to the max
                        if(correctAnswers > testMaxCorrect)
                        {
                            testMaxCorrect = correctAnswers;
                            maxCorrectKeeper = personData.ID;
                            testMaxCorrectScore = result.Value;
                        }
                        else if (correctAnswers == testMaxCorrect && result.Value > testMaxCorrectScore)
                        {
                            testMaxCorrect = correctAnswers;
                            maxCorrectKeeper = personData.ID;
                            testMaxCorrectScore = result.Value;
                        }               

                        if (correctAnswers == TestLines.Count())
                        {
                            HasAnswer = true;
                            if (!Directory.Exists(TestRequest.OutputDirectory)) Directory.CreateDirectory(TestRequest.OutputDirectory);
                            string GoodGuy = string.Format("{0}\\{1}.bDNA", TestRequest.OutputDirectory, personData.ID);
                            FileHelper.ByteArrayToFile(GoodGuy, personData.Data.BitArrayTableToByteArray());
                            //File.WriteAllBytes(GoodGuy, personData.Data.BitArrayTableToByteArray());

                            backgroundWorker.ReportProgress(0, "** Result FOUND!!!");
                            Thread.Sleep(5);
                            Results.Add(result);
                        }
                        else
                            Results.Add(result);
                    }
                    catch { }
                }
            }

            backgroundWorker.ReportProgress(1, "done");
            Thread.Sleep(5);

            //set the data for the MaxCorrect
            double avgCorrect = (double)testMaxCorrect / (double)TestLines.Count();
            FitnessCorrect.Add(avgCorrect);

            backgroundWorker.ReportProgress(0, "-- Avg Correct Answers: " + avgCorrect.ToString());
            Thread.Sleep(120);
            
            backgroundWorker.ReportProgress(0, "-- Max Correct Answers: " + testMaxCorrect.ToString());
            Thread.Sleep(120);

            backgroundWorker.ReportProgress(0, "-- Max tests over 0.8: " + testRunMaxOver8.ToString());
            Thread.Sleep(120);

            return Results;
        }

        protected void ProcessFitnessSorting(List<FitnessResult> Results, BackgroundWorker backgroundWorker)
        {
            backgroundWorker.ReportProgress(0, "- Sorting Population by Fitness Results");
            Thread.Sleep(50);

            #region Sort Population into PopulationTmp by Population["xxx"]["Weight"]

            PopulationTmp = new Hashtable();

            Results.Sort((a, b) => -a.Value.CompareTo(b.Value));
            /*delegate (FitnessResult a, FitnessResult b)
            {
                if (a == null || b == null) return 0;
                //else if (a == null) return 0;
                //else if (b == null) return 0;
                else return -a.Value.CompareTo(b.Value);
            });*/

            foreach (FitnessResult rslt in Results)
            {
                backgroundWorker.ReportProgress(1, ".");
                Thread.Sleep(5);

                PopulationTmp.Add(rslt.PersonID, new FPGAPerson()
                {
                    ID = rslt.PersonID,
                    Data = GetPersonFromPopulation(rslt.PersonID).Data,
                    Results = new List<string>(),
                    Weight = rslt.Value
                });
            }
            backgroundWorker.ReportProgress(1, "done");
            Thread.Sleep(5);
            
            //Capture the High and Low for this Generation
            double highVal = Results[0].Value;
            double lowVal = Results[Results.Count - 1].Value;
            double avgVal = Results.Average((r) => r.Value);
            FitnessHighs.Add(highVal);
            FitnessLows.Add(lowVal);
            FitnessAvgs.Add(avgVal);
            FitnessHigh = highVal;

            backgroundWorker.ReportProgress(0, "  -- Fitness Results:");
            Thread.Sleep(25);
            backgroundWorker.ReportProgress(0, "--------------------------------------------------------");
            Thread.Sleep(25);
            backgroundWorker.ReportProgress(0, string.Format("   ---- High: {0} from -> {1}", highVal, Results[0].PersonID));
            Thread.Sleep(25);
            backgroundWorker.ReportProgress(0, string.Format("   ----  Low: {0} from -> {1}", lowVal, Results[Results.Count - 1].PersonID));
            Thread.Sleep(25);
            backgroundWorker.ReportProgress(0, string.Format("   ----  AVG: {0} ----", avgVal));
            Thread.Sleep(25);
            backgroundWorker.ReportProgress(0, "--------------------------------------------------------");
            Thread.Sleep(25);

            #endregion
        }

        protected void ProcessGeneticMixing(List<FitnessResult> results, BackgroundWorker backgroundWorker)
        {
            //backgroundWorker.ReportProgress(0, "Running Genetic Mixing");
            //Thread.Sleep(50);

            List<List<List<List<BitArray>>>> tmpHold = new List<List<List<List<BitArray>>>>();
            List<List<List<List<BitArray>>>> newHold = new List<List<List<List<BitArray>>>>();

            ProcessFilterPopulation(results, tmpHold, newHold, backgroundWorker);

            ProcessGeneticBreeding(tmpHold, newHold, backgroundWorker);

            ProcessCreateNewGeneration(newHold, backgroundWorker);
        }

        protected void ProcessFilterPopulation(List<FitnessResult> results, List<List<List<List<BitArray>>>> tmpHold, List<List<List<List<BitArray>>>> newHold, BackgroundWorker backgroundWorker)
        {
            tmpHold.Clear();

            #region Filter Population 

            backgroundWorker.ReportProgress(0, "- Filtering Population");
            Thread.Sleep(50);

            Population = new Hashtable();
            int keepLimit = PopulationTmp.Count / 2;
            int kept = 0;
            //double maxRslt = -1;
            
            foreach(FitnessResult result in results) 
            //foreach (DictionaryEntry person in PopulationTmp)
            {
                FPGAPerson myPerson = (FPGAPerson)PopulationTmp[result.PersonID]; //person.Value;
                backgroundWorker.ReportProgress(1, ".");

                if (kept < 3 || myPerson.ID == maxCorrectKeeper)
                //if(myPerson.Weight > maxRslt)
                {
                    //we only carry one person froward
                    if (newHold.Count < 1)
                        newHold.Add(myPerson.Data);
                    //we will carry forward if different the maxCorrectKeeper (one with the most correct answers)
                    else if (myPerson.ID == maxCorrectKeeper)
                        newHold.Add(myPerson.Data);

                    //if(newHold.Count == 3)
                    //    maxRslt = myPerson.Weight;

                    if (myPerson.ID == maxCorrectKeeper)
                    {
                        backgroundWorker.ReportProgress(0, string.Format(" - myPerson Keeper: {0}", myPerson.Weight));
                        FitnessMaxCorrect.Add(myPerson.Weight);
                    }
                    else
                        backgroundWorker.ReportProgress(0, string.Format(" - myPerson Elite: {0}", myPerson.Weight));

                    tmpHold.Add(myPerson.Data);
                    kept++;
                }
                else if (kept < keepLimit)
                {
                    tmpHold.Add(myPerson.Data);
                    kept++;
                }
            }

            if(FitnessMaxCorrect.Count() < FitnessCorrect.Count())
            {
                Console.WriteLine("Finess Mismatch");
                FitnessMaxCorrect.Add(FitnessMaxCorrect[FitnessMaxCorrect.Count - 1]);
            }

            backgroundWorker.ReportProgress(1, "done");
            Thread.Sleep(50);

            #endregion
        }

        protected void ProcessGeneticBreeding(List<List<List<List<BitArray>>>> tmpHold, List<List<List<List<BitArray>>>> newHold, BackgroundWorker backgroundWorker)
        {
            backgroundWorker.ReportProgress(0, "- Breeding new Population bDNA");
            Thread.Sleep(50);
            
            if(TestRequest.CullHerd)
            {
                //Take only the top 40% and use them to breed the rest
                int cullNum = int.Parse(Math.Floor(tmpHold.Count * 0.5).ToString());
                tmpHold.RemoveRange(cullNum, tmpHold.Count - cullNum);
            }

            int loopCount = (int)Math.Floor((double)tmpHold.Count / 2) * 2;
            int i = 0;
            while(newHold.Count < TestRequest.PopulationSize)
            //for (int i = 0; i < loopCount; i++)
            {
                if ((i * 2) + 1 >= tmpHold.Count) break;

                backgroundWorker.ReportProgress(1, ".");

                Breed(tmpHold, newHold, i + i, i + (i + 1));
                i++;
            }
            
            //Take only the top 40% and use them to breed the rest
            int fp = int.Parse(Math.Floor(tmpHold.Count * 0.4).ToString());
            tmpHold.RemoveRange(fp, tmpHold.Count-fp);

            while (newHold.Count < TestRequest.PopulationSize)
            {
                backgroundWorker.ReportProgress(1, ".");
                int pAIndx = NumberHelper.RandomBetween(0, tmpHold.Count - 1);
                int pBIndx = NumberHelper.RandomBetween(0, tmpHold.Count - 1);
                while (pBIndx == pAIndx)
                {
                    pBIndx = NumberHelper.RandomBetween(0, tmpHold.Count - 1);
                }

                Breed(tmpHold, newHold, pAIndx, pBIndx);
            }

            backgroundWorker.ReportProgress(1, "done");
            Thread.Sleep(50);
        }

        protected void ProcessCreateNewGeneration(List<List<List<List<BitArray>>>> newHold, BackgroundWorker backgroundWorker)
        {
            #region Create new Population form the Mixes

            backgroundWorker.ReportProgress(0, "- Creating new Population from new bDNA");
            Thread.Sleep(50);

            for (int i = 0; i < newHold.Count; i++)
            {
                backgroundWorker.ReportProgress(1, ".");

                string PersionID = Guid.NewGuid().ToString();

                FPGAPerson PersonData = new FPGAPerson()
                {
                    ID = PersionID,
                    Data = newHold[i],
                    Results = new List<string>(),
                    Weight = 0
                };

                Population.Add(PersionID, PersonData);
            }

            backgroundWorker.ReportProgress(1, "done");
            Thread.Sleep(50);

            Generations++;

            #endregion
        }

        #endregion

        protected FPGAPerson GetPersonFromPopulation(string personID)
        {
            if (Population.Count <= 0) return null;
            else if (!Population.ContainsKey(personID)) return null;
            else return Population[personID] as FPGAPerson;
        }
        
        private void Breed(List<List<List<List<BitArray>>>> tmpHold, List<List<List<List<BitArray>>>> newHold, int pAIndx, int pBIndx)
        {
            List<List<List<BitArray>>> pA = tmpHold[pAIndx];
            List<List<List<BitArray>>> pB = tmpHold[pBIndx];

            int pCIndx = newHold.Count;
            List<List<List<BitArray>>> pC = new List<List<List<BitArray>>>();
            newHold.Add(pC);

            int pDIndx = newHold.Count;
            List<List<List<BitArray>>> pD = new List<List<List<BitArray>>>();
            newHold.Add(pD);

            int pEIndx = newHold.Count;
            List<List<List<BitArray>>> pE = new List<List<List<BitArray>>>();

            int pFIndx = newHold.Count+1;
            List<List<List<BitArray>>> pF = new List<List<List<BitArray>>>();
            
            if (TestRequest.SwapMethod == GenitcSwapMethod.Kenneth)
            {
                newHold.Add(pE);
                newHold.Add(pF);
            }

            //Row
            for (int rowIndx = 0; rowIndx < pA.Count; rowIndx++)
            { 
                pC.Add(new List<List<BitArray>>());
                pD.Add(new List<List<BitArray>>());

                pE.Add(new List<List<BitArray>>());
                pF.Add(new List<List<BitArray>>());

                //Column
                for (int colIndx = 0; colIndx < pA[rowIndx].Count; colIndx++)
                {
                    pC[rowIndx].Add(new List<BitArray>());
                    pD[rowIndx].Add(new List<BitArray>());

                    pE[rowIndx].Add(new List<BitArray>());
                    pF[rowIndx].Add(new List<BitArray>());

                    #region Swap DNA

                    //BitArray Config 'bytes'
                    for (int configIndx = 0; configIndx < pA[rowIndx][colIndx].Count; configIndx++)
                    {
                        //TODO: here we can control what bytes are getting swaped and when
                        /*
                         * We can setup some conditions to which, depending on the Generation & FitnessHigh
                         *  how the swaping is happening, maybe after so many generations some bytes are less
                         *  swaped and more carried on as is
                        */
                        BitArray pAAry = pA[rowIndx][colIndx][configIndx];
                        BitArray pBAry = pB[rowIndx][colIndx][configIndx];

                        bool[] pCVals = new bool[8];
                        bool[] pDVals = new bool[8];
                        
                        bool[] pEVals = new bool[8];
                        bool[] pFVals = new bool[8];

                        if (TestRequest.SwapMethod == GenitcSwapMethod.Kenneth)
                        {
                            //Person C (new Person 1)
                            pCVals[0] = pBAry[4];
                            pCVals[1] = pBAry[5];
                            pCVals[2] = pBAry[6];
                            pCVals[3] = pBAry[7];

                            pCVals[4] = pAAry[4];
                            pCVals[5] = pAAry[5];
                            pCVals[6] = pAAry[6];
                            pCVals[7] = pAAry[7];

                            //Person D (new Person 2)
                            pDVals[0] = pBAry[0];
                            pDVals[1] = pBAry[1];
                            pDVals[2] = pBAry[2];
                            pDVals[3] = pBAry[3];

                            pDVals[4] = pAAry[0];
                            pDVals[5] = pAAry[1];
                            pDVals[6] = pAAry[2];
                            pDVals[7] = pAAry[3];

                            //Person E (new Person 3)
                            pEVals[0] = pAAry[4];
                            pEVals[1] = pAAry[5];
                            pEVals[2] = pAAry[6];
                            pEVals[3] = pAAry[7];

                            pEVals[4] = pBAry[4];
                            pEVals[5] = pBAry[5];
                            pEVals[6] = pBAry[6];
                            pEVals[7] = pBAry[7];

                            //Person F (new Person 4)
                            pFVals[0] = pAAry[0];
                            pFVals[1] = pAAry[1];
                            pFVals[2] = pAAry[2];
                            pFVals[3] = pAAry[3];

                            pFVals[4] = pBAry[0];
                            pFVals[5] = pBAry[1];
                            pFVals[6] = pBAry[2];
                            pFVals[7] = pBAry[3];
                        }
                        else if(TestRequest.SwapMethod == GenitcSwapMethod.FourBit)
                        {
                            //Person C (new Person 1)
                            pCVals[0] = pAAry[0];
                            pCVals[1] = pAAry[1];
                            pCVals[2] = pAAry[2];
                            pCVals[3] = pAAry[3];

                            pCVals[4] = pBAry[4];
                            pCVals[5] = pBAry[5];
                            pCVals[6] = pBAry[6];
                            pCVals[7] = pBAry[7];

                            //Person D (new Person 2)
                            pDVals[0] = pBAry[0];
                            pDVals[1] = pBAry[1];
                            pDVals[2] = pBAry[2];
                            pDVals[3] = pBAry[3];

                            pDVals[4] = pAAry[4];
                            pDVals[5] = pAAry[5];
                            pDVals[6] = pAAry[6];
                            pDVals[7] = pAAry[7];
                        }
                        else
                        {
                            //Person C (new Person 1)
                            pCVals[0] = pAAry[0];
                            pCVals[1] = pAAry[1];

                            pCVals[2] = pBAry[2];
                            pCVals[3] = pBAry[3];

                            pCVals[4] = pAAry[4];
                            pCVals[5] = pAAry[5];

                            pCVals[6] = pBAry[6];
                            pCVals[7] = pBAry[7];

                            //Person D (new Person 2)
                            pDVals[0] = pBAry[0];
                            pDVals[1] = pBAry[1];

                            pDVals[2] = pAAry[2];
                            pDVals[3] = pAAry[3];

                            pDVals[4] = pBAry[4];
                            pDVals[5] = pBAry[5];

                            pDVals[6] = pAAry[6];
                            pDVals[7] = pAAry[7];
                        }

                        if(TestRequest.SwapMethod == GenitcSwapMethod.Kenneth)
                        {
                            pE[rowIndx][colIndx].Add(new BitArray(pEVals));
                            pF[rowIndx][colIndx].Add(new BitArray(pFVals));
                        }

                        pC[rowIndx][colIndx].Add(new BitArray(pCVals));
                        pD[rowIndx][colIndx].Add(new BitArray(pDVals));
                    }

                    #endregion

                    if (TestRequest.MutationMethod == GeneticMutationMethod.OutOfN)
                    {
                        //Try to mutate Person C
                        Mutate(rowIndx, colIndx, TestRequest.MutationN, pC);

                        //Try to mutate Person D
                        Mutate(rowIndx, colIndx, TestRequest.MutationN, pD);
                    }
                    else if(TestRequest.MutationMethod == GeneticMutationMethod.RMethod)
                    {
                        //Try to mutate Person C
                        MutateR(rowIndx, colIndx, pC);

                        //Try to mutate Person D
                        MutateR(rowIndx, colIndx, pD);
                    }
                    else if(TestRequest.MutationMethod == GeneticMutationMethod.ByteOutOfN)
                    {
                        //Try to Mutate Person C
                        MutateByte(rowIndx, colIndx, TestRequest.MutationN, pC);

                        //Try to Mutate Person D
                        MutateByte(rowIndx, colIndx, TestRequest.MutationN, pD);
                    }
                }
            }
        }

        #region Mutate

        protected void Mutate(int rowIndx, int colIndx, int N, List<List<List<BitArray>>> personData)
        {
            if (N < 1) N = 1;
            //Mutate Factor 1 out of N
            int mutateFactor = NumberHelper.RandomBetween(1, N);
            
            if (mutateFactor == 1)
            {
                //get a Random bit index for C
                int bitCIndx = NumberHelper.RandomBetween(0, 7);
                //get a random BitArray to mutate for C
                int bitAryCIndx = NumberHelper.RandomBetween(0, personData[rowIndx][colIndx].Count - 1);
                //Invert the Bit
                personData[rowIndx][colIndx][bitAryCIndx][bitCIndx] = !personData[rowIndx][colIndx][bitAryCIndx][bitCIndx];
            }      
        }

        protected void MutateByte(int rowIndx, int colIndx, int N, List<List<List<BitArray>>> personData)
        {
            for (int m = 0; m < personData[rowIndx][colIndx].Count; m++)
            {
                if (N < 1) N = 1;
                int mutateFactor = NumberHelper.RandomBetween(1, N);
                if (mutateFactor == 1)
                {
                    //get a Random bit index for C and D
                    int bitCIndx = NumberHelper.RandomBetween(0, 7);
                    personData[rowIndx][colIndx][m][bitCIndx] = !personData[rowIndx][colIndx][m][bitCIndx];
                }
            }
        }

        protected void MutateR(int rowIndx, int colIndx, List<List<List<BitArray>>> personData)
        {
            //Mutate at least one, up to 5
            int mutateFactor = NumberHelper.RandomBetween(0, 523);
            int mutateCount = 1;
            if (mutateFactor % 5 == 0)
                mutateCount = 5;
            else if (mutateFactor % 4 == 0)
                mutateCount = 4;
            else if (mutateFactor % 3 == 0)
                mutateCount = 3;
            else if (mutateFactor % 2 == 0)
                mutateCount = 2;

            List<int> cChanges = new List<int>();
            for (int m = 0; m < mutateCount; m++)
            {
                //get a Random bit index for C and D
                int bitCIndx = NumberHelper.RandomBetween(0, 7);

                //get a random (but not already used) BitArray to mutate for C
                int bitAryCIndx = NumberHelper.RandomBetween(0, personData[rowIndx][colIndx].Count - 1);
                while (cChanges.IndexOf(bitAryCIndx) >= 0)
                {
                    bitAryCIndx = NumberHelper.RandomBetween(0, personData[rowIndx][colIndx].Count - 1);
                }

                personData[rowIndx][colIndx][bitAryCIndx][bitCIndx] = !personData[rowIndx][colIndx][bitAryCIndx][bitCIndx];
            }
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            ts?.Cancel();
            parentForm.EnableRun();
            if (graph != null && !graph.IsDisposed) graph.Close();

            parentForm.WindowState = FormWindowState.Normal;
            base.OnClosing(e);
        }

        protected void ShowFitnessGraph()
        {
            if (graph == null || graph.IsDisposed)
                graph = new bDNA_FitnessGraph(this);

            if (Application.OpenForms["bDNA_FitnessGraph"] == null)
                graph.Show();

            graph.BringToFront();
        }

        protected void WriteLogFile()
        {
            string saveFileName = saveLogFileDialog.FileName;
            if (string.IsNullOrEmpty(saveFileName)) saveFileName = string.Format("{0}\\{1}.log", OutputDir, OuputDirName);
            File.WriteAllText(saveFileName, txtOutput.Text);
            saveLogFileDialog.FileName = string.Empty;
        }

        protected void WriteFitnessHistoryFile()
        {
            string FitnessHistoryFilename = string.Format("{0}\\{1}.fit", OutputDir, OuputDirName);
            //if (File.Exists(FitnessHistoryFilename)) File.WriteAllText(FitnessHistoryFilename, string.Empty);

            FitnessHistory fitHistory = new FitnessHistory()
            {
                Highs = FitnessHighs,
                Lows = FitnessLows,
                Avgs = FitnessAvgs,
                Correct = FitnessCorrect,
                MostCorrect = FitnessMaxCorrect
            };
            
            using (Stream sw = File.Open(FitnessHistoryFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(sw, fitHistory);
            }
        }

        #region Directory Helpers

        protected string OuputDirName
        {
            get
            {
                string[] outputDir = OutputDir.Split('\\');
                return outputDir[outputDir.Length - 1];
            }
        }

        protected string OutputDir
        {
            get
            {
                string outDir = TestRequest.OutputDirectory;

                if (!Directory.Exists(outDir))
                    Directory.CreateDirectory(outDir);

                if(TestRequest.CreateSubDirectory && string.IsNullOrEmpty(subDir))
                {
                    outDir = string.Format("{0}\\{1}", outDir, Guid.NewGuid());
                    if (!Directory.Exists(outDir))
                        Directory.CreateDirectory(outDir);
                }

                return outDir;
            }
        }

        protected string OutputDNADir
        {
            get
            {
                string bDNADir = string.Format("{0}\\{1}", OutputDir, FPGAConfig.DIR_bDNA);
                if (!Directory.Exists(bDNADir))
                    Directory.CreateDirectory(bDNADir);
                return bDNADir;
            }
        }

        #endregion

        private void btnWriteLogToFile_Click(object sender, EventArgs e)
        {
            DialogResult rslt = saveLogFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveLogFileDialog.FileName))
            {
                WriteLogFile();
                WriteFitnessHistoryFile();
                MessageBox.Show(string.Format("Log File Saved to: {0}", saveLogFileDialog.FileName));
            }
        }

        private void btnOpenGraph_Click(object sender, EventArgs e)
        {
            ShowFitnessGraph();
        }
    }
}