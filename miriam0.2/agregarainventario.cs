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
    public partial class agregarainventario : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string generaluser;
        string tipo;

        public agregarainventario(string usuario)
        {
            InitializeComponent();
            generaluser = usuario;
            tipo = conexion.getTipo(usuario);
            this.Text = "Agregar Productos [" + generaluser + "]";
        }

        private void agregarainventario_Load(object sender, EventArgs e)
        {
            log.notificacion(generaluser, "Agregar a inventario cargado.");
            cargarCombos();
        }

        public void cargarCombos()
        {
            DataTable table = conexion.getTable("units", string.Empty);
            txtunidaddemedida.DataSource = table;
            txtunidaddemedida.DisplayMember = "nombre";
            txtunidaddemedida.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtunidaddemedida_SelectedValueChanged(object sender, EventArgs e)
        {
            labels();
            
        }

        public void labels()
        {
            string um = txtunidaddemedida.Text;
            if (txtunidaddemedida.Text == "Otra...")
            {
                txtotramedida.Enabled = true;
                um = txtotramedida.Text;
            }
            else
            {
                txtotramedida.Enabled = false;
            }
            label6.Text = "Cantidad de " + um + " compradas";
            label4.Text = "Precio de compra por " + um;
            label5.Text = "Precio de venta por " + um;
        }

        public void enviar()
        {

            try
            {
                string idsuplidor = txtidsupli.Text;
                string nombre = txtnombre.Text;
                string marca = txtmarca.Text;
                string unidaddemedida;
                if (txtunidaddemedida.Text == "Otra...") { unidaddemedida = txtotramedida.Text; } else
                {
                    unidaddemedida= txtunidaddemedida.Text;
                }
                string cantidad = txtcantidad.Text;
                string preciocompra = txtpreciocompra.Text;
                string precioventa = txtprecioventa.Text;
                string preciounitario = txtpreciounitario.Text;
                string descripcion = txtdescripcion.Text;
                
                conexion.abrir();
                string consulta = "INSERT INTO inventario (idsuplidor,nombredeproducto,marca,medida,preciocomprapormedida,precioventapormedida,precioventa,descripcion,unidaddemedida,fechadecompra)" +
                    "VALUES" +
                    "('"+idsuplidor+ "','" + nombre + "','" + marca + "','" + cantidad + "','" + preciocompra + "','" + precioventa + "','"+preciounitario+"','" + descripcion + "','" + unidaddemedida + "','"+fecha.Value+"')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
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


        private void txtunidaddemedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkmas.Checked == true)
            {
                //txtidsupli.ReadOnly = true;
                enviar();
                report();
                conexion.inform("Producto (" + txtnombre.Text + ") agregado con exito.");
                limpiar();
                

            }
            else {
                enviar();
                report();
                conexion.inform("Producto (" + txtnombre.Text + ") agregado con exito.");
                //this.Close();
            }
            
        }

        public void report()
        {
            try
            {
                string um;
                if (txtunidaddemedida.Text == "Otra...") { um = txtotramedida.Text; } else { um = txtunidaddemedida.Text; }
                string acc = "Se han agregado "+txtcantidad.Text+" "+um+" de " + txtnombre.Text + " " + txtmarca.Text;
                conexion.abrir();
                string hor = DateTime.Now.ToString("h:mm:ss tt");
                string query = "insert into reporteinventario(producto,fecha,hora,accion)values('" + txtnombre.Text+" "+txtmarca.Text + "','" + dateTimePicker1.Text + "','"+hor+"','" + acc + "')";
                SqlCommand comando = new SqlCommand(query, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
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

    
        public void limpiar() {
            txtidsupli.Clear();
            txtcantidad.Clear();
            txtdescripcion.Clear();
            txtmarca.Clear();
            txtnombre.Clear();
            txtotramedida.Clear();
            txtpreciocompra.Clear();
            txtprecioventa.Clear();
            txtunidaddemedida.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtidsupli.Text = conexion.selector("suplidores", "Idsuplidor");
            //consultarSuplidor cs = new consultarSuplidor(generaluser,tipo);
            //cs.MdiParent = this.ParentForm;
            //cs.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            inventario ii = new inventario(generaluser);
            ii.MdiParent = this.ParentForm;
            ii.Show();

        }

        private void txtidsupli_TextChanged(object sender, EventArgs e)
        {
            getSuplidor();
        }

        public void getSuplidor()
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from suplidores where idsuplidor = '" + txtidsupli.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    txtidsupli.BackColor = Color.Green;
                    //conexion.Open();
                    while (lector.Read())
                    {
                        //conexion.Close();

                        lbsupli.Text = lector["nombre"].ToString().ToUpper();                        
                        //buscarporsuplidor();
                        //MessageBox.Show(lector["nombre"].ToString());                        
                    }
                }
                else
                {
                    txtidsupli.BackColor = Color.Red;
                    lbsupli.Text = "[Incorrecto]";
                }
                if (txtidsupli.Text == "")
                {
                    txtidsupli.BackColor = Color.White; lbsupli.Text = "______________________________________________";
                }
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void txtotramedida_TextChanged(object sender, EventArgs e)
        {
            labels();
        }
    }
}
