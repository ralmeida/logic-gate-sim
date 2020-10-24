using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA
{
    public class FPGATestConfig
    {
        public string PersionID { get; set; } = null;

        public string TestFile { get; set; } = null;

        public int InputCount { get; set; } = 4;

        public int OutputCount { get; set; } = 4;
    }
}
