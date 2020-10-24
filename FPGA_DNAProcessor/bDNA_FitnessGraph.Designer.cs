namespace FPGA_DNAProcessor
{
    partial class bDNA_FitnessGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0.275D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.15668D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.1235D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0.21D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0.156D);
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0.4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0.4567D);
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0.3235D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 0.365D);
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0.532D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0.6546D);
            this.chartFitnessProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.statusStripGraph = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerSeconds = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartFitnessProgress)).BeginInit();
            this.statusStripGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartFitnessProgress
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Generation";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IntervalOffset = 0.05D;
            chartArea1.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 1.5D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartAreaMain";
            this.chartFitnessProgress.ChartAreas.Add(chartArea1);
            this.chartFitnessProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.DockedToChartArea = "ChartAreaMain";
            legend1.Name = "LegendMain";
            legend1.Title = "Legend";
            this.chartFitnessProgress.Legends.Add(legend1);
            this.chartFitnessProgress.Location = new System.Drawing.Point(0, 0);
            this.chartFitnessProgress.Name = "chartFitnessProgress";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartAreaMain";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "LegendMain";
            series1.Name = "HighSeries";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartAreaMain";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "LegendMain";
            series2.Name = "LowSeries";
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            series2.Points.Add(dataPoint7);
            series2.Points.Add(dataPoint8);
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartAreaMain";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "LegendMain";
            series3.Name = "AvgSeries";
            series3.Points.Add(dataPoint9);
            series3.Points.Add(dataPoint10);
            series3.Points.Add(dataPoint11);
            series3.Points.Add(dataPoint12);
            series3.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartAreaMain";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Color = System.Drawing.Color.DarkGoldenrod;
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            series4.Legend = "LegendMain";
            series4.Name = "CorrectSeries";
            series4.Points.Add(dataPoint13);
            series4.Points.Add(dataPoint14);
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartAreaMain";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series5.Color = System.Drawing.Color.DarkGreen;
            series5.Legend = "LegendMain";
            series5.Name = "MaxCorrectSeries";
            series5.Points.Add(dataPoint15);
            series5.Points.Add(dataPoint16);
            series5.Points.Add(dataPoint17);
            this.chartFitnessProgress.Series.Add(series1);
            this.chartFitnessProgress.Series.Add(series2);
            this.chartFitnessProgress.Series.Add(series3);
            this.chartFitnessProgress.Series.Add(series4);
            this.chartFitnessProgress.Series.Add(series5);
            this.chartFitnessProgress.Size = new System.Drawing.Size(484, 461);
            this.chartFitnessProgress.TabIndex = 0;
            this.chartFitnessProgress.TabStop = false;
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 3000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // statusStripGraph
            // 
            this.statusStripGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUpdate});
            this.statusStripGraph.Location = new System.Drawing.Point(0, 439);
            this.statusStripGraph.Name = "statusStripGraph";
            this.statusStripGraph.Size = new System.Drawing.Size(484, 22);
            this.statusStripGraph.TabIndex = 1;
            this.statusStripGraph.Text = "statusStrip1";
            this.statusStripGraph.Visible = false;
            // 
            // toolStripStatusLabelUpdate
            // 
            this.toolStripStatusLabelUpdate.Name = "toolStripStatusLabelUpdate";
            this.toolStripStatusLabelUpdate.Size = new System.Drawing.Size(115, 17);
            this.toolStripStatusLabelUpdate.Text = "Next Update in 00:00";
            // 
            // timerSeconds
            // 
            this.timerSeconds.Enabled = true;
            this.timerSeconds.Interval = 3000;
            this.timerSeconds.Tick += new System.EventHandler(this.timerSeconds_Tick);
            // 
            // bDNA_FitnessGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.statusStripGraph);
            this.Controls.Add(this.chartFitnessProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "bDNA_FitnessGraph";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "bDNA FitnessGraph";
            ((System.ComponentModel.ISupportInitialize)(this.chartFitnessProgress)).EndInit();
            this.statusStripGraph.ResumeLayout(false);
            this.statusStripGraph.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFitnessProgress;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.StatusStrip statusStripGraph;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdate;
        private System.Windows.Forms.Timer timerSeconds;
    }
}