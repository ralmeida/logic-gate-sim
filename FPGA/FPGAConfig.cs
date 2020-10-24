namespace FPGA
{
    /// <summary>
    /// Genetic Swap Methods
    /// </summary>
    public enum GenitcSwapMethod
    {
        TwoBit,
        FourBit,
        Kenneth
    }

    /// <summary>
    /// Genetic Mutation Methods
    /// </summary>
    public enum GeneticMutationMethod
    {
        OutOfN,
        RMethod,
        ByteOutOfN
    }

    /// <summary>
    /// Static class for Config Values
    /// </summary>
    public static class FPGAConfig
    {
        /// <summary>
        /// Bytes used to define each cell
        /// </summary>
        public const int BytesPerCell = 9;

        /// <summary>
        /// Define the max square size a FPGA can have
        /// </summary>
        public const int MaxGridSquareSize = 256;

        /// <summary>
        /// Max number of External Inputs
        /// </summary>
        public const int MaxExternalInputs = 16;

        /// <summary>
        /// Max number of External Outputs
        /// </summary>
        public const int MaxExternalOutputs = 16;

        /// <summary>
        /// Max number of Internal Inputs per cell
        /// </summary>
        public const int MaxInternalInputs = 4;

        /// <summary>
        /// Max number of Internal Outputs per cell
        /// </summary>
        public const int MaxInternalOutputs = 4;

        /// <summary>
        /// Max number of times a Signal can be sent to the same Cell
        /// </summary>
        public const int InputCountLimit = 25;

        /// <summary>
        /// Directory to hold the Generation Directories
        /// </summary>
        public const string DIR_bDNA = "bDNA";
        /// <summary>
        /// Directory to hold the Results
        /// </summary>
        public const string DIR_Results = "Results";
        /// <summary>
        /// Directory to hold the Logs
        /// </summary>
        public const string DIR_Logs = "Logs";

        /// <summary>
        /// Increment on which to record the .bDNA files for the generation
        /// </summary>
        public const int GenerationsToArchive = 15;
    }
}