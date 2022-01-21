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
    public partial class consultarSuplidor : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        int productostotal = 0;
        string selected;
        string usuario;
        string tipo;

        public consultarSuplidor(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();

        }

        public void buscar() {
            try
            {
                if (comboBox1.Text == "Seleccionar...") {conexion.inform("Primero seleccione un criterio de busqueda"); }
                else
                {
                    string texto = textBox1.Text;
                    string colu = comboBox1.Text;
                    string query = "SELECT * FROM suplidores WHERE " + colu + " LIKE '%" + texto + "%';";
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
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void consultarSuplidor_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Consultar suplidor cargado.");
            cargar();
        }

        public void cargar()
        {
            try
            {
                dataGridView1.DataSource = conexion.getTable("suplidores",string.Empty);
               
                getTotal();
                error.Text = productostotal.ToString() + " suplidores en total";
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
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
                productostotal = conexion.getCount("suplidores",string.Empty);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + ex.ToString());
                conexion.showError(ex);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarSuplidor aaa = new agregarSuplidor(usuario);
            aaa.MdiParent = this.ParentForm;
            aaa.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea elimnar " + dataGridView1.CurrentRow.Cells["nombre"].Value.ToString().ToUpper() + " de manera permanente de la lista de suplidores?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    selected = dataGridView1.CurrentRow.Cells["idsuplidor"].Value.ToString();
                    conexion.abrir();
                    string consulta = "delete from suplidores where idsuplidor= '" + selected + "';";
                    SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                    comando.ExecuteNonQuery();

                    conexion.inform("Elemento eliminado");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(pp.ToString());
                    conexion.showError(ex);
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
            if (conexion.isAdmin(usuario))
            {
                button2.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarSuplidor aaa = new agregarSuplidor(usuario);
            aaa.MdiParent = this.ParentForm;
            aaa.Show();
        }
    }
}
