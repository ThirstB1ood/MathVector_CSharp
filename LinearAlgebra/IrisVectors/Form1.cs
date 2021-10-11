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
            catch (Exception)
            {
                MessageBox.Show(
                    "не то",
                    "Сообщение");
            }


            /*chart1.BackColor = Color.Gray;
            Series series = this.chart1.Series.Add("ghbdtn");
            this.chart1.Palette = ChartColorPalette.EarthTones;
            Axis ax = new Axis();
            ax.Title = "Частота";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Вольт";
            chart1.ChartAreas[0].AxisY = ay;
            series.Points.Add(3);
            series.Points.Add(5);
            Series series1 = this.chart1.Series.Add("ghbd");
            series1.Points.Add(4);*/

        }

        private void paintPie()
        {
            Series series = chart2.Series.Add("Re");
            series.Points.Add(businessLogic.length("Setosa and Versicolor"));
            series.Points.Add(businessLogic.length("Setosa and Virginica"));
            series.Points.Add(businessLogic.length("Versicolor and Virginica"));
            Title AreaTitle = new Title("Pie diagram", Docking.Top, new Font("Verdana", 10), Color.Black);
            chart2.Titles.Add(AreaTitle);
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
