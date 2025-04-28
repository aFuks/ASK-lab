using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tester_kierowcy
{
    public partial class finish : Form
    {
        public finish(int colorpoints,int kretpoints,int audiopoints)
        {
            InitializeComponent();
            label2.Text = "Dokładność: " + colorpoints;
            label3.Text = "Szybkość: " + kretpoints;
            label4.Text = "Czas reakcji: " + audiopoints + "ms";
            chart1.Series.Clear();
            chart1.Series.Add("Punkty");
            chart1.Series["Punkty"].Points.AddXY("Dokładność", colorpoints);
            chart1.Series["Punkty"].Points.AddXY("Szybkość", kretpoints);
            chart1.Series["Punkty"].Points.AddXY("Czas reakcji", audiopoints);
            chart1.ChartAreas[0].AxisY.Minimum = 0; // Ustawienie minimalnej wartości osi Y
            chart1.ChartAreas[0].AxisY.Maximum = 100; // Ustawienie maksymalnej wartości osi Y
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //move to next form
            this.Hide();
            infoinfo f1 = new infoinfo();
            f1.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //close application
            Application.Exit();
        }

        private void finish_Load(object sender, EventArgs e)
        {

        }
    }
}
