using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku.controls
{
    public partial class progressBar : UserControl
    {
        int i;
        bool backmode = false;
        public progressBar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //667;

            if (backmode)
            {
                flowLayoutPanel1.Location = new Point(i, flowLayoutPanel1.Location.Y);
                i--;
            }
            else
            {
                flowLayoutPanel1.Location = new Point(i, flowLayoutPanel1.Location.Y);
                i++;
                if (flowLayoutPanel1.Location.X == 500)
                {
                    backmode = false;
                }
            }

            
        }

        private void progressBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

    }
}
