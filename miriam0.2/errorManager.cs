
using miriam0._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku
{
    public partial class errorManager : Form
    {
        string mensaje;
        string detalle;
        string tipo;
        Exception pro;
        cnn conexion = new cnn();

        public bool respuesta { get; set; }

        public errorManager(string type, Exception problema)
        {
            //string msj = getError(problema.Message);

            string msj = problema.Message;

            mensaje = msj;
            string detalles = problema.ToString();
            detalle = detalles;
            pro = problema;
            tipo = type;
            InitializeComponent();
        }

        public string getError(string err)
        {
            miriam0._2.log kk = new miriam0._2.log();
            string[] lines = System.IO.File.ReadAllLines(kk.rutaErrors + kk.fileError);
            int i = 0;
            foreach (string item in lines)
            {
                if (item == err)
                {
                    return lines[i];
                }
                else
                {
                    i++;
                }
            }
            return err;
        }

        private void errorManager_Load(object sender, EventArgs e)
        {
            getSettings();
            richTextBox1.Text = mensaje;
            button1.Focus();
            designType();
        }

        public void setColor(Color co)
        {
            panel1.BackColor = co;
            button1.BackColor = co;
            button2.BackColor = co;
        }

        public void designType()
        {
            switch (tipo)
            {
                case "info":
                    label1.Text = "Informacion";
                    button2.Hide();
                    button1.Text = "Entendido";
                    pictureBox2.Visible = true;
                    setColor(Color.BlueViolet);
                    //pictureBox1.Hide();
                    //System.Drawing.Point lo = new Point(23, 74);
                    //richTextBox1.Location = lo;
                    //System.Drawing.Size size = new Size(577, 129);
                    //richTextBox1.Size = size;

                    //System.Drawing.Size tama = new Size(612, 247);
                    //this.Size = tama;
                    break;
                case "yesno":
                    label1.Text = "Pregunta";
                    //button2.Hide();
                    button1.Text = "Si";
                    button2.Text = "No";
                    pictureBox3.Visible = true;
                    setColor(Color.Green);
                    this.TopMost = true;
                    //pictureBox1.Hide();
                    //System.Drawing.Point lo = new Point(23, 74);
                    //richTextBox1.Location = lo;
                    //System.Drawing.Size size = new Size(577, 129);
                    //richTextBox1.Size = size;

                    //System.Drawing.Size tama = new Size(612, 247);
                    //this.Size = tama;
                    break;
                default:
                    label1.Text = "Ups, esto es un error.";
                    button1.Text = "OK";
                    button2.Text = "Ver Detalles";
                    setColor(Color.Red);
                    break;
            }
        }



        public void getSettings()
        {
            string color = riku.Properties.Settings.Default.color;
            switch (color)
            {
                case "rojo":
                    panel1.BackColor = Color.DarkRed;
                    button1.BackColor = Color.DarkRed;
                    button2.BackColor = Color.DarkRed;
                    button1.ForeColor = Color.White;
                    button2.ForeColor = Color.White;
                    break;
                case "azul":
                    panel1.BackColor = Color.DarkBlue;
                    button1.BackColor = Color.DarkBlue;
                    button2.BackColor = Color.DarkBlue;
                    break;

                case "blanco":
                    panel1.BackColor = Color.Gray;
                    button1.BackColor = Color.Gray;
                    button2.BackColor = Color.Gray;
                    label1.ForeColor = Color.Black;
                    button1.ForeColor = Color.Black;
                    button2.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "info":

                    break;
                case "yesno":
                    respuesta = false;
                    break;
                default:
                    MessageBox.Show(pro.ToString());
                    break;
            }
            this.Close();
            //MessageBox.Show(pro.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "info":

                    break;
                case "yesno":
                    respuesta = true;
                    break;
                default:

                    break;
            }

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
