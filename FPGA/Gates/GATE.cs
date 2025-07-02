using System.Linq;
namespace FPGA
{
    /// <summary>
    /// Logic Gates
    /// </summary>
    public static class GATE
    {
        /// <summary>
        /// NOT Gate (inverter)
        /// </summary>
        /// <param name="x">0/1 to invert</param>
        /// <returns></returns>
        public static bool NOT(bool x)
        {
            return !x;
        }

        /// <summary>
        /// 2 Input AND Gate
        /// </summary>
        /// <param name="x">Input 0</param>
        /// <param name="y">Input 1</param>
        /// <returns>Output</returns>
        public static bool AND(bool x, bool y)
        {
            return (x && y);
        }
        /// <summary>
        /// Multi Input AND Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool AND(bool[] vals)
        {
            bool totalRslt = false;
            if (vals.Length < 2) return totalRslt;
            for (int i = 0; i < vals.Length; i++)
            {
                totalRslt = vals[i];
                if (!totalRslt) break;
            }
            return totalRslt;
        }

        /// <summary>
        /// 2 Input NAND Gate
        /// </summary>
        /// <param name="x">Input 0</param>
        /// <param name="y">Input 1</param>
        /// <returns>Output</returns>
        public static bool NAND(bool x, bool y)
        {
            return NOT(AND(x, y));
        }
        /// <summary>
        /// Multi Input NAND Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool NAND(bool[] vals)
        {
            return NOT(AND(vals));
        }

        /// <summary>
        /// 2 Input OR Gate
        /// </summary>
        /// <param name="x">Input 0</param>
        /// <param name="y">Input 1</param>
        /// <returns>Output</returns>
        public static bool OR(bool x, bool y)
        {
            return NOT(NOT(x) && NOT(y));
        }
        /// <summary>
        /// Multi Input OR Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool OR(bool[] vals)
        {
            bool totalRslt = false;
            if (vals.Length < 2) return totalRslt;
            for (int i = 0; i < vals.Length; i++)
            {
                totalRslt = vals[i];
                if (totalRslt) break;
            }
            return totalRslt;
        }

        /// <summary>
        /// 2 Input NOR Gate
        /// </summary>
        /// <param name="x">Input 0</param>
        /// <param name="y">Input 1</param>
        /// <returns>Output</returns>
        public static bool NOR(bool x, bool y)
        {
            return NOT(OR(x, y));
        }
        /// <summary>
        /// Multi Input NOR Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool NOR(bool[] vals)
        {
            return NOT(OR(vals));
        }

        /// <summary>
        /// 2 Input XOR Gate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool XOR(bool x, bool y)
        {
            return NOT(x == y);
        }
        /// <summary>
        /// Multi Input XOR Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool XOR(bool[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            return vals.Aggregate(false, (current, val) => current ^ val);
        }
        
        /// <summary>
        /// 2 Input XNOR Gate
        /// </summary>
        /// <param name="x">Input 0</param>
        /// <param name="y">Input 1</param>
        /// <returns>Output</returns>
        public static bool XNOR(bool x, bool y)
        {
            return AND(x, y) || NOR(x, y);
        }
        /// <summary>
        /// Multi Input XNOR Gate
        /// </summary>
        /// <param name="vals">Input 0-n</param>
        /// <returns>Output</returns>
        public static bool XNOR(bool[] vals)
        {
            return !XOR(vals);
        }
    }
}
