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

        public consultarCliente(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
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
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM clientes", conexion.ver());
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

        public void cargar()
        {
            try
            {
                conexion.abrir();
                //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                string comando = "select idcliente,nombre,apellidos,tipo,telefono,clientedesde,comentario from clientes";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                conexion.cerrar();
                getTotal();
                error.Text = productostotal.ToString() + " clientes en total";
            }
            catch (Exception ex)
            {
                // MessageBox.Show("ERROR" + Convert.ToString(ex));
                errorManager ho = new errorManager(string.Empty,ex);
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
                catch (Exception pp)
                {
                    //MessageBox.Show(pp.ToString());
                    errorManager ho = new errorManager(string.Empty,pp);
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
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarCliente cc = new agregarCliente(usuario);
            cc.Show();
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
            if (tipo == "administrador")
            {
                button2.Enabled = true;
            }
        }
    }
}
