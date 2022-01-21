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
    public partial class consultarCliente : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        int productostotal = 0;
        string selected;
        string usuario;
        string tipo;

        public consultarCliente(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario); ;
            this.Text = "Consultar Cliente [" + usuario+"] ["+tipo+"]";
        }

        private void consultarCliente_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Consultar clientes cargado.");
            cargar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscar();
        }

        public void buscar()
        {
            try
            {
                if (comboBox1.Text == "Seleccionar...") { MessageBox.Show("Primero seleccione un criterio de busqueda"); }
                else
                {
                    string texto = textBox1.Text;
                    string colu = comboBox1.Text;
                    string query = "SELECT * FROM clientes WHERE " + colu + " LIKE '%" + texto + "%';";
                    SqlCommand cmd = new SqlCommand(query, conexion.ver());
                    conexion.abrir();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    dt.Fill(tb);
                    dataGridView1.DataSource = tb;
                    conexion.cerrar();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }


        public void cargar()
        {
            try
            {
                dataGridView1.DataSource= conexion.getTable("clientes", string.Empty);
                error.Text = conexion.getCount("clientes",string.Empty) + " clientes en total";
            }
            catch (Exception ex)
            {
                // MessageBox.Show("ERROR" + Convert.ToString(ex));
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
            agregarCliente cc = new agregarCliente(usuario);
            cc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea elimnar " + dataGridView1.CurrentRow.Cells["nombre"].Value.ToString().ToUpper() + " de manera permanente de la lista de clientes?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    selected = dataGridView1.CurrentRow.Cells["idcliente"].Value.ToString();
                    conexion.abrir();
                    string consulta = "delete from clientes where idcliente= '" + selected + "';";
                    SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Cliente eliminado", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(pp.ToString());
                    errorManager ho = new errorManager(string.Empty, ex);
                    ho.Show();
                }
                finally
                {
                    conexion.cerrar();
                    cargar();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarCliente invv = new agregarCliente(usuario);
            invv.MdiParent = this.ParentForm;
            invv.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tipo == "administrador" || tipo == "ADMINISTRADOR")
            {
                button2.Enabled = true;
            }
        }
    }
}
