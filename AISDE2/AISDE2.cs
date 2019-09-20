using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AISDE2
{
    public partial class AISDE2 : Form
    {
        public AISDE2()
        {
            InitializeComponent();

            Simulator sim = new Simulator();
            sim.Startsimulation(1000); //ustawia czas trwania symulacji

            var times = sim.times;
            var speeds = sim.speeds;
            var buffer = sim.bufferlenght;

            int i = 0;
            foreach (var time in times)
            {
                this.chart1.Series["szybkosc"].Points.AddXY(Math.Round(time), speeds[i]);
                this.chart1.Series["bufor"].Points.AddXY(Math.Round(time), buffer[i]);
                this.chart1.ChartAreas[0].AxisX.Title = "Czas";
                this.chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                this.chart1.ChartAreas[0].AxisY.Title = "Predkosc";
                this.chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                this.chart1.ChartAreas[0].AxisY2.Title = "Wielkosc";
                this.chart1.ChartAreas[0].AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                i++;
            }
        }

        
    }
}
