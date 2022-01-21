using riku;
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
    public partial class facturaNo : Form
    {
        string usuario;
        string tipo;
        log log = new log();
        cnn conexion = new cnn();

        public facturaNo(string uusuario)
        {
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                FacturaViewer bb = new FacturaViewer(usuario, textBox1.Text);
                bb.Show();
            }
        }

        private void facturaNo_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario,"Consulta factura cargado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacturaViewer ll = new FacturaViewer(usuario,textBox1.Text);
            ll.imprimir();
        }
    }
}
