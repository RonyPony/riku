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

        public consultarSuplidor(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();

        }

        public void buscar() {
            try
            {
                if (comboBox1.Text == "Seleccionar...") { MessageBox.Show("Primero seleccione un criterio de busqueda"); }
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
                //MessageBox.Show(ex.ToString());
                errorManager ho = new errorManager(string.Empty,ex);
                ho.Show();
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
                conexion.abrir();
                //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                string comando = "select idsuplidor,nombre,tipo,telefono,direccion,comentarios from suplidores";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                conexion.cerrar();
                getTotal();
                error.Text = productostotal.ToString() + " suplidores en total";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + Convert.ToString(ex));
                errorManager ho = new errorManager(string.Empty,ex);
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

                conexion.abrir();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM suplidores", conexion.ver());
                Int32 count = (Int32)comm.ExecuteScalar();
                productostotal = count;
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


        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarSuplidor aaa = new agregarSuplidor(usuario,tipo);
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

                    MessageBox.Show("Elemento eliminado", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception pp)
                {
                    //MessageBox.Show(pp.ToString());
                    errorManager ho = new errorManager(string.Empty, pp);
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
            string ti = tipo.ToLower();
            if (ti=="administrador") { button2.Enabled = true; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarSuplidor aaa = new agregarSuplidor(usuario,tipo);
            aaa.Show();
        }
    }
}
