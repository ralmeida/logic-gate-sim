using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA
{
    public class bDNA_Test_Request
    {
        public bool Resume { get; set; } = false;

        public string OutputDirectory { get; set; } = "";
        public bool CreateSubDirectory { get; set; } = false;

        public string TestInputsFileData { get; set; } = null;
        public string TestInputsFile { get; set; } = "";

        public int PopulationSize { get; set; } = 0;

        public int SquareSize { get; set; } = 0;

        public int InputCount { get; set; } = 0;
        public int OutputCount { get; set; } = 0;

        public bool ShowFitnessGraph { get; set; } = true;

        public bool CullHerd { get; set; } = false;
        public GenitcSwapMethod SwapMethod { get; set; } = GenitcSwapMethod.TwoBit;

        public GeneticMutationMethod MutationMethod { get; set; } = GeneticMutationMethod.OutOfN;
        public int MutationN { get; set; } = 1000;

        public bDNA_Test_Request() { }
        public bDNA_Test_Request(string testFile,
                                 string outDir,
                                 bool createSubDir,
                                 int popSize, 
                                 int sqSize, 
                                 int inCount, 
                                 int outCount,
                                 bool resume,
                                 bool showFitnessGraph,
                                 GenitcSwapMethod swapMethod)
        {

            TestInputsFile = testFile;
            OutputDirectory = outDir;

            CreateSubDirectory = createSubDir;

            PopulationSize = popSize;

            SquareSize = sqSize;

            InputCount = inCount;
            OutputCount = outCount;

            Resume = resume;

            ShowFitnessGraph = showFitnessGraph;

            SwapMethod = swapMethod;
        }
    }
}
