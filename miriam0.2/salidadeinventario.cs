using riku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class salidadeinventario : Form
    {
        log log = new log();
        cnn conexion = new cnn();
        string usuario;
        string tipo;
        String cantidadexistente;
        Double cantidadResultante;
        string restante;

        public salidadeinventario(string usuario)
        {
            tipo = conexion.getTipo(usuario);
            InitializeComponent();
        }

        private void salidadeinventario_Load(object sender, EventArgs e)
        {
            cargarProductos();
            log.notificacion(usuario,"salida de inventario cargado");
        }

        public void cargarProductos()
        {
            try
            {
                conexion.abrir();
                //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                string comando = "select nombredeproducto,marca,idproducto from inventario";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buscarProducto();
        }
        public void buscarProducto()
        {
            try
            {
                if (comboBox2.Text == "") { conexion.inform("Seleccione un metodo de busqueda."); }
                else
                {
                    string texto = text.Text;
                    string colu = comboBox2.Text;
                    string query = "SELECT idproducto,nombredeproducto,marca FROM inventario WHERE " + colu + " LIKE '%" + texto + "%';";
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
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            buscarProducto();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDatos();

        }

        public void getDatos()
        {
            try
            {
                nm.Text = dataGridView1.CurrentRow.Cells["nombredeproducto"].Value.ToString() + " "+dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                conexion.abrir();
                DataTable dt = new DataTable();
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString());
                //MessageBox.Show(id.ToString());
                string consulta = "select * from inventario where idproducto = '" + dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    while (lector.Read())
                    {
                        textBox1.Text = lector["medida"].ToString()+" "+lector["unidaddemedida"].ToString();
                        label3.Text = lector["unidaddemedida"].ToString();
                    }
                }
            }
            catch (Exception ex) {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                
                conexion.cerrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString());
                //MessageBox.Show(id.ToString());
                string consulta = "select * from inventario where idproducto = '" + dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector22;
                lector22 = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                
                Boolean hayRegistros = lector22.HasRows;
                if (hayRegistros)
                {
                    while (lector22.Read())
                    {
                        // cantidadexistente = float.Parse(lector22["medida"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        cantidadexistente = lector22["medida"].ToString();
                    }

                    //float aquitar = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                    String aquitar = textBox2.Text;
                    System.Console.WriteLine(cantidadexistente);
                    System.Console.WriteLine(aquitar);
                    //Double cantidadResultante;
                    cantidadResultante = (double.Parse(cantidadexistente, CultureInfo.InvariantCulture) - double.Parse(aquitar, CultureInfo.InvariantCulture));
                     // textBox3.Text = textBox3.Text.Replace(',','.');
                    System.Console.WriteLine(cantidadResultante.ToString().Replace(',','.'));
                    restante = cantidadResultante.ToString().Replace(',', '.');
                    //System.Console.WriteLine("=" +(double.Parse(cantidadexistente, CultureInfo.InvariantCulture)- double.Parse(aquitar, CultureInfo.InvariantCulture)));
                    if (double.Parse(aquitar, CultureInfo.InvariantCulture) > double.Parse(cantidadexistente, CultureInfo.InvariantCulture)) { MessageBox.Show("No tienes Productos Suficientes"); }
                    else
                    {                       
                        string um = " " + label3.Text;
                        if (MessageBox.Show("En inventario tienes " + cantidadexistente + um + ", se sacarán " + aquitar + um + ". Quedará un total de " + restante + um + " disponible. Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            procesar();

                        }
                    }
                }
            }
            catch (Exception ex) {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void procesar()
        {
                try
                {
               // MessageBox.Show("existente: "+ cantidadexistente.ToString());
               // MessageBox.Show("resultante: " + restante.ToString());
                string id = dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString();
                conexion.cerrar();
                    conexion.abrir();
                    string query = "update inventario set medida = '"+restante+"' where idproducto = '"+id+"'";
                    SqlCommand comando = new SqlCommand(query, conexion.ver());
                    comando.ExecuteNonQuery();
                    conexion.cerrar();
                    report();
                }
                catch (Exception ex)
                {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
                finally
                {
                    conexion.cerrar();
                }          

        }

        public void report()
        {
            try
            {
                string nombre = dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString();
                string acc = "Se han sacado "+textBox2.Text+" "+label3.Text;
                conexion.abrir();
                string hor = DateTime.Now.ToString("h:mm:ss tt");
                string query = "insert into reporteinventario(producto,fecha,hora,accion)values('"+nm.Text+"','"+dateTimePicker1.Text+"','"+hor+"','"+acc+"')";
                SqlCommand comando = new SqlCommand(query, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty,ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
