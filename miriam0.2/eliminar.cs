using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using riku;

namespace miriam0._2
{
    public partial class eliminar : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;

        public eliminar(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") { button1.Enabled = true; } else { button1.Enabled = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "delete from usuarios where id = '" + textBox1.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                MessageBox.Show("Elimindo");
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verusuarios vu = new verusuarios(usuario,tipo);
            vu.Show();
        }

        private void eliminar_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Eliminar usuario cargado.");
        }
    }
}
