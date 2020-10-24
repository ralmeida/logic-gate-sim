using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FPGA
{
    public class FileHelper
    {
        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                using (FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write))
                {
                    // Writes a block of bytes to this stream using data from
                    // a byte array.
                    _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                }

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        public static byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
        
        public static void GetFileBits(string fileName, string outputFileName = null)
        {
            if (outputFileName == null) outputFileName = string.Format(@"C:\Apps\{0}.txt", Guid.NewGuid());

            byte[] fileBytes = File.ReadAllBytes(fileName);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in fileBytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            File.WriteAllText(outputFileName, sb.ToString());
            Console.WriteLine("File [{0}] Created with Bit Data from [{1}]", outputFileName, fileName);
        }

        public static void RandomByte(int i, byte[] fileData)
        {
            BitArray byteData = new BitArray(8);
            for (int x = 8; x > 0; x--)
            {
                int randVal = NumberHelper.RandomBetween(1, 500);
                byteData[x - 1] = randVal % 2 == 0;
            }
            
            fileData[i] = ConvertToByte(byteData);
        }

        public static byte[] MakeFile(int fileByteSize)
        {
            int byteArySize = fileByteSize,
                bufferAmount = 0;

            int byteArySizeBuffed = byteArySize + bufferAmount;

            byte[] fileData = new byte[byteArySizeBuffed];

            //these are backwards... do note! (This will give you the string "Test"
            //fileData[0] = ConvertToByte(new BitArray(new bool[] { false, false, true, false, true, false, true, false })); //{ false, true, false, true, false, true, false, false })); //T
            //fileData[1] = ConvertToByte(new BitArray(new bool[] { true, false, true, false, false, true, true, false })); //{ false, true, true, false, false, true, false, true })); //e
            //fileData[2] = ConvertToByte(new BitArray(new bool[] { true, true, false, false, true, true, true, false })); //{ false, true, true, true, false, false, true, true })); //s
            //fileData[3] = ConvertToByte(new BitArray(new bool[] { false, false, true, false, true, true, true, false })); //{ false, true, true, true, false, true, false, false })); //t

            //Task[] Tasks = new Task[byteArySize];
            List<Task> Tasks = new List<Task>();
            for (int i = bufferAmount; i < byteArySizeBuffed; i++)
            {
                RandomByte(i, fileData);
                //Task aTask = new Task(() => { RandomByte(i, fileData); });
                //aTask.Start();
                //Tasks.Add(aTask);
                //Tasks[i] = aTask;
                //Console.WriteLine("I:{0}", i);
            }

            Task.WaitAll(Tasks.ToArray());

            return fileData;
        }

        public static byte[] MakeFile(string fileName, int fileByteSize)
        {
            byte[] fileData = MakeFile(fileByteSize);
            if (ByteArrayToFile(fileName, fileData))
            {
                //Console.WriteLine("File [{0}] Created", fileName);
            }

            return fileData;
        }

        public static void MakeNewFiles(int numberOfFiles, out Dictionary<string, byte[]> Population)
        {
            Population = new Dictionary<string, byte[]>();

            for (int i = numberOfFiles; i > 0; i--)
            {
                string fileName = string.Format(@"C:\Apps\EvolveIt\{0}.txt", Guid.NewGuid());
                byte[] fileData = MakeFile(fileName, 2);
                Population.Add(fileName, fileData);
            }
        }

        public static bool ValidateFile(string fileName, string removeBefore = "Test")
        {
            bool superValid = false;
            bool valid = false;
            string fileOutput = File.ReadAllText(fileName).Replace(removeBefore, "").Trim();
            //Console.WriteLine("{0}\r\n: [{1} | ({2})]", fileName, fileOutput, fileOutput.Length);
            if (fileOutput.Length > 1)
            {
                if (fileOutput[0] == 'R' &&
                    fileOutput[1] == 'O')
                {
                    Console.WriteLine("** WE Found a WINNER!!! **");
                    Console.WriteLine("");
                    superValid = true;
                }
            }

            if (!superValid)
            {
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    if (valid == true && char.IsLetterOrDigit(fileOutput[i]))
                        superValid = true;
                    else if (char.IsLetterOrDigit(fileOutput[i]))
                        valid = true;
                }
            }

            if (valid)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Success! At least one letter or Number was generated on file: {0}\r\n\r [{1}]", fileName, fileOutput);
                Console.WriteLine("");
            }
            //else Console.WriteLine("Fail! No letter or number was present on file: {0}", fileName);

            return superValid;
        }

        public static void ValidateFiles(Dictionary<string, byte[]> Population, bool deleteInvalid = true)
        {
            int successes = 0;
            string[] filesToValidate = Directory.GetFiles(@"C:\Apps\EvolveIt");
            foreach (string fileToValidate in filesToValidate)
            {
                if (!ValidateFile(fileToValidate))
                {
                    if (Population.ContainsKey(fileToValidate))
                    {
                        Population.Remove(fileToValidate);
                    }

                    if (deleteInvalid) File.Delete(fileToValidate);
                }
                else successes++;
            }
            Console.WriteLine("Successes: {0}", successes);
        }
    }
}
