using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FPGA
{
    public static class ByteHelper
    {
        public static Encoding Encoding { get { return Encoding.ASCII; } }        

        public static BitArray Empty8BitArray { get { return new BitArray(new bool[] { false, false, false, false, false, false, false, false }); } }

        public static BitArray RandomBitArray
        {
            get
            {
                BitArray byteData = new BitArray(8);
                for (int x = 8; x > 0; x--)
                {
                    int randVal = NumberHelper.RandomBetween(1, 500);
                    byteData[x - 1] = randVal % 2 == 0;
                }
                return byteData;
            }
        }

        public static BitArray ToBitArray(this byte b)
        {
            bool[] vals = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                vals[i] = (b & 0x80) != 0;
                b *= 2;
            }
            return new BitArray(vals);
        }

        public static byte ToByte(this BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        public static BitArray ToBitArray(this string obj)
        {
            byte[] x = Encoding.GetBytes(obj);
            BitArray b = new BitArray(x);
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            return b;
        }

        public static List<List<List<BitArray>>> ToBitArrayTable(this byte[] byteData, int bytesPerCell, int columnCount)
        {
            List<List<List<BitArray>>> config = new List<List<List<BitArray>>>();
            int row = 0,
                col = 0,
                count = 0;

            //Add our first row
            config.Add(new List<List<BitArray>>() { new List<BitArray>() });
            foreach (byte configByte in byteData)
            {
                if (count != 0 && config.Count <= row)
                    config.Add(new List<List<BitArray>>() { new List<BitArray>() });

                if (col != 0 && config[row].Count <= col)
                    config[row].Add(new List<BitArray>());

                BitArray configData = configByte.ToBitArray();
                config[row][col].Add(configData);

                count++;
                //{n} bytes per cell (col)
                if (count % bytesPerCell == 0)
                {
                    col++;
                    if (col >= columnCount)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            return config;
        }

        public static byte[] BitArrayTableToByteArray(this List<List<List<BitArray>>> bitTable)
        {
            List<byte> byteData = new List<byte>();
            foreach(List<List<BitArray>> row in bitTable)
            {
                foreach(List<BitArray> col in row)
                {
                    foreach(BitArray bitData in col)
                    {
                        bitData.Reverse();
                        byteData.Add(bitData.ToByte());
                    }
                    col.Reverse();
                }
            }
            //byteData.Reverse();

            return byteData.ToArray();
        }

        public static void Reverse(this BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }
}
