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

    public partial class audio_info : Form
    {
        public int earnedcolorpoints;
        public int earnedkretpoints;

        public audio_info(int colorpoints,int kretpoints)
        {
            InitializeComponent();
            earnedcolorpoints = colorpoints;
            earnedkretpoints= kretpoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //move to next form
            this.Hide();
            audio_warmup f8 = new audio_warmup(earnedcolorpoints,earnedkretpoints);
            f8.ShowDialog();
            this.Close();
        }

        private void audio_info_Load(object sender, EventArgs e)
        {

        }
    }
}
