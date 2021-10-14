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

namespace ChartsVisualisation
{
    public partial class Form1 : Form
    {
        BusinessLogic businessLogic;
        public Form1()
        {
            InitializeComponent();
            businessLogic = new BusinessLogic();
            chart1.Series.Clear();
            chart2.Series.Clear();
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            if(fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                //businessLogic._fileName = "C:\\Users\\vdv30\\Downloads\\iris.csv";
                businessLogic._fileName = fileDialog.FileName;
              FileName.Text = System.IO.Path.GetFileName(fileDialog.FileName);
            }
            try
            {
                businessLogic.ReadFile();
                paintGraphic();
                paintPie();
            }
            catch (Exception eror)
            {
                MessageBox.Show(
                    eror.Message,
                    "Сообщение");
                //chart1.Series.Clear();
                //chart2.Series.Clear();
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
            }
        }
    }
}
