using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA
{
    public class FitnessResult
    {
        public string PersonID { get; set; }
        public double Value { get; set; } = 0.0;
        public int Correct { get; set; } = 0;
        public double CorrectAvg { get; set; } = 0.0;
    }
}
