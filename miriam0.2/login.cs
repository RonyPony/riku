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

using System.IO;
using riku;
using System.Runtime.InteropServices;
//using MySql.Data.MySqlClient;

namespace miriam0._2
{
    
    public partial class Form1 : Form
    {
        cnn data = new cnn();
        windowsControl ventana = new windowsControl();
        Color mainColor = Color.Cyan;
        Color secondColor = Color.Red;
        Color fontColor = Color.HotPink;

        cnn conexion = new cnn();
        string usr;
        string pass;
        Boolean offlinemode;
        log log = new log();
        int storeId;

        public Form1(bool online,int storeid)
        {
            storeId = storeid;

            if (!online)
            {
                this.offlinemode = true;
            }
            else
            {
                this.offlinemode = false;
            }
            InitializeComponent();
        }
        
        public void checkMode()
        {
            if (offlinemode)
            {
                string d = "fuera de linea";
                txt.Text = d.ToUpper();
            }
            else
            {
                string d = "en linea";
                txt.Text = d.ToUpper();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        

        public void verificar() {
            if (data.login(textBox1.Text,textBox2.Text))
            {
                //MessageBox.Show("Bienvenido al sistema " + textBox1.Text);
                homeMDI hm = new homeMDI(textBox1.Text);
                hm.Show();
                log.notificacion(textBox1.Text, "Se ha iniciado sesion como [" + textBox1.Text + "]");
                
                this.Close();
            }
            else
            {
                conexion.inform("Usuario o contraseña incorrecta");
                log.notificacion(textBox1.Text, "Usuario o contraseña incorrecta");
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            home many = new home("Programador!",false,90);
          //  many.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        public void salir()
        {
            if (conexion.yesnoDialog("Estas seguro que desea salir?"))
            {
                Application.Exit();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validation
            if (textBox1.Text!="" && textBox2.Text!="")
            {
                if (conexion.probar())
                {
                    button1.Text = "[Por favor, espere...]";
                    pantalla.Enabled = false;
                    login.Start();
                }
                else
                {
                    Exception ex = new Exception("No hemos podido conectar con el servidor, asegurate de que has configurado correctamente la conexion, ve a OPCIONES > SERVIDOR para modificarla.");
                    errorManager error = new errorManager("info", ex);
                    error.Show();
                }
            }
            else
            {
                Exception ex = new Exception("Debe ingresar el usuario y la contraseña para poder iniciar sesion");
                errorManager error = new errorManager("info",ex);
                error.Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ventana.Maximizar(this);
            checkMode();
            getSetting();
            log.notificacion("[[No se requiere usuario]]", "Login cargado.");
            getUsers();
            textBox1.Focus();
        }

        public void getUsers()
        {

            if (conexion.probar())
            {
                DataTable table = data.getTable("usuarios", string.Empty);
                textBox1.DataSource = table;
                textBox1.DisplayMember = "usuario";
                textBox1.Text = "";
            }
            
        }

        public void getSetting()
        {
            string color = riku.Properties.Settings.Default.color;
            string name = riku.Properties.Settings.Default.loadingName;
            string frase = riku.Properties.Settings.Default.loadingPhr;
            string startMode = riku.Properties.Settings.Default.startMode;
            if (name.Length < 6)
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
                    mainColor = Color.Red;
                    secondColor = Color.DarkRed;
                    fontColor = Color.White;
                    this.BackColor = Color.Red;
                    this.barraPrincipal.BackColor = Color.DarkRed;
                    this.titulo.ForeColor = Color.White;
                    this.ForeColor = Color.White;
                    this.pantalla.BackColor = Color.Red;
                    this.pantalla.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    appName.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    groupBox1.BackColor = Color.Red;
                    groupBox1.ForeColor= Color.White;
                    button1.ForeColor = Color.Black;
                    button2.ForeColor = Color.Black;
                    servidor.LinkColor = Color.White;
                    txt.LinkColor = Color.White;
                    opciones.LinkColor = Color.White;
                    
                    break;
                case "azul":
                    this.BackColor = Color.Blue;
                    this.barraPrincipal.BackColor = Color.MediumAquamarine;
                    this.ForeColor = Color.White;
                    this.pantalla.BackColor = Color.Blue;
                    this.pantalla.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    appName.ForeColor = Color.White;
                    appPhr.ForeColor = Color.White;
                    groupBox1.BackColor = Color.Blue;
                    groupBox1.ForeColor = Color.White;
                    button1.ForeColor = Color.Black;
                    button2.ForeColor = Color.Black;
                    txt.LinkColor = Color.White;
                    servidor.LinkColor = Color.White;
                    opciones.LinkColor = Color.White;
                    break;

                case "blanco":
                    this.BackColor = Color.White;
                    this.barraPrincipal.BackColor = Color.DarkGray;
                    this.titulo.ForeColor = Color.White;
                    this.ForeColor = Color.Black;
                    this.pantalla.BackColor = Color.White;
                    this.pantalla.ForeColor = Color.Black;
                    appPhr.ForeColor = Color.Black;
                    appName.ForeColor = Color.Black;
                    appPhr.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
            switch (startMode)
            {
                case "Maximizada":
                    ventana.Maximizar(this);
                    break;
                case "Normal":
                    ventana.normalizar(this);
                    break;
                case "Minimizada":
                    //ventana.Minimizar(this);
                    break;
                default:
                    //ventana.Maximizar(this);
                    break;
            }
        }

        public void checkServer()
        {
            if (conexion.probar())
            {
                servidor.Text = "Conectado";
            }
            else
            {
                servidor.Text = "Desconectado";
            }
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            nuevoUsr nu = new nuevoUsr("Hacker","Administrador");
            nu.Show(); 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool status;
                onlineCnn conexion = new onlineCnn();
                string query = "insert into solicitudes (idemisor,idreceptor,estado)values('1','2','3')";
              //  MySqlCommand comando = new MySqlCommand(query, conexion.ver());
              //  MySqlDataReader MyReader2;
                conexion.abrir();
             //   MyReader2 = comando.ExecuteReader();
              //  while (MyReader2.Read())
                {

                }
                status = true;
            }

        private void txt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            onlineCnn conexion = new onlineCnn();
            string msj;
            if (conexion.checkInter(storeId))
            {
                msj = "Si estas conectado a internet";
            }
            else
            {
                msj = "No estas conectado a internet";
            }
            data.inform(msj);
        }

        private void servidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            servidor.Text = "[Espere...]";
            pantalla.Enabled = false;
            server.Start();            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            server.Stop();            
            checkServer();
            pantalla.Enabled = true;

        }

        private void login_Tick(object sender, EventArgs e)
        {
            login.Stop();
            
            verificar();
            pantalla.Enabled = true;
            button1.Text = "Volver a intentar";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            if (e.KeyChar == 13)
            {
                button1.Text = "[Por favor, espere...]";
                pantalla.Enabled = false;
                login.Start();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Text = "[Por favor, espere...]";
                pantalla.Enabled = false;
                login.Start();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Text = "[Por favor, espere...]";
                pantalla.Enabled = false;
                login.Start();
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            
        }

        private void appName_Click(object sender, EventArgs e)
        {
           
        }

        private void appName_DoubleClick(object sender, EventArgs e)
        {
            settings mm = new settings(usr);
            mm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ventana.Minimizar(this);
        }

        private void ventana_btn_max_Click(object sender, EventArgs e)
        {
            ventana.Maximizar(this);
        }

        private void ventana_btn_normal_Click(object sender, EventArgs e)
        {
            ventana.normalizar(this);
        }

        private void barraPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ventana.mover(this);
        }

        private void appPhr_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            settings ff = new settings(usr);
            ff.Show();
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            
        }

        private void ventana_btn_min_Click(object sender, EventArgs e)
        {
            ventana.Minimizar(this);
            ventana_btn_max.Visible = true;
            ventana_btn_min.Visible = false;
        }

        private void ventana_btn_max_Click_1(object sender, EventArgs e)
        {
            ventana.Maximizar(this);
            ventana_btn_max.Visible = false;
            ventana_btn_min.Visible = true;
        }

        private void ventana_btn_cerrar_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void ventana_btn_normal_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void barraPrincipal_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_ImeModeChanged(object sender, EventArgs e)
        {
            
        }

        private void barraPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    /*

conexion.abrir();
MessageBox.Show(conexion.licenceCheck("x").ToString());
conexion.cerrar();
*/
}
    

