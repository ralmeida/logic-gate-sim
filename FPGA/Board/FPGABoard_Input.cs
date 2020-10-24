using System.Collections.Generic;

namespace FPGA
{
    public class FPGABoard_Input
    {
        public int InputPort { get; set; }

        public List<FPGA_ADDRESS> Addresses { get; set; }
    }
}
