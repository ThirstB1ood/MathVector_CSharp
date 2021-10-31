using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace ChartsVisualisation
{
    public partial class Irises : Form
    {
        private readonly BusinessLogic businessLogic;

        public Irises()
        {
            InitializeComponent();
            businessLogic = new BusinessLogic();
            ClearCharts();
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv" };

            if (fileDialog.ShowDialog() != DialogResult.Cancel && File.Exists(fileDialog.FileName))
            {
                FileName.Text = Path.GetFileName(fileDialog.FileName);

                try
                {
                    businessLogic.ReadFile(fileDialog.FileName);

                    PaintGraphs();
                }
                catch (Exception exception)
                {
                    OutputError(exception.Message);
                }
            }
            else
            {
                OutputError("No file selected");
            }
        }


        private void PaintGraphs()
        {
            OutputError("Graphs were built");

            PaintGraphic();
            PaintPie();
        }

        
        private void PaintPie()
        {
            Series series = chart2.Series.Add("");

            series.Points.Add(businessLogic.Length("Setosa and Versicolor"));
            series.Points.Add(businessLogic.Length("Setosa and Virginica"));
            series.Points.Add(businessLogic.Length("Versicolor and Virginica"));

            series.Points[0].LegendText = "Setosa and Versicolor";
            series.Points[1].LegendText = "Setosa and Virginica";
            series.Points[2].LegendText = "Versicolor and Virginica";

            series.Points[0].Label = (Math.Round(businessLogic.Length("Setosa and Versicolor"), 2)).ToString();
            series.Points[1].Label = (Math.Round(businessLogic.Length("Setosa and Virginica"), 2)).ToString();
            series.Points[2].Label = (Math.Round(businessLogic.Length("Versicolor and Virginica"), 2)).ToString();

            series.ChartType = SeriesChartType.Pie;
        }

        private void PaintGraphic()
        {
            Series series = this.chart1.Series.Add("Setosa");
            for(int i = 0; i < businessLogic.GetAverageVector("Setosa").Dimensions; i++)
            {
                series.Points.Add(businessLogic.GetAverageVector("Setosa")[i]);
            }

            Series series1 = this.chart1.Series.Add("Versicolor");
            for (int i = 0; i < businessLogic.GetAverageVector("Versicolor").Dimensions; i++)
            {
                series1.Points.Add(businessLogic.GetAverageVector("Versicolor")[i]);
            }

            Series series2 = this.chart1.Series.Add("Virginica");
            for (int i = 0; i < businessLogic.GetAverageVector("Virginica").Dimensions; i++)
            {
                series2.Points.Add(businessLogic.GetAverageVector("Virginica")[i]);
            }
            series.Points[0].AxisLabel = "sepal\nlength";
            series.Points[1].AxisLabel = "sepal\nwidth";
            series.Points[2].AxisLabel = "petal\nlength";
            series.Points[3].AxisLabel = "petal\nwidth";

            series.IsValueShownAsLabel = true;
            series.SmartLabelStyle.Enabled = false;

            series1.IsValueShownAsLabel = true;
            series1.SmartLabelStyle.Enabled = false;

            series2.IsValueShownAsLabel = true;
            series2.SmartLabelStyle.Enabled = false;

            Axis ax = new Axis();
            ax.Title = "Characterictics";
            chart1.ChartAreas[0].AxisX = ax;

            Axis ay = new Axis();
            ay.Title = "Values";
            chart1.ChartAreas[0].AxisY = ay;
        }

        private void ClearCharts()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
        }

        private void Irises_Load(object sender, EventArgs e)
        {
            errors.Text = "Size less than 10 KB";
        }

        private void OutputError(string error)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            errors.Text = error;
        }
    }
}
