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
    public partial class consultarVentas : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;
        int ventasTotal;

        public consultarVentas(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
        }

        private void consultarVentas_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Consultar ventas cargado.");
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
                dataGridView1.DataSource = conexion.getTable("ventas", colu.Text + " LIKE '%" + texto.Text + "%'");
                
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
                dataGridView1.DataSource = conexion.getTable("ventas",string.Empty);
                getTotal();
                error.Text = ventasTotal.ToString() + " ventas en total";
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


        public void getTotal()
        {
            try
            {
                ventasTotal = conexion.getCount("ventas",string.Empty); ;
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

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void texto_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea elimnar la venta numero " + dataGridView1.CurrentRow.Cells["idventa"].Value.ToString() + " de manera permanente de la lista de ventas ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    string selected = dataGridView1.CurrentRow.Cells["idventa"].Value.ToString();
                    conexion.abrir();
                    string consulta = "delete from ventas where idventa= '" + selected + "';";
                    SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Elemento eliminado", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (conexion.isAdmin(usuario))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.getCount("ventas",string.Empty)>=1)
                {
                    string id = dataGridView1.CurrentRow.Cells["idventa"].Value.ToString();
                    FacturaViewer ff = new FacturaViewer(usuario, id);
                    ff.Show();
                }
                else
                {
                    errorManager ho = new errorManager("info", new Exception("No se han realizado ventas aun.")) ;
                    ho.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(vv.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            facturar ff = new facturar(usuario);
            ff.Show();
        }
    }
}
