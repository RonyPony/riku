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
    public partial class addUnit : Form
    {
        cnn conexion = new cnn();
        string usuario;

        public addUnit(string usua)
        {
            InitializeComponent();
            usuario = usua;
        }

        private void addUnit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string desc = textBox2.Text;
            string table = "units";
            string fields = "nombre,descripcion,createdby";
            string ux = conexion.getIdUsuario(usuario);
            string values = "'"+nombre+"','"+desc+"','"+ux+"'";
            conexion.save(table,fields,values);
            conexion.inform("Guardado con exito");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
