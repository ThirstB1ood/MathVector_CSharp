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
using System.Threading;

namespace ChartsVisualisation
{
    public partial class Irises : Form
    {
        BusinessLogic businessLogic;
        public Irises()
        {
            InitializeComponent();
            businessLogic = new BusinessLogic();
            clearCharts();
        }

        private void FileSelect_Click(object sender, EventArgs e)
        { 
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (fileDialog.ShowDialog() != DialogResult.Cancel && System.IO.File.Exists(fileDialog.FileName))
            {
                //businessLogic._fileName = "C:\\Users\\vdv30\\Downloads\\iris.csv";
                System.IO.FileInfo fi = new System.IO.FileInfo(fileDialog.FileName);
                if(fi.Length == 0)
                {
                    clearCharts();
                    errors.Text = "Empty file";
                    //MessageBox.Show(
                    //  "Empty file",
                    //"Error");
                }
                else if(fi.Length < 10000)
                {
                    businessLogic._fileName = fileDialog.FileName;
                    FileName.Text = System.IO.Path.GetFileName(fileDialog.FileName);
                    try
                    {
                        businessLogic.ReadFile();
                        clearCharts();
                        paintGraphic();
                        paintPie();
                    }
                    catch (Exception exeption)
                    {
                        clearCharts();
                        errors.Text = exeption.Message;
                        //MessageBox.Show(
                        //  exeption.Message,
                        //"Error read file");
                    }
                }
                else
                {
                    clearCharts();
                    Irises_Load(sender, e);
                }
            }
            else
            {
                clearCharts();
                errors.Text = "No file selected";
                // MessageBox.Show(
                 //   "No file selected", 
                   // "Error read file");
            }
        }
        
        private void paintPie()
        {
            Series series = chart2.Series.Add("");
            series.Points.Add(businessLogic.length("Setosa and Versicolor"));
            series.Points.Add(businessLogic.length("Setosa and Virginica"));
            series.Points.Add(businessLogic.length("Versicolor and Virginica"));
            series.Points[0].LegendText = "Setosa and Versicolor";
            series.Points[1].LegendText = "Setosa and Virginica";
            series.Points[2].LegendText = "Versicolor and Virginica";
            series.Points[0].Label = (Math.Round(businessLogic.length("Setosa and Versicolor"), 2)).ToString();
            series.Points[1].Label = (Math.Round(businessLogic.length("Setosa and Virginica"), 2)).ToString();
            series.Points[2].Label = (Math.Round(businessLogic.length("Versicolor and Virginica"), 2)).ToString();
            series.ChartType = SeriesChartType.Pie;
        }

        private void paintGraphic()
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
                series2.Points[0].AxisLabel = "asfgd";
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
            ax.Title = "Характеристики";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Значения";
            chart1.ChartAreas[0].AxisY = ay;
        }

        private void clearCharts()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
        }

        private void Irises_Load(object sender, EventArgs e)
        {
            errors.Text = "Это приложение принимает на вход только csv-файлы меньше 10 Кб";
            //MessageBox.Show(
              //  "Это приложение принимает на вход только csv-файлы меньше 10 Кб",
                //"Добрый день");
        }
    }
}
