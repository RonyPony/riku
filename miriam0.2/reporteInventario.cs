using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class reporteInventario : Form
    {
        log log = new log();
        string rutaReportes = @"C:\RikuFiles\Reportes\";
        string usuario;
        string tipo;

        public reporteInventario(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            if (cinventario.Checked) { log.crearReporte(date, "inventario"); }
            if (cusuario.Checked) { log.crearReporte(date, "usuarios"); }
            if (finventario.Checked) { log.crearReporte(dateTimePicker2.Text, "flujo de inventario"); }
            if (ventadiariaesp.Checked) { log.crearReporte(dateventadiariaespecifica.Text,"venta diaria esp"); }
            if (vdt.Checked) { log.crearReporte(dateTimePicker1.Text, "venta diaria total"); }
            if (act.Checked) { log.crearReporte(dateTimePicker1.Text, "actividades"); }
            if (acte.Checked) { log.cearreporteACTE(dateTimePicker1.Text,txtacte.Text); }
            cargarReportes();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Abrir(rutaReportes+lista.Text);
        }

        public void cargarReportes()
        {
            try
            {
                string rutaReportes = @"C:\RikuFiles\Reportes\";
                if (Directory.Exists(rutaReportes))
                {
                    DirectoryInfo dinfo = new DirectoryInfo(rutaReportes);
                    FileInfo[] Files = dinfo.GetFiles("*.html");
                    lista.Items.Clear();
                    int total = Files.Count();
                    if (total==0)
                    {
                        lista.Items.Add("Aún no se han generado reportes");
                        return;
                    }
                    foreach (FileInfo file in Files)
                    {
                        lista.Items.Add(file.Name);
                    }
                }
                else
                {
                    Directory.CreateDirectory(rutaReportes);
                    cargarReportes();
                }
                
            }
            catch (Exception x)
            {
                if (MessageBox.Show("ERROR cargando los reportes, quiere ver detalles del error?","Ups!",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes) { MessageBox.Show(x.ToString()); }
            }
        }

        private void reporteInventario_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Administrador de reportes cargado.");
            cargarReportes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Abrir(rutaReportes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro?, Se eliminara de forma permanente el reporte del "+lista.Text+"", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.eliminar(rutaReportes+lista.Text);
                cargarReportes();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            inventario ii = new inventario(usuario,tipo);
            ii.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verusuarios vv = new verusuarios(usuario,tipo);
            vv.Show();
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            log.Abrir(rutaReportes + lista.Text);
        }

        private void lista_Enter(object sender, EventArgs e)
        {
           
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            inventario ii = new inventario(usuario,tipo);
            ii.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarVentasDiaria cc = new consultarVentasDiaria(usuario,tipo);
            cc.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarVentaDeldia dd = new agregarVentaDeldia(usuario,tipo);
            dd.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarActividad ac = new agregarActividad(usuario,tipo);
            ac.Show();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarActividades ca = new consultarActividades(usuario,tipo);
            ca.Show();
        }
    }
}
