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
    public partial class conversor : Form
    {
        log log = new log();
        string usuario;
        public conversor(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                double a = Convert.ToDouble(textBox2.Text);
                double result = a / 16;
                textBox1.Text = result.ToString();
            }
            else { textBox1.Clear(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                double a = Convert.ToDouble(textBox3.Text);
                double result = a / 2.205;
                textBox4.Text = result.ToString();
            }
            else { textBox4.Clear(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                double a = Convert.ToDouble(textBox4.Text);
                double result = a*2.205;
                textBox3.Text = result.ToString();
            }
            else { textBox3.Clear(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                double a = Convert.ToDouble(textBox5.Text);
                double result = a * 453.592;
                textBox6.Text = result.ToString();
            }
            else { textBox6.Clear(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                double a = Convert.ToDouble(textBox6.Text);
                double result = a / 453.592;
                textBox5.Text = result.ToString();
            }
            else { textBox5.Clear(); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                double a = Convert.ToDouble(textBox7.Text);
                double result = a / 2204.623;
                textBox8.Text = result.ToString();
            }
            else { textBox8.Clear(); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                double a = Convert.ToDouble(textBox8.Text);
                double result = a * 2204.623;
                textBox7.Text = result.ToString();
            }
            else { textBox7.Clear(); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double a = Convert.ToDouble(textBox1.Text);
                double result = a * 16;
                textBox2.Text = result.ToString();
            }
            else { textBox2.Clear(); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void conversor_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Conversor cargado.");
        }
    }
}
