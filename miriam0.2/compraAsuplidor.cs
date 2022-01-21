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
    public partial class compraAsuplidor : Form
    {
        log log = new log();
        cnn conexion = new cnn();
        string usuario;
        string tipo;
        string currentUm = "Unidad de Medida";

        public compraAsuplidor(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void compraAsuplidor_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Compra a suplidor cargado.");
            generar();
            verificarID();
            loadCategories();
            updateUm();
        }

        public void generar()
        {
            Random rd = new Random();
            int numero = rd.Next(111111, 999999); 
            idventayfac.Text = numero.ToString();
            
        }

        private void loadCategories()
        {
            DataTable table = conexion.getTable("units", string.Empty);
            txtunidaddemedida.DataSource = table;
            txtunidaddemedida.DisplayMember = "nombre";
            txtunidaddemedida.Text = "";
        }

        public void verificarID()
        {
            try
            {
                conexion.cerrar();
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from compras where idcompra = '" + idventayfac.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();

                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    generar();
                }
                else
                {

                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtidsuplidor_TextChanged(object sender, EventArgs e)
        {
            getSupli();
        }
        public void getSupli()
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from suplidores where idsuplidor = '" + txtidsuplidor.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    txtidsuplidor.BackColor = Color.Green;
                    //conexion.Open();
                    while (lector.Read())
                    {
                        txtnombresuplidor.Text = lector["nombre"].ToString() + " (" + lector["tipo"].ToString()+")";
                    }

                }
                else
                {
                    txtidsuplidor.BackColor = Color.Red;
                    txtnombresuplidor.Text = "[Cliente no idenificado]";
                }
                if (txtidsuplidor.Text == "")
                {
                    txtidsuplidor.BackColor = Color.White; txtnombresuplidor.Text = "__________________";
                }
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtidsuplidor.Text= conexion.selector("suplidores","idsuplidor");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            getSupli();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultarSuplidor cs = new consultarSuplidor(usuario);
            cs.Show();
        }

        private void txtunidaddemedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateUm();
        }

        private void updateUm()
        {
            currentUm = txtunidaddemedida.Text;
            label6.Text = "Cantidad de "+currentUm;
            label7.Text = "Precio de compra por "+currentUm;
            label5.Text = "Precio de venta por "+currentUm;
        }
    }
}
