namespace FPGA
{
    /// <summary>
    /// FPGA Cell Output
    /// </summary>
    public class FPGABoard_Output
    {
        /// <summary>
        /// Where is the output going
        /// </summary>
        public FPGA_ADDRESS Address { get; set; }

        /// <summary>
        /// What is the output
        /// </summary>
        public bool Value { get; set; }

        /// <summary>
        /// Create a new FPGA Output
        /// </summary>
        /// <param name="address">Where is the output to</param>
        /// <param name="value">What is the output value</param>
        public FPGABoard_Output(FPGA_ADDRESS address, bool value)
        {
            Address = address;
            Value = value;
        }
    }
}
