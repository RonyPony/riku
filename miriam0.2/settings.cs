using miriam0._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku
{
    public partial class settings : Form
    {
        cnn conexion = new cnn();
        string user;
        bool isAdmin;
        bool isLogedIn;

        public settings(string userr)
        {
            InitializeComponent();
            user = userr;
            if (user != null)
            {
                isAdmin = conexion.isAdmin(user);
                isLogedIn = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            updatePic();
        }

        public void updatePic()
        {
            if (Colorblanco.Checked)
            {
                whitePic.Visible = true;
                bluePic.Visible = false;
                redPic.Visible = false;
                def.Visible = false;
            }
            if (colorAzul.Checked)
            {
                whitePic.Visible = false;
                bluePic.Visible = true;
                redPic.Visible = false;
                def.Visible = false;
            }
            if (colorRojo.Checked)
            {
                whitePic.Visible = false;
                bluePic.Visible = false;
                redPic.Visible = true;
                def.Visible = false;
            }
            if (defectoSelect.Checked)
            {
                whitePic.Visible = false;
                bluePic.Visible = false;
                redPic.Visible = false;
                def.Visible = true;
            }
        }

        private void colorAzul_CheckedChanged(object sender, EventArgs e)
        {
            updatePic();
        }

        private void colorRojo_CheckedChanged(object sender, EventArgs e)
        {
            updatePic();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            updatePic();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            getData();
        }

        public void updatesInfo()
        {
            updater actualizador = new updater();
            DateTime lastUpdateRequest = actualizador.getLastUpdateRequest();
            double localVersion = actualizador.localVersion;
            double currentVersion = actualizador.currentVersion;

            txtLocalVersion.Text = "Version Actual : " + localVersion;
            txtUltimaVersion.Text = "Ultima Version : " + currentVersion;
            txtupdateHeader.Text = "La  ultima consulta de actualizacion fue el \n\r " + lastUpdateRequest;
        }
        public void getData()
        {
            string color = riku.Properties.Settings.Default.color;
            string name = riku.Properties.Settings.Default.loadingName;
            string frase = riku.Properties.Settings.Default.loadingPhr;
            string ScreenMode = riku.Properties.Settings.Default.startMode;
            string homeweb = riku.Properties.Settings.Default.webhomepage;
            string instance = riku.Properties.Settings.Default.instance;//.Replace("////","//");
            string database = riku.Properties.Settings.Default.database;
            string dbuser = riku.Properties.Settings.Default.dbUser;
            string dbpass = riku.Properties.Settings.Default.dbPass;
            bool integratedSecurity = riku.Properties.Settings.Default.integratedSecurity;
            int ConnectTimeout = riku.Properties.Settings.Default.ConnectTimeout;
            bool Encrypt = riku.Properties.Settings.Default.Encrypt;
            bool TrustServerCertificate = riku.Properties.Settings.Default.TrustServerCertificate;
            string ApplicationIntent = riku.Properties.Settings.Default.ApplicationIntent;
            bool MultiSubnetFailover = riku.Properties.Settings.Default.MultiSubnetFailover;
            bool rikuNetworkActive = riku.Properties.Settings.Default.rikuNetworkSyncActive;
            int rikuNetworkBussinessCode = riku.Properties.Settings.Default.rikuNetworkBussinessCode;
            string rikuNetworkPass = riku.Properties.Settings.Default.rikuNetworkPassword;

            //riku network
            txtrikunetworkactive.Checked = rikuNetworkActive;
            txtrikunetworkbussinnescode.Text = rikuNetworkBussinessCode.ToString();
            txtrikunetworkpass.Text = rikuNetworkPass;

            //string browserpage = riku.Properties.Settings.Default;
            txtinstancia.Text = instance;
            txtbasededatos.Text = database;
            txtdbuser.Text = dbuser;
            txtdbpass.Text = dbpass;
            txtintegratedsecurity.Checked = integratedSecurity;
            txttimeout.Text = ConnectTimeout.ToString();
            txtencrypt.Checked = Encrypt;
            txttrustservercertificate.Checked = TrustServerCertificate;
            txtapplicationintent.Text = ApplicationIntent;
            txtmultisubnetfailover.Checked = MultiSubnetFailover;

            //facturas
            string facturaname = riku.Properties.Settings.Default.receiptName;
            string customeReceiptFooter = riku.Properties.Settings.Default.customReceiptFooter;

            txtfactura.Text = facturaname;
            txtfacturafooter.Text = customeReceiptFooter;

            //inicializacion

            if (isAdmin || isLogedIn)
            {
                DataTable table = conexion.getTable("modulos", string.Empty);
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "name";
                string kk;
                try
                {
                    kk = conexion.getModuloById(conexion.getTable("usuarios", "id=" + conexion.getIdUsuario(user)).Rows[0][11].ToString());

                }
                catch (Exception)
                {
                    kk = "Ninguna";
                }
                comboBox1.Text = kk;
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "Primero inicie sesion...";
                comboBox1.Enabled = false;
            }



            //updates
            updatesInfo();

            countDGII();
            if (name.Length < 6)
            {
                txtName.Text = name;
            }
            else
            {
                txtName.Text = "RIKU";
            }
            if (frase.Length < 20)
            {
                txtFrase.Text = frase;
            }
            else
            {
                txtFrase.Text = "Version Empresarial";
            }
            if (homeweb.Length > 1)
            {
                txtinitialwebpage.Text = homeweb;
            }
            else
            {
                txtinitialwebpage.Text = "http://ronycruz.myartsonline.com/riku";
            }
            //color
            switch (color)
            {
                case "rojo":
                    colorRojo.Checked = true;
                    colorAzul.Checked = false;
                    Colorblanco.Checked = false;
                    defectoSelect.Checked = false;
                    updatePic();
                    break;
                case "azul":
                    colorRojo.Checked = false;
                    colorAzul.Checked = true;
                    Colorblanco.Checked = false;
                    defectoSelect.Checked = false;
                    updatePic();
                    break;

                case "blanco":
                    colorRojo.Checked = false;
                    colorAzul.Checked = false;
                    Colorblanco.Checked = true;
                    defectoSelect.Checked = false;
                    updatePic();
                    break;
                default:
                    colorRojo.Checked = false;
                    colorAzul.Checked = false;
                    Colorblanco.Checked = false;
                    defectoSelect.Checked = true;
                    updatePic();
                    break;
            }
            switch (ScreenMode)
            {
                case "Maximizada":
                    cbxInitialScreenMode.Text = "Maximizada";
                    break;
                case "Normal":
                    cbxInitialScreenMode.Text = "Normal";
                    break;
                default:
                    cbxInitialScreenMode.Text = "Maximizada";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Si ha realizado cambios sin guardar, estos se perderan, Cerrar?", "Cerrar",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            //{
            this.Close();
            //}
        }

        public void countDGII()
        {
            label19.Text = conexion.getCount("contribuyentes", string.Empty) + " Contribuyentes registrados";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                riku.Properties.Settings.Default.Save();
                conexion.inform("Configuracion Guardada");
            }
        }

        public Boolean Save()
        {
            try
            {
                string uzuario = null;
                string tmpUsr = null;
                tmpUsr = conexion.getIdUsuario(user);
                if (tmpUsr == null)
                {
                    conexion.inform("Solo se guardara la configuracion del servidor, debe iniciar sesion para poder guardar el resto de informacion de configuracion");
                    riku.Properties.Settings.Default.instance = txtinstancia.Text;
                    riku.Properties.Settings.Default.database = txtbasededatos.Text;
                    riku.Properties.Settings.Default.integratedSecurity = txtintegratedsecurity.Checked;
                    riku.Properties.Settings.Default.ConnectTimeout = Convert.ToInt32(txttimeout.Text);
                    riku.Properties.Settings.Default.Encrypt = txtencrypt.Checked;
                    riku.Properties.Settings.Default.TrustServerCertificate = txttrustservercertificate.Checked;
                    riku.Properties.Settings.Default.ApplicationIntent = txtapplicationintent.Text;
                    riku.Properties.Settings.Default.MultiSubnetFailover = txtmultisubnetfailover.Checked;
                    riku.Properties.Settings.Default.dbUser = txtdbuser.Text;
                    riku.Properties.Settings.Default.dbPass = txtdbpass.Text;
                    riku.Properties.Settings.Default.Save();
                    return false;
                }
                else
                {
                    uzuario = tmpUsr;
                }

                if (cbxInitialScreenMode.Text == "Normal" || cbxInitialScreenMode.Text == "Minimizada" || cbxInitialScreenMode.Text == "Maximizada")
                {
                    riku.Properties.Settings.Default.startMode = cbxInitialScreenMode.Text;
                }
                if (Colorblanco.Checked)
                {
                    riku.Properties.Settings.Default.color = "blanco";
                }
                if (colorAzul.Checked)
                {
                    riku.Properties.Settings.Default.color = "azul";
                }
                if (colorRojo.Checked)
                {
                    riku.Properties.Settings.Default.color = "rojo";
                }
                if (defectoSelect.Checked)
                {
                    riku.Properties.Settings.Default.color = "Default";
                }
                if (txtName.Text.Length < 6)
                {
                    riku.Properties.Settings.Default.loadingName = txtName.Text;
                }
                else
                {
                    txtName.BackColor = Color.Red;
                    txtName.ForeColor = Color.White;
                    conexion.inform("El titulo no puede pasar de 6 caracteres");
                    return false;
                }
                if (txtFrase.Text.Length < 20)
                {
                    riku.Properties.Settings.Default.loadingPhr = txtFrase.Text;
                }
                else
                {
                    txtFrase.BackColor = Color.Red;
                    txtFrase.ForeColor = Color.White;
                    conexion.inform("El subtituo no puede pasar de 20 caracteres");
                    return false;
                }
                if (txtinitialwebpage.Text.Length > 1)
                {
                    riku.Properties.Settings.Default.webhomepage = txtinitialwebpage.Text;
                }

                riku.Properties.Settings.Default.instance = txtinstancia.Text;
                riku.Properties.Settings.Default.database = txtbasededatos.Text;
                riku.Properties.Settings.Default.integratedSecurity = txtintegratedsecurity.Checked;
                riku.Properties.Settings.Default.ConnectTimeout = Convert.ToInt32(txttimeout.Text);
                riku.Properties.Settings.Default.Encrypt = txtencrypt.Checked;
                riku.Properties.Settings.Default.TrustServerCertificate = txttrustservercertificate.Checked;
                riku.Properties.Settings.Default.ApplicationIntent = txtapplicationintent.Text;
                riku.Properties.Settings.Default.MultiSubnetFailover = txtmultisubnetfailover.Checked;
                riku.Properties.Settings.Default.dbUser = txtdbuser.Text;
                riku.Properties.Settings.Default.dbPass = txtdbpass.Text;
                riku.Properties.Settings.Default.rikuNetworkBussinessCode = Convert.ToInt32(txtrikunetworkbussinnescode.Text);
                riku.Properties.Settings.Default.rikuNetworkPassword = txtrikunetworkpass.Text;
                riku.Properties.Settings.Default.rikuNetworkSyncActive = txtrikunetworkactive.Checked;
                

                riku.Properties.Settings.Default.receiptName = txtfactura.Text;
                riku.Properties.Settings.Default.customReceiptFooter = txtfacturafooter.Text;

                string nuevoModulo = conexion.getModuleIdByname(comboBox1.Text);
                if (comboBox1.Text == "Ninguna" || comboBox1.Text == "")
                {
                    nuevoModulo = "0";
                }
               
                conexion.update("usuarios", "moduloInicial = " + nuevoModulo, " Id=" + uzuario);

                return true;
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
                return false;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splash sp = new splash(true);
            sp.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            darInfo("initialWindow");
        }

        public void darInfo(string info)
        {
            string msj = "";
            string titulo = "";
            switch (info)
            {
                case "initialWindow":
                    msj = "Permite establecer en que modo quieres que inicie el formulario de incio de sesion, puede ser modo normal o modo maximizado";
                    titulo = "Pantalla completa, o ventana normal?";
                    break;
                case "initialForm":
                    msj = "permite abrir un formulario luego de completarse el proceso de inicializacion e identificacion del usuario";
                    titulo = "formulario inicial";
                    break;
                case "titulo":
                    msj = "Aqui puedes escribir el titulo que se mostrara en la pantalla de carga";
                    titulo = "Titulo de carga";
                    break;
                default:
                    break;
            }
            if (msj != "" && titulo != "")
            {
                conexion.inform(titulo.ToUpper() + " --- " + msj.ToUpper());
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            darInfo("initialForm");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            darInfo("titulo");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //darInfo();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = "Buscando ...";
            updater gg = new updater();
            conexion.inform(gg.procesar("buscar"));
            updater go = new updater();
            go.setLastUpdateRequest(DateTime.Now);

            updatesInfo();

            updater a = new updater();
            double localVersion = a.localVersion;
            double currentVersion = a.currentVersion;

            if (currentVersion > localVersion)
            {
                btnDownload.Enabled = true;
                btnDownload.Text = "Descargar V" + currentVersion;
            }
            button5.Text = "Buscar Actualizaciones";
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        public void btnDownload_Click(object sender, EventArgs e)
        {
            txtupdateHeader.Text = "Estamos descargando el nuevo programa, \r\n esto tardara unos minutos dependeindo de \r\n tu velocidad de internet, te avisaremos \r\n al terminar, solo dame unos minutos.";
            btnDownload.Text = "Descargando ...";
            updater gg = new updater();
            conexion.inform(gg.procesar("descargar"));
            btnDownload.Text = "Descargar";
            btnDownload.Enabled = false;
            updatesInfo();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetItem(textBox2.Text);
        }

        private static void GetItem(string id)
        {
            var url = $"http://173.249.49.169:88/api/test/consulta/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label19.Text = "Conectandonos con la DGII, esto tardara unos minutos";
            process.RunWorkerAsync();

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (conexion.checkInter())
                {
                    //this.button6.Text = "Descargando...";
                    updater internet = new updater();
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    string str2 = "https://dgii.gov.do/app/WebApps/Consultas/RNC/DGII_RNC.zip";
                    string targetRoute = System.IO.Directory.GetCurrentDirectory() + "\\Contribuyentes\\";
                    string filename = "data.zip";
                    if (internet.descargar(str2, targetRoute, filename))
                    {
                        //button6.Text = "Extrayendo...";
                        ZipFile.ExtractToDirectory(targetRoute + filename, targetRoute);
                        string[] lines = System.IO.File.ReadAllLines(targetRoute + "\\TMP\\DGII_RNC.txt");

                        string campos = "rnc,nombre,descripcion,fecha,estado,condicion";
                        int i = 0;
                        int total = 0;
                        int inserts = 10;

                        if (conexion.yesnoDialog("Se encontro un total de " + lines.Length + " contribuyentes en la DGII que seran agregados a la base de datos, esto tardara bastante, podras cerrar la ventana de configuracion, pero no podras salir de RIKU... quiere continuar?"))
                        {
                            CheckForIllegalCrossThreadCalls = false;
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = lines.Length;
                            CheckForIllegalCrossThreadCalls = true;

                            conexion.borrarTabla("contribuyentes");
                            //button6.Text = "Insertando en la base de datos...";
                            string values = "";
                            foreach (var item in lines)
                            {
                                string[] datax = item.Split('|');

                                if (datax.Length != 11)
                                {
                                    string ms = "No se pudo agregar a " + datax[0].ToString();
                                    //MessageBox.Show(ms);
                                    log log = new log();
                                    log.notificacion(user, ms);
                                }
                                else
                                {
                                    values = values + "('" + datax[0].ToString() + "','" + datax[1].Replace("'","") + "','" + datax[3] + "','" + datax[8] + "','" + datax[9] + "','" + datax[10] + "'),";
                                    //List<string> listaTextoP = values.Split(new[] { "(" },
                                    //    StringSplitOptions.RemoveEmptyEntries).ToList();
                                    i++;
                                    Console.WriteLine("i: " + i + "/" + lines.Length + "    | TOTAL INSERTADO " + total);
                                    //inform("i: " + i + "/" + lines.Length + "    | TOTAL INSERTADO " + total);
                                }


                                if (i == inserts)
                                {
                                    Console.WriteLine("Insertando " + inserts);

                                    if (conexion.saveMultiple("contribuyentes", campos, values.Remove(values.Length - 1)))
                                    {
                                        values = "";
                                        total = total + i;
                                        inform("INSERTANDO " + total + " de " + lines.Length, total);
                                        i = 0;
                                        Console.WriteLine("________________");
                                        //inform("__________________________________________________");
                                    }
                                    else
                                    {
                                        break;
                                    }


                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ff)
            {
                MessageBox.Show(ff.Message);
                //conexion.showError(ff);
            }
            finally
            {
                File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\Contribuyentes\\TMP\\DGII_RNC.txt");
                File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\Contribuyentes\\data.zip");
                Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\Contribuyentes\\TMP");
                Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\Contribuyentes");
                button6.Text = "Actualizar Base de datos de contribuyentes";

                //countDGII();
            }
        }

        public void inform(string data, int percent)
        {

            CheckForIllegalCrossThreadCalls = false;
            progressBar1.Value = percent;
            label19.Text = data;
            CheckForIllegalCrossThreadCalls = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //countDGII();
            //progressBar1.Value =e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logview gg = new logview();
            gg.Show();
        }

        private void savedgii_DoWork(object sender, DoWorkEventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        #region Print a sample receipt
        async void PrintReceipt_Click()
        {

            string receiptString = "=====================================\n" +
                                   "|   Sample Header                   |\n" +
                                   "=====================================\n" +
                                   "Item                            Price\n" +
                                   "-------------------------------------\n" +
                                   "Books                           10.40\n" +
                                   "Games                            9.60\n" +
                                   "-------------------------------------\n" +
                                   "Total                           20.00\n";

            //rootPage.NotifyUser("Printing receipt...", NotifyType.StatusMessage);

            //// The job consists of two receipts, one for the merchant and one
            //// for the customer.
            //ReceiptPrintJob job = rootPage.ClaimedPrinter.Receipt.CreateJob();
            //PrintLineFeedAndCutPaper(job, receiptString + GetMerchantFooter());
            //PrintLineFeedAndCutPaper(job, receiptString + GetCustomerFooter());

            //await ExecuteJobAndReportResultAsync(job);
        }

        string GetMerchantFooter()
        {
            return "\n" +
                   "______________________\n" +
                   "Signature\n" +
                   "\n" +
                   "Merchant Copy\n";
        }

        string GetCustomerFooter()
        {
            return "\n" +
                   "Customer Copy\n";
        }

        // Cut the paper after printing enough blank lines to clear the paper cutter.
        //private void PrintLineFeedAndCutPaper(ReceiptPrintJob job, string receipt)
        //{
        //    // Passing a multi-line string to the Print method results in
        //    // smoother paper feeding than sending multiple single-line strings
        //    // to PrintLine.
        //    string feedString = "";
        //    for (uint n = 0; n < rootPage.ClaimedPrinter.Receipt.LinesToPaperCut; n++)
        //    {
        //        feedString += "\n";
        //    }
        //    job.Print(receipt + feedString);
        //    if (rootPage.Printer.Capabilities.Receipt.CanCutPaper)
        //    {
        //        job.CutPaper();
        //    }
        //}
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
