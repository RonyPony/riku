using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class suplidoresdecidir : Form
    {
        string usuario;
        string tipo;

        public suplidoresdecidir(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
            this.Text = "Suplidores ["+usuario+"]";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarSuplidor ass = new agregarSuplidor(usuario);
            ass.MdiParent = this.ParentForm;
            ass.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            consultarSuplidor cs = new consultarSuplidor(usuario);
            cs.MdiParent = this.ParentForm;
            cs.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarSuplidor cs = new consultarSuplidor(usuario);
            cs.MdiParent = this.ParentForm;
            cs.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            agregarSuplidor ass = new agregarSuplidor(usuario);
            ass.MdiParent = this.ParentForm;
            ass.Show();
            this.Close();
        }

        private void suplidoresdecidir_Load(object sender, EventArgs e)
        {

        }
    }
}
