using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Iris
{
    public partial class Irises : Form
    {
        BusinessLogic businessLogic;
        private int maxFileSize = 100; // В килобайтах
        public Irises()
        {
            InitializeComponent();
            businessLogic = new BusinessLogic();
            ClearCharts();
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            ClearCharts();
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (fileDialog.ShowDialog() != DialogResult.Cancel && System.IO.File.Exists(fileDialog.FileName))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileDialog.FileName);
                if(fi.Length == 0)
                {
                    errors.Text = "Empty file";
                }
                else if(fi.Length < 1024 * maxFileSize)
                {
                    businessLogic._fileName = fileDialog.FileName;
                    FileName.Text = System.IO.Path.GetFileName(fileDialog.FileName);
                    try
                    {
                        businessLogic.ReadFile();
                        DrawGraphic();
                        DrawPie();
                    }
                    catch (Exception exeption)
                    {
                        errors.Text = exeption.Message;
                    }
                }
                else
                {
                    Irises_Load(sender, e);
                }
            }
            else
            {
                errors.Text = "No file selected";
            }
        }
        
        private void DrawPie()
        {
            Series series = chart2.Series.Add("");
            series.Points.Add(businessLogic.Distance("Setosa and Versicolor"));
            series.Points.Add(businessLogic.Distance("Setosa and Virginica"));
            series.Points.Add(businessLogic.Distance("Versicolor and Virginica"));
            series.Points[0].LegendText = "Setosa and Versicolor";
            series.Points[1].LegendText = "Setosa and Virginica";
            series.Points[2].LegendText = "Versicolor and Virginica";
            series.Points[0].Label = (Math.Round(businessLogic.Distance("Setosa and Versicolor"), 2)).ToString();
            series.Points[1].Label = (Math.Round(businessLogic.Distance("Setosa and Virginica"), 2)).ToString();
            series.Points[2].Label = (Math.Round(businessLogic.Distance("Versicolor and Virginica"), 2)).ToString();
            series.ChartType = SeriesChartType.Pie;
        }

        private void DrawGraphic()
        {
            Series seriesSetosa = this.chart1.Series.Add("Setosa");
            for(int i = 0; i < businessLogic.GetAverageVector("Setosa").Dimensions; i++)
            {
                seriesSetosa.Points.Add(businessLogic.GetAverageVector("Setosa")[i]);
            }

            Series seriesVersicolor = this.chart1.Series.Add("Versicolor");
            for (int i = 0; i < businessLogic.GetAverageVector("Versicolor").Dimensions; i++)
            {
                seriesVersicolor.Points.Add(businessLogic.GetAverageVector("Versicolor")[i]);
            }

            Series seriesVirginica = this.chart1.Series.Add("Virginica");
            for (int i = 0; i < businessLogic.GetAverageVector("Virginica").Dimensions; i++)
            {
                seriesVirginica.Points.Add(businessLogic.GetAverageVector("Virginica")[i]);
            }
            seriesSetosa.Points[0].AxisLabel = "sepal\nlength";
            seriesSetosa.Points[1].AxisLabel = "sepal\nwidth";
            seriesSetosa.Points[2].AxisLabel = "petal\nlength";
            seriesSetosa.Points[3].AxisLabel = "petal\nwidth";
            seriesSetosa.IsValueShownAsLabel = true;
            seriesVersicolor.IsValueShownAsLabel = true;
            seriesVirginica.IsValueShownAsLabel = true;
            seriesSetosa.SmartLabelStyle.Enabled = false;
            seriesVersicolor.SmartLabelStyle.Enabled = false;
            seriesVirginica.SmartLabelStyle.Enabled = false;

            Axis ax = new Axis();
            ax.Title = "Specification";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Value";
            chart1.ChartAreas[0].AxisY = ay;
        }

        private void ClearCharts()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
        }

        private void Irises_Load(object sender, EventArgs e)
        {
            errors.Text = $"Max CSV file: {maxFileSize}Kb";
        }
    }
}
