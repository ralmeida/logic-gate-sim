using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA
{
    public enum SolverPhase
    {
        NONE = -1,
        Test = 1,
        Fitness = 2,
        Split = 3
    }
}
