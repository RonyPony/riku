using riku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class calculadora : Form
    {
        log log = new log();
        string usuario;
        string tipo;
        cnn conexion = new cnn();

        public calculadora(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
        }

        double a;
        double b;
        string c;

        private void calculadora_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Calculadora cargada.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "1";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "2";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "3";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "4";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "5";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "6";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "7";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "8";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "9";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtpantalla2.Text == "")
            {
                txtpantalla2.Text = "0";
            }
            else
            {
                txtpantalla2.Text = txtpantalla2.Text + "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.txtpantalla2.Text);
            c = "/";
            this.txtpantalla2.Clear();
            this.txtpantalla2.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.txtpantalla2.Text);
            c = "*";
            this.txtpantalla2.Clear();
            this.txtpantalla2.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.txtpantalla2.Text);
            c = "-";
            this.txtpantalla2.Clear();
            this.txtpantalla2.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.txtpantalla2.Text);
            c = "+";
            this.txtpantalla2.Clear();
            this.txtpantalla2.Focus();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (this.txtpantalla2.Text.Contains('.') == false)
            {
                this.txtpantalla2.Text = this.txtpantalla2.Text + ",";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToDouble(this.txtpantalla2.Text);
                switch (c)
                {
                    case "+":
                        this.txtpantalla2.Text = Convert.ToString(b + a);
                        break;

                    case "-":
                        this.txtpantalla2.Text = Convert.ToString(b - a);
                        break;

                    case "*":
                        this.txtpantalla2.Text = Convert.ToString(b * a);
                        break;

                    case "/":
                        this.txtpantalla2.Text = Convert.ToString(b / a);
                        break;
                }
            }
            catch (Exception oo) {
                if (conexion.yesnoDialog("Error en el calculo, ¿Quiere ver detalles del error?"))
                {
                    MessageBox.Show(oo.ToString());
                }
            }


        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
            string ruta = "\\archivo.txt";
                if (File.Exists(ruta)) {
                    //MessageBox.Show("Existe");
                    StreamWriter WriteReportFile = File.AppendText(ruta);
                    WriteReportFile.WriteLine(a + c + b + "=" + this.txtpantalla2.Text);
                    WriteReportFile.Close();
                }
                else
                {
                    //MessageBox.Show("No Existe");
                    StreamWriter Archivo = new StreamWriter(ruta);
                    Archivo.WriteLine("Registro de Operaciones Realizadas en la Super Calculadora");        
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(ruta);
                    div.WriteLine("------------------------------------------------------------------");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(ruta);
                    WriteReportFile.WriteLine(a + c + b + "=" + this.txtpantalla2.Text);
                    WriteReportFile.Close();
                }
              
                //System.Diagnostics.Process.Start("\\archivo.txt");
                //SendToPrinter();
                if (conexion.yesnoDialog("Calculo exportado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    AbrirSaved(ruta);
                }
            } catch (Exception ex) {
                //MessageBox.Show(pp.ToString());
                errorManager ho = new errorManager(string.Empty,ex);
                ho.Show();
            }
        }

        void AbrirSaved(string file)
        {
            if (File.Exists(file))
            {
                System.Diagnostics.Process.Start(file);
            }
            else
            {
             //   var filename = "ServiceLog.txt";
             //   using (File.Create(filename)) ;
             //   AbrirLogs();
            }
        }

        private void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
            info.FileName = @"C:\Firmador\1.pdf";         // Ruta hacia el fichero que quieres imprimir
            info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
            info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta

            Process p = new Process();
            p.StartInfo = info;
            p.Start();  // Lanza el proceso

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);          // Espera 3 segundos
            if (false == p.CloseMainWindow())
                p.Kill();                                  // Y cierra el programa de imprimir PDF's
        }
        private void button18_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            this.txtpantalla2.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
