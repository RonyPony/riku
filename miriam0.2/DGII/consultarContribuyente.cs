using miriam0._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku.DGII
{
    public partial class consultarContribuyente : Form
    {
        string user;
        log log = new log();
        cnn conexion = new cnn();

        public consultarContribuyente(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void consultarContribuyente_Load(object sender, EventArgs e)
        {
            log.notificacion(user, "Consultar Contribuyentes de la DGII cargado.");
            label7.Text = conexion.getCount("contribuyentes", string.Empty) + " Contribuyentes registrados";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rnc = textBox1.Text;
            string[] contribu = conexion.getContribuyentes(rnc);
            if (contribu!=null)
            {
                textBox2.Text = contribu[0].ToString();
                textBox3.Text = contribu[1].ToString();
                textBox4.Text = contribu[2].ToString();
                textBox5.Text = contribu[3].ToString();
                textBox6.Text = contribu[4].ToString();
                log.notificacion(user,"Se ha consultado el RNC "+rnc);
            }
            else
            {
                conexion.inform("RNC no valido");
                log.notificacion(user, "Consulta de RNC fallida, informacion no valida (" + rnc+")");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
