namespace FPGA
{
    /// <summary>
    /// FPGA Cell Input is representing a 'signal'
    /// </summary>
    public class FPGACell_Input
    {
        /// <summary>
        /// What Address is the Input from
        /// </summary>
        public FPGA_ADDRESS From { get; set; } = new FPGA_ADDRESS() { Row = -2, Column = -2 };

        /// <summary>
        /// What Port is the Input from
        /// </summary>
        public int OutputPort { get; set; } = -2;

        /// <summary>
        /// What is the Input Value
        /// </summary>
        public bool Value { get; set; } = false;

        /// <summary>
        /// New CellInput, with Default Address and -2 OutputPort
        /// </summary>
        /// <param name="fromAddress">Where is the Input From</param>
        /// <param name="inOutputByte">What Port is the Output using</param>
        public FPGACell_Input(FPGA_ADDRESS fromAddress = new FPGA_ADDRESS(), int outputPort = -2)
        {
            From = fromAddress;
            OutputPort = outputPort;
        }
    }
}
