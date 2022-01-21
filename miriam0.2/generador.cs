using riku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class generador : Form
    {
        public generador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = Convert.ToInt32(textBox1.Text); i < Convert.ToInt32(textBox2.Text); i++)
                {
                    //string ant = richTextBox1.Text;
                    //richTextBox1.Text = ant + "x";
                    richTextBox1.AppendText(i.ToString());
                    richTextBox1.AppendText("\n");

                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            
        }

        private void generador_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
