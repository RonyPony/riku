using riku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class consultarActividades : Form
    {
        log log = new log();
        cnn conexion = new cnn();
        string usuario;
        string tipo;

        public consultarActividades(string uusuario)
        {
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);

            InitializeComponent();
        }

        private void consultarActividades_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario,"Consultar Actividades ha sido cargado");
            cargar();
            tipo = tipo.ToLower();
            if (tipo=="administrador") { button2.Enabled = true; }
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
                    string query = "SELECT * FROM actividades WHERE " + colu + " LIKE '%" + texto + "%';";
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
                // MessageBox.Show(ex.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }


        public void getTotal()
        {
            try
            {
                Int32 count = conexion.getCount("actividades","");
                int total = count;
                error.Text = count.ToString()+" actividades en total";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + ex.ToString());
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
                dataGridView1.DataSource = conexion.getTable("actividades","");
                getTotal();
               // error.Text = productostotal.ToString() + " clientes en total";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + Convert.ToString(ex));
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
            agregarActividad aa = new agregarActividad(usuario);
            aa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarActividad aa = new agregarActividad(usuario);
            aa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conexion.getCount("actividades","")>=1)
            {
                if (MessageBox.Show("Estas seguro que desea elimnar elemento de manera permanente de la lista de actividades?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        string selected = dataGridView1.CurrentRow.Cells["idactividad"].Value.ToString();
                        conexion.abrir();
                        string consulta = "delete from actividades where idactividad= '" + selected + "';";
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
            else
            {
                conexion.inform("No existen actvidades");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tipox = tipo.ToLower();
            if (tipox == "administrador")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
