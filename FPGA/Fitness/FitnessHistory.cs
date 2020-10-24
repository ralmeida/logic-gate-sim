using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPGA
{
    [Serializable()]
    public class FitnessHistory
    {
        public List<double> Highs { get; set; } = new List<double>();
        public List<double> Lows { get; set; } = new List<double>();
        public List<double> Avgs { get; set; } = new List<double>();
        public List<double> Correct { get; set; } = new List<double>();
        public List<double> MostCorrect { get; set; } = new List<double>();
    }
}
