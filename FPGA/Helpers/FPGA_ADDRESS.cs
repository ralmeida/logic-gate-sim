using System;

namespace FPGA
{
    /// <summary>
    /// FPGA Board Cell Address
    /// </summary>
    public struct FPGA_ADDRESS : IComparable<FPGA_ADDRESS>
    {
        /// <summary>
        /// Row Location Value
        /// </summary>
        public int Row;
        /// <summary>
        /// Columns Location Value
        /// </summary>
        public int Column;

        /// <summary>
        /// Create a new Address
        /// </summary>
        /// <param name="row">Row Location</param>
        /// <param name="column">Column Location</param>
        public FPGA_ADDRESS(int row = -1, int column = -1)
        {
            Row = row;
            Column = column;
        }
        
        /// <summary>
        /// Compare FPGA_Addresses
        /// </summary>
        /// <param name="obj">other Address</param>
        /// <returns>0 - Same | 1 - (-2) | 2 - (-1) | default: 9</returns>
        public int CompareTo(FPGA_ADDRESS obj)
        {
            if (obj.Row == Row && obj.Column == Column) return 0;
            if (obj.Row == -1 && obj.Column == -1) return 2;
            if (obj.Row == -2 && obj.Column == -2) return 1;
            return 9;
        }

        /// <summary>
        /// Simple Readable Output for Address
        /// </summary>
        /// <returns>Formated FPGA Board Cell Address</returns>
        public override string ToString()
        {
            return string.Format("[ Row: {0} | Column: {1} ]", Row, Column);
        }

        public bool Equals(FPGA_ADDRESS obj)
        {
            return (obj.Column == Column && obj.Row == Row);
        }
    }
}
