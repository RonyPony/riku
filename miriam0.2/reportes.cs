using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using riku;

namespace miriam0._2
{
    public partial class reporteInventario : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string rutaReportes = @"C:\RikuFiles\Reportes\";
        string usuario;
        string tipo;

        public reporteInventario(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
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
            if (ventas.Checked) { log.crearReporte(dateTimePicker1.Text, ventas.Text); }
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
            catch (Exception ex)
            {
                if (MessageBox.Show("ERROR cargando los reportes, quiere ver detalles del error?","Ups!",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes) { MessageBox.Show(ex.ToString()); }
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
            if (conexion.yesnoDialog("¿Estas seguro?, Se eliminara de forma permanente el reporte del "+lista.Text+""))
            {
                log.eliminar(rutaReportes+lista.Text);
                cargarReportes();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new inventario(usuario));
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new verusuarios(usuario));
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
            abrir(new inventario(usuario));
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new consultarVentasDiaria(usuario));
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new agregarVentaDeldia(usuario));
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new agregarActividad(usuario));
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new consultarActividades(usuario));
        }

        public void abrir(Form d)
        {
            d.MdiParent = this.ParentForm;
            d.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrir(new consultarVentas(usuario));
        }

        [Obsolete]
        private void button5_Click(object sender, EventArgs e)
        {
            HtmlToText ht = new HtmlToText();
            var plainText = ht.Convert(rutaReportes + lista.SelectedItem.ToString());
            imprimirReporte(plainText);
        }

        private string limpiar(string html)
        {
            string[] notAllowed = {
                //color: blue; border-collapse: collapse;width: 80%;hrborder: 10px 
                //solid blue;.grad background-image: linear-gradient(to left, rgba(255, 0, 0, 0),
                //    rgba(255, 0, 0, 1));tr:nth-child(even) background-image: linear-gradient
                //(-90deg, pink, yellow);th, td padding: 8px;text-align: left;border-bottom: 1px solid #ddd;
                "<",
                ">",
                "html",
                "title",
                "/",
                "style",
                "h2",
                "head",
                "{",
                "}",
                "table",
                "color",
                "border-collapse:","color: blue;","blue",";","width","collapse","background","%","80","gradient","grad","image","linear","(","" +
                ")","px","solid","center","hr","th","tr","strong","td"
            };
            string r = html;
            string nada = "";
            foreach (var item in notAllowed)
            {
                r = r.Replace(item, nada);
            }

            return r;
        }

        public void imprimirReporte(string data)
        {
            FacturaViewer fv = new FacturaViewer(usuario,"0");
            string businessName = riku.Properties.Settings.Default.receiptName;
            string footercustom = riku.Properties.Settings.Default.customReceiptFooter;
            string company = fv.StringLimit(businessName, 32, true);
            string nombreReporte = fv.StringLimit(lista.SelectedItem.ToString(), 32, true);
            string receiptString = "==================================\n" +
                                   "|" + company + "|\n" +
                                   "==================================\n" +
                                   "                                  \n" +
                                   "                                  \n" +
                                   "----------------------------------\n" +
                                   "REPORTE " + nombreReporte + " \n" +
                                   "----------------------------------\n" +
                                   "                                  \n" +
                                   ""+data+"\n" +
                                   "                                  \n";

            string footer =        "----------------------------------\n" +
                                   "                                  \n";

            string customFooter = "----------------------------------\n " +
                                  "Solicitado por:  " + fv.getUser() + "\n \n \n" + footercustom;


           

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(receiptString+footer+customFooter, new Font("OCR A Extended", 10), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                if (true)
                {
                    p.Print();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
    }
}
