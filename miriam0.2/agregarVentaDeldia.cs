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
    public partial class agregarVentaDeldia : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;

        public agregarVentaDeldia(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
            this.Text = "Registrar Venta del Dia [" + uusuario + "]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (dateTimePicker1.Text=="" || textBox2.Text=="")
            {
                conexion.inform("Datos Incompletos. Debe seleccionar una fecha e ingresar un valor de dinero a registrar");
            }
            else
            {
                try
                {
                    enviar();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(cc.ToString());
                    conexion.showError(ex);
                }
            }
        }

        public void enviar()
        {

            try
            {
                string fecha = dateTimePicker1.Text;
                string dinero = textBox2.Text;
                conexion.abrir();
                string consulta = "INSERT INTO ventasDiarias (fecha,dinero)" +
                    "VALUES" +
                    "('" + fecha + "','" + dinero + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                conexion.inform("Venta Guardada.");
                limpiar();
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

        public void limpiar()
        {
            dateTimePicker1.Text = "";
            textBox2.Text = "";
        }

        private void agregarVentaDeldia_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario,"Agregar venta del dia ha sido cargado");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarVentasDiaria ccc = new consultarVentasDiaria(usuario);
            ccc.Show();
        }
    }
}
