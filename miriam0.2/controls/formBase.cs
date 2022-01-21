using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku.controls
{
    public partial class formBase : Form
    {
        public formBase()
        {
            InitializeComponent();
        }

        public string titulazo
        {
            get {return titulo.Text; }
            set {titulo.Text = value; }
        }

        public Image logo
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public Color color
        {
            get { return barraPrincipal.BackColor; }
            set { barraPrincipal.BackColor = value; }
        }


        private void formBase_Load(object sender, EventArgs e)
        {
            
        }
    }
}
