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
    public partial class agregarActividad : Form
    {
        log log = new log();
        cnn conexion = new cnn();
        string usuario;
        string tipo;

        public agregarActividad(string uusuario)
        {
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtaccion.Text!="" && txtflujo.Text!="" && txttipo.Text!="" && txtfecha.Text!="")
            {
                enviar();
            }
            else
            {
                conexion.inform("Primero ingrese todos los datos.");
            }
        }

        public void enviar()
        {

            try
            {
                
                string accion = txtaccion.Text;
                string flujo = txtflujo.Text;
                string tipox = txttipo.Text;
                string fecha = txtfecha.Text;

                conexion.abrir();
                string consulta = "INSERT INTO actividades (accion,flujoefectivo,tipo,fecha)" +
                    "VALUES" +
                    "('" + accion + "','" + flujo + "','" + tipox + "','" + fecha + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                conexion.inform("Actividad Guardada.");
                limpiar();
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

        public void limpiar()
        {
            txtfecha.Text = "";
            txtflujo.Text = "";
            txtaccion.Text = "";
            txttipo.Text = "";
        }

        private void agregarActividad_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar Actividad [" + usuario + "]";
            log.notificacion(usuario,"Agregar Actividad ha sido cargado");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarActividades ca = new consultarActividades(usuario);
            ca.Show();
        }
    }
}
