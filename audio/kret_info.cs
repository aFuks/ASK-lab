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
    public partial class kret_info : Form
    {
        public int earnedcolorpoints;
        public kret_info(int colorpoints)
        {
            InitializeComponent();
            earnedcolorpoints = colorpoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //move to next form
            this.Hide();
            kret_warmup f6 = new kret_warmup(earnedcolorpoints);
            f6.ShowDialog();
            this.Close();
        }
    }
}
