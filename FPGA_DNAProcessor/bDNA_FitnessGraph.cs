using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

using FPGA;

namespace FPGA_DNAProcessor
{
    public partial class bDNA_FitnessGraph : Form
    {
        bDNA_Solver SolverForm = null;

        public bDNA_FitnessGraph(bDNA_Solver parentForm)
        {
            SolverForm = parentForm;
            InitializeComponent();
            
            UpdateGraph();

            bDNA_Test_Request TestRequest = SolverForm.TestRequest;

            string mutMethod = string.Format("{0}{1}", TestRequest.MutationMethod, TestRequest.MutationMethod != GeneticMutationMethod.RMethod ? string.Format("({0})", TestRequest.MutationN) : "");
            string swapMethod = TestRequest.SwapMethod.ToString();
            string cullHerd = TestRequest.CullHerd.ToString();
            Text = string.Format("bDNA FitnessGraph | Swap: {0} | Mutation: {1} | Culling: {2}", swapMethod, mutMethod, cullHerd);
        }

        protected DataPointCollection ChartPointsHigh { get { return chartFitnessProgress.Series["HighSeries"].Points; } }
        protected DataPointCollection ChartPointsLow { get { return chartFitnessProgress.Series["LowSeries"].Points; } }
        protected DataPointCollection ChartPointsAvg { get { return chartFitnessProgress.Series["AvgSeries"].Points; } }
        protected DataPointCollection ChartPointsCorrect { get { return chartFitnessProgress.Series["CorrectSeries"].Points; } }
        protected DataPointCollection ChartPointsMaxCorrect { get { return chartFitnessProgress.Series["MaxCorrectSeries"].Points; } }

        int timerT = 0;
        private void timerTick_Tick(object sender, EventArgs e)
        {
            UpdateGraph();
            timerT = 0;
        }

        private void timerSeconds_Tick(object sender, EventArgs e)
        {
            timerT++;
            double seconds = Math.Floor((double)timerTick.Interval / 1000) - timerT;
            double mins = Math.Floor(seconds / 60);
            seconds -= (mins * 60);
            toolStripStatusLabelUpdate.Text = string.Format("Next Update in {0:00}:{1:00}", mins, seconds);
        }

        private void UpdateGraph()
        {
            if (SolverForm != null)
            {
                List<double> Highs = SolverForm.FitnessHighs;
                List<double> Lows = SolverForm.FitnessLows;
                List<double> Avgs = SolverForm.FitnessAvgs;
                List<double> Corrects = SolverForm.FitnessCorrect;
                List<double> MaxCorrect = SolverForm.FitnessMaxCorrect;

                ChartPointsHigh.Clear();
                ChartPointsLow.Clear();
                ChartPointsAvg.Clear();
                ChartPointsCorrect.Clear();
                ChartPointsMaxCorrect.Clear();

                for (int x = 0; x < Highs.Count; x++)
                {
                    ChartPointsHigh.AddXY(x, Highs[x]);
                    ChartPointsLow.AddXY(x, Lows[x]);
                    ChartPointsAvg.AddXY(x, Avgs[x]);
                }

                for (int x = 0; x < Corrects.Count; x++)
                {
                    ChartPointsCorrect.AddXY(x, Corrects[x]);
                }

                for (int x = 0; x < MaxCorrect.Count; x++)
                {
                    ChartPointsMaxCorrect.AddXY(x, MaxCorrect[x]);
                }
            }
        }
    }
}
