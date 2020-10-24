using System;
using System.Collections;
using System.Security.Cryptography;

namespace FPGA
{
    public class NumberHelper
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int RandomBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

        public static int GetIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        public static long GetLongFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > 64)
                throw new ArgumentException("Argument length shall be at most 64 bits.");

            long[] array = new long[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
