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
    public partial class agregarSuplidor : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;

        public agregarSuplidor(string uusuario, string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void agregarSuplidor_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Agregar suplidor cargado.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enviar();
        }


        public void enviar()
        {

            try
            {
                string nombre = txtnombre.Text;
                string direccion = txtdireccion.Text;
                string telefono = txttelefono.Text;
                string tipo = txttipo.Text;
                string comentarios = txtcomentario.Text;
                conexion.abrir();
                string consulta = "INSERT INTO suplidores (nombre,direccion,telefono,tipo,comentarios)" +
                    "VALUES" +
                    "('" + nombre + "','" + direccion + "','" + telefono + "','" + tipo + "','" + comentarios + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                MessageBox.Show("Suplidor Guardado.");
                limpiar();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + ex.ToString());
                errorManager ho = new errorManager(string.Empty,ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void limpiar()
        {
            txtcomentario.Clear();
            txtdireccion.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txttipo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
