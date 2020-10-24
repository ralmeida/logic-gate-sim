namespace FPGA
{
    /// <summary>
    /// FPGA Output Address maps Where to Go and what Port is being used
    /// </summary>
    public class FPGACell_OutputAddress
    {
        /// <summary>
        /// Where is the Output going
        /// </summary>
        public FPGA_ADDRESS To { get; set; }

        /// <summary>
        /// What port is the output using
        /// </summary>
        public int OutputPort { get; set; }

        /// <summary>
        /// Create a new OutputAddress
        /// </summary>
        /// <param name="toAddress">Where is the Rquest going</param>
        /// <param name="outputPort">Where is the Request coming from</param>
        public FPGACell_OutputAddress(FPGA_ADDRESS toAddress, int outputPort = -2)
        {
            To = toAddress;
            OutputPort = outputPort;
        }
    }
}
