using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
//using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using riku;
using System.Reflection;
using System.Diagnostics;

namespace miriam0._2
{
    public partial class splash : Form
    {
        onlineCnn internet = new onlineCnn();
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////
        /// </summary>
        int XstoreIdX = 707;
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        bool conectadoAinternet = false;
        bool licenciaVerificada = false;
        Boolean testing = false;


        public splash(bool mode)
        {
            testing = mode;
            InitializeComponent();
            pantalla.Items.Add("Inicializando el verificador.");
            getSetting();
        }
        public splash()
        {
            InitializeComponent();
            pantalla.Items.Add("Inicializando el verificador.");
            getSetting();
        }

        public void getSetting()
        {
            string color = riku.Properties.Settings.Default.color;
            string name = riku.Properties.Settings.Default.loadingName;
            string frase = riku.Properties.Settings.Default.loadingPhr;
            if (name.Length<6)
            {
                appName.Text = name;
            }
            else
            {
                appName.Text = "RIKU";
            }
            if (frase.Length < 20)
            {
                appPhr.Text = frase;
            }
            else
            {
                appPhr.Text = "Version Empresarial";
            }
            //color
            switch (color)
            {
                case "rojo":
                    this.BackColor = Color.Red;
                    this.ForeColor = Color.White;
                    this.pantalla.BackColor = Color.Red;
                    this.pantalla.ForeColor = Color.White;
                    label3.ForeColor = Color.White;
                    appName.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    label5.ForeColor = Color.White;
                    break;
                case "azul":
                    this.BackColor = Color.Blue;
                    this.ForeColor = Color.White;
                    this.pantalla.BackColor = Color.Blue;
                    this.pantalla.ForeColor = Color.White;
                    label3.ForeColor = Color.White;
                    appName.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    label5.ForeColor = Color.White;
                break;

                case "blanco":
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                    this.pantalla.BackColor = Color.White;
                    this.pantalla.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    appName.ForeColor = Color.Black;
                    appPhr.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
        }

       



        private void Form1_Load(object sender, EventArgs e)
        {
            //internet.abrir();
            timer1.Start();            
            log l = new log();
            l.instalar();
            l.notificacion("[[[No se requiere usuario]]]", "Splash cargado.");
            updater h = new updater();
            //desabilitado para usar actualizador de windows
            //label6.Text = "V"+h.localVersion.ToString().Replace(",",".");
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            label6.Text = "V "+version;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 30) {
                timer1.Stop();
                pantalla.Items.Add("Verificando la conexion a internet");
                if (internet.checkInter(XstoreIdX))
                {
                    pantalla.Items.Add("Conexion establecida");
                    conectadoAinternet = true;
                } else {
                    pantalla.Items.Add("Conexion no establecida");
                }
                timer1.Start();
            }
            //conectadoAinternet
                if (progressBar1.Value == 50)
            {
                pantalla.Items.Add("Verificando actualizaciones...");
                timer1.Stop();
                
                if (conectadoAinternet)
                {
                    updater ac = new updater();

                    //string updated = ac.procesar("buscar");
                    //pantalla.Items.Add(updated);

                    pantalla.Items.Add("Busqueda suspendida, usaremos otro metodo de actualizacion.");

                    //comentado para usar actualizador de windows 

                    //if (updated!= "-- TIENES LA VERSION MAS ACTUALIZADA --" && updated!= "Ups, ha pasado algo inesperado en el proceso de actualizacion.")
                    //{
                    //    if (MessageBox.Show("Hay una actualizacion nueva, quienes descargarla ahora ?", "Nueva Version", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //    {
                    //        riku.settings f = new riku.settings();
                    //        f.Show();
                    //        f.tabControl1.SelectedTab = f.tabPage7;
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                    timer1.Start();

                    //licenciaVerificada = true;
                }
                else
                {
                    pantalla.Items.Add("No pudimos buscar actualizaciones");
                    timer1.Start();
                }
            }
            if (progressBar1.Value == 60)
            {
                string instance = riku.Properties.Settings.Default.instance;
                if (instance == "NoData")
                {
                    riku.Properties.Settings.Default.instance = System.Environment.MachineName+@"\"+"SQLEXPRESS";
                    riku.Properties.Settings.Default.Save();
                }
            }
            /*if (progressBar1.Value == 50)
            {
                timer1.Stop();
                pantalla.Items.Add("verificando la licencia de uso");
                if (internet.licenceCheck()=="1")
                {
                    pantalla.Items.Add("Licencia Aceptada");
                    timer1.Start();
                    licenciaVerificada = true;
                } else
                {
                    pantalla.Items.Add("Licencia Rechazada");
                    timer1.Stop();
                    
                    if (MessageBox.Show(internet.getExpiredLicenceReason(), "Licencia no Valida", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        progressBar1.Value = 0;
                        timer1.Start();
                        pantalla.Items.Clear();
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
            }
            */

            int valor = progressBar1.Value;
            if (valor == 100) {
                timer1.Stop();
                label3.Text = "100";
                this.Hide();
                if (conectadoAinternet)
                {
                    Form1 lg = new Form1(true, XstoreIdX);
                    if (!testing)
                    {
                        lg.Show();
                    }
                    this.Hide();
                }
                else
                {
                    //if (MessageBox.Show("No se ha completado la verificacion de licencia y conexion a internet, desea acceder en modo offline", "Sin Conexiones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                        Form1 lg = new Form1(false, XstoreIdX);
                        if (!testing)
                        {
                            lg.Show();
                        }                        
                    //}
                }
            } else
            {
                progressBar1.Value = valor + 1;
                string valorTxt = Convert.ToString(valor);
                label3.Text = valorTxt+"%";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!testing)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg,int wparam, int lparam);
        private void splash_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void appName_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void appPhr_Click(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pantalla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar2_Load(object sender, EventArgs e)
        {

        }
    }
}
