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

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (x > 0 && y > 0)
            {
                palletPanelShow1.SetColRowNums(x, y);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox5.Text);
            int y = int.Parse(textBox4.Text);
            int status = int.Parse(textBox3.Text);
            if (x >= 0 && y >= 0 && status >= 0)
            {
                palletPanelShow1.SetXYPointStatus(x, y, status);
            }
        }
    }
}
