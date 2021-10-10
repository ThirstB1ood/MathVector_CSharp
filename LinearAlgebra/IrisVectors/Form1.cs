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
        }

        private void FileSelect_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv";
            //if(fileDialog.ShowDialog() != DialogResult.Cancel)
            //{
                businessLogic._fileName = "C:\\Users\\vdv30\\Downloads\\iris.csv";
              //  FileName.Text = System.IO.Path.GetFileName(fileDialog.FileName);
            //}
            businessLogic.ReadFile();
            int a = 3;
            chart1.BackColor = Color.Gray;
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
            series1.Points.Add(4);
        }
    }
}
