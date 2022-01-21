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
using System.Reflection;
using System.Diagnostics;

namespace miriam0._2
{
    public partial class home : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        public string usuario;
        string tipo;
        Boolean offlinemode;
        int storeId;

        public home(string uusuario,bool online,int storeid)
        {
            storeId = storeid;
            InitializeComponent();
            offlinemode = !online;
            usuario = uusuario;
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea salir?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 login = new Form1(!offlinemode,storeId);
            login.Show();
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admUsuarios admu = new admUsuarios(usuario);
            admu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admUsuarios admu = new admUsuarios(usuario);
            admu.MdiParent = this.ParentForm;
            admu.Show();
        }

        private void cuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            facturar ft = new facturar(usuario);
            ft.Show();
        }

        private void cuentasPorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compraASuplidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compraAsuplidor cs = new compraAsuplidor(usuario,tipo);
            cs.Show();
        }

        private void nuevoSuplidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarSuplidor ags = new agregarSuplidor(usuario);
            ags.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {
            
            this.Focus();
            getDatos();            
            log.notificacion(usuario,"Panel principal cargado");
            getSettings();
            //setLimites();
            timerhora.Start();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string Xversion = fileVersionInfo.ProductVersion;
            //char[] array = Xversion.Take(5).ToArray();
            version.Text = Xversion.Substring(0,3);
        }
        public void getSettings()
        {
            version.Text = riku.Properties.Settings.Default.localVersion.ToString().Replace(",",".");
        }

        

        //public void setLimites()
        //{
        //    tipo = tipo.ToLower();
        //    if (tipo == "administrador")
        //    {
        //        msj.Text = "Tu tipo de cuenta es de administrador, por lo que el sistema le concede acceso a toda informacion y poder para modificarla permanentemente.";
        //    }else if (tipo == "empleado corriente")
        //    {
        //        msj.Text = "Tu tipo de cuenta es de empleado corriente, por lo que el sistema le concede acceso limitado a ciertas funciones del sistema.";
        //        btnfacturar.Enabled = false;
        //        btnadmusuario.Enabled = false;
        //        btncompra.Enabled = false;
        //        nuevoUsuarioToolStripMenuItem.Enabled = false;
        //        eliminarUsuarioToolStripMenuItem.Enabled = false;
        //        eliminarUsuarioToolStripMenuItem1.Enabled = false;
        //        cuentasPorPagarToolStripMenuItem.Enabled = false;
        //    }

        //}

        public void getDatos()
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from usuarios where usuario = '" + usuario + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    //conexion.Open();
                    while (lector.Read())
                    {
                        //conexion.Close();
                        tipo = lector["tipo"].ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }


        }


        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoUsr ns = new nuevoUsr(usuario,tipo);
            ns.Show();
        }

        private void eliminarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            facturar factura = new facturar(usuario);
            factura.Show();
        }

        private void generadorDeNumerosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void resetearToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inventario invv = new inventario(usuario);
            invv.MdiParent = this.ParentForm;
            invv.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            suplidoresdecidir sd = new suplidoresdecidir(usuario,tipo);
            sd.MdiParent = this.ParentForm;
            sd.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarSuplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarSuplidor cs = new consultarSuplidor(usuario);
            cs.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calculadora c = new calculadora(usuario);
            c.MdiParent = this.ParentForm;
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conversor cc = new conversor(usuario);
            cc.MdiParent = this.ParentForm;
            cc.Show();
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarCliente ccc = new consultarCliente(usuario);
            ccc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clientesDecidir ccccc = new clientesDecidir(usuario,tipo);
            ccccc.MdiParent = this.ParentForm;
            ccccc.Show();
        }

        private void reporteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteInventario rr = new reporteInventario(usuario);
            rr.Show();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarCliente aaa = new agregarCliente(usuario);
            aaa.Show();
        }

        private void lOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logview ll = new logview();
            ll.Show();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarVentas cv = new consultarVentas(usuario);
            cv.Show();
        }

        private void generadorDeNumerosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generadorDeNumerosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            facturaNo g = new facturaNo(usuario);
            g.Show();
        }

        private void administradorDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteInventario ri = new reporteInventario(usuario);
            ri.Show();
        }

        private void sistemaDeDepuracionInternaSDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Sistema de depuracion interna (SDI) cargado");
            logview ll = new logview();
            ll.Show();
        }

        private void registrarVentaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarVentaDeldia vv = new agregarVentaDeldia(usuario);
            vv.Show();
        }

        private void consultarVentasDiariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarVentasDiaria cc = new consultarVentasDiaria(usuario);
            cc.Show();
        }

        private void home_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                facturar factura = new facturar(usuario);
                factura.Show();
            }
            if (e.KeyCode == Keys.F2)
            {
                inventario invv = new inventario(usuario);
                invv.Show();
            }
            if (e.KeyCode == Keys.F3)
            {
                admUsuarios admu = new admUsuarios(usuario);
                admu.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("enter");
            }
        }

        private void timerhora_Tick(object sender, EventArgs e)
        {

        }

        private void btncompra_Click(object sender, EventArgs e)
        {
            compraAsuplidor cs = new compraAsuplidor(usuario,tipo);
            cs.MdiParent = this.ParentForm;
            cs.Show();

        }

        private void registrarVentaDelDiaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void registrarUnaActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void resgistrarVentaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarVentasDiariasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            consultarVentasDiaria cvd = new consultarVentasDiaria(usuario);
            cvd.Show();
        }

        private void registrarVentaDelDiaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            agregarVentaDeldia vdd = new agregarVentaDeldia(usuario);
            vdd.Show();
        }

        private void consultarVentasDiariasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            consultarVentasDiaria cvd = new consultarVentasDiaria(usuario);
            cvd.Show();
        }

        private void registrarUnaActividadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            agregarActividad aa = new agregarActividad(usuario);
            aa.Show();
        }

        private void consultarActividadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            consultarActividades ca = new consultarActividades(usuario);
            ca.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conexion.yesnoDialog("Estas seguro que desea salir?"))
            {
                Application.Exit();
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Abrir("http://ronycruz.myartsonline.com/riku");
        }

        private void conversorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conversor cc = new conversor(usuario);
            cc.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculadora vv = new calculadora(usuario);
            vv.Show();
        }

        private void navegadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tipox = tipo.ToLower();

            if (tipox == "administrador")
            {
                
            }
            else
            {
                MessageBox.Show("Esta herramienta esta disponible solo para Adminstradores","Solo Para Administradores",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buscar();
        }

        public void buscar()
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //web.ScriptErrorsSuppressed = true;
            //url.Text = web.Url.ToString();
            try
            {
            //   // MessageBox.Show(web.Tag.ToString());
            //   // MessageBox.Show(web.TabIndex.ToString());
            //    //MessageBox.Show(web.StatusText.ToString());
            //    //MessageBox.Show(web.Site.ToString());
            //   // MessageBox.Show(web.ReadyState.ToString());
            //   // MessageBox.Show(web.ProductName.ToString());
            //    if (web.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        loadingpack.Visible = false;
            //    }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(b.ToString());
                errorManager rr = new errorManager(string.Empty,ex);
                rr.Show();
            }
        }
        private void web_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //if (button10.BackColor == Color.Gray)
            //{
            //    navegador.Left = 1007;
            //    navegador.Width = 351;
            //    web.Width = 343;
            //    web.Height = 578;
            //    button10.BackColor = Color.LightGray;
            //}
            //else
            //{
            //    navegador.Left = 0;
            //    navegador.Width = 1300;
            //    web.Width = 1380;
            //    web.Height = 567;
            //    button10.BackColor = Color.Gray;
            //}
        }

        private void url_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("Left Web = "+web.Left.ToString()+ " right Web = " + web.Right.ToString() + " Heigh Web = " + web.Height.ToString());
            // MessageBox.Show("Left navegador = " + navegador.Left.ToString() + " right navegador = " + navegador.Right.ToString() + " Heigh navegador = " + navegador.Height.ToString());
           // MessageBox.Show("web WxH " + web.Width+" x "+web.Height);
           // MessageBox.Show("Nav WxH "+navegador.Width+" x "+navegador.Height);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //web.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string home = "http://ronycruz.myartsonline.com/riku";
            //url.Text = home;
            //buscar();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //web.GoBack();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //web.GoForward();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //web.Stop();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //navegador.Visible = false;
        }

        private void web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //loadingpack.Visible = true;
            
        }

        private void generadorDeNumerosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            generador g = new generador();
            g.Show();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings sets = new settings(usuario);
            sets.Show();
        }

        private void url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                buscar();
            }
        }

        private void botonMenu1_Click(object sender, EventArgs e)
        {
            facturar factura = new facturar(usuario);
            factura.Show();
        }

        private void botonMenu1_Click_1(object sender, EventArgs e)
        {

        }

        private void botonMenu1_Click_2(object sender, EventArgs e)
        {
            inventario invv = new inventario(usuario);
            invv.Show();
        }

        private void botonMenu1_Click_3(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            facturar factura = new facturar(usuario);
            factura.MdiParent = this.ParentForm;
            factura.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
