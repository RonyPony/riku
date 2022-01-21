using riku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class consultarVentasDiaria : Form
    {
        string usuario;
        cnn conexion = new cnn();
        log log = new log();
        int total;
        int count;
        string tipo;
        string selected;

        public consultarVentasDiaria(string uusuario)
        {
            usuario = uusuario;
            tipo = conexion.getTipo(usuario).ToLower();            
            this.Text = "Ventas Diarias ["+usuario+"]";            
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarVentaDeldia vv = new agregarVentaDeldia(usuario);
            vv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void consultarVentasDiaria_Load(object sender, EventArgs e)
        {
            if (tipo == "administrador") { button2.Enabled = true; } else { button2.Enabled = false; }
            log.notificacion(usuario, "Consultar Ventas Diarias cargado");
            cargar();
        }

        public void getTotal()
        {
            try
            {
                Int32 count = conexion.getCount("ventasdiarias","");
                total = count;
                productostotal.Text = count.ToString() + " ventas en total";
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


        public void buscarDinero()
        {
            try
            {
                
                    string cantidad = textBox1.Text;
                string colu = "dinero";
                    string query = "SELECT * FROM ventasdiarias WHERE " + colu + " LIKE '%" + cantidad + "%';";
                    SqlCommand cmd = new SqlCommand(query, conexion.ver());
                    conexion.abrir();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    dt.Fill(tb);
                    dataGridView1.DataSource = tb;
                    conexion.cerrar();
                
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
                dataGridView1.DataSource = conexion.getTable("ventasdiarias",string.Empty);
                getTotal();
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

        private void button3_Click(object sender, EventArgs e)
        {
            buscarFecha();
        }

        public void buscarFecha()
        {
            try
            {
                string fecha = dateTimePicker1.Text;
                string colu = "fecha";
                string query = "SELECT * FROM ventasdiarias WHERE " + colu + " LIKE '%" + fecha + "%';";
                SqlCommand cmd = new SqlCommand(query, conexion.ver());
                conexion.abrir();
                cmd.ExecuteNonQuery();
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;
                conexion.cerrar();

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

        private void button6_Click(object sender, EventArgs e)
        {
            buscarDinero();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarVentaDeldia vv = new agregarVentaDeldia(usuario);
            vv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea elimnar la venta del " + dataGridView1.CurrentRow.Cells["fecha"].Value.ToString().ToUpper() + " de manera permanente de la lista de ventas diaria?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    selected = dataGridView1.CurrentRow.Cells["idventadiaria"].Value.ToString();
                    conexion.abrir();
                    string consulta = "delete from ventasDiarias where idventadiaria= '" + selected + "';";
                    SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Venta eliminada", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
