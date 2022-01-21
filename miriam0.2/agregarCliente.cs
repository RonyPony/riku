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
    public partial class agregarCliente : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;

        public agregarCliente(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            this.Text = "Agregar Cliente ["+usuario+"]";
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
                string apellidos = txtapellidos.Text;
                string telefono = txttelefono.Text;
                string tipo = txttipo.Text;
                string comentarios = txtcomentario.Text;
                string clientedesde = Convert.ToString(txtfecha.Value) ;
                conexion.abrir();
                string consulta = "INSERT INTO clientes (nombre,apellidos,tipo,clientedesde,telefono,comentario)" +
                    "VALUES" +
                    "('" + nombre + "','" + apellidos + "','" + tipo + "','" + clientedesde + "','" + telefono + "','"+comentarios+"')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                MessageBox.Show("Cliente Guardado.");
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
            txtapellidos.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txttipo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void agregarCliente_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Agregar cliente cargado.");
        }
    }
}
