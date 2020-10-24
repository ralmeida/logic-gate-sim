using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA
{
    /// <summary>
    /// TEST 'Person' for the bDNA_Solver
    /// </summary>
    public class FPGAPerson
    {
        /// <summary>
        /// 'Name' {Guid}
        /// </summary>
        public string ID { get; set; } = null;

        /// <summary>
        /// Data array nasty, TODO: converto to use a Board object
        /// </summary>
        public List<List<List<BitArray>>> Data { get; set; } = new List<List<List<BitArray>>>();

        /// <summary>
        /// Store Result Outputs
        /// </summary>
        public List<string> Results { get; set; } = new List<string>();

        /// <summary>
        /// Avarage of all Fitness Results
        /// </summary>
        public double Weight { get; set; } = 0;
    }
}
