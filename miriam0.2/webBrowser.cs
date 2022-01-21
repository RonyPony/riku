using miriam0._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku
{
    public partial class webBrowser : Form
    {
        string user;
        log log = new log();
        public webBrowser(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void buscar()
        {
            web.Navigate(url.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string home = riku.Properties.Settings.Default.webhomepage;
            url.Text = home;
            buscar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            web.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            web.GoForward();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            web.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            web.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            url.Text = "http://google.com";
            buscar();
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser_Load(object sender, EventArgs e)
        {
            log.notificacion(user, "Navegador cargado.");
            string home = riku.Properties.Settings.Default.webhomepage;
            url.Text = home;
            buscar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
