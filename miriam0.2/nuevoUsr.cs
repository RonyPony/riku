using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

using riku;

namespace miriam0._2
{
    
    public partial class nuevoUsr : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;


        public nuevoUsr(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            loginValidate();
        }

        public void loginValidate()
        {
            string pass1 = textBox6.Text;
            string pass2 = textBox9.Text;
            if (pass1 == pass2 && pass1 != "")
            {
                if (textBox5.Text != "")
                {
                    pictureBox1.Visible = true;
                    pictureBox7.Visible = false;
                }
                else {
                    pictureBox1.Visible = false;
                    pictureBox7.Visible = true;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                pictureBox7.Visible = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            loginValidate();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            loginValidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void enviar() {

            try {
                string nombre = textBox1.Text;
                string apellido = textBox2.Text;
                string correo = textBox3.Text;
                string tipo = comboBox4.Text;
                string celular = textBox4.Text;
                string diaFechaNacimiento = comboBox1.Text;
                string mesFechaNacimiento = comboBox2.Text;
                string yearFechaNacimiento = comboBox3.Text;
                string fecha = diaFechaNacimiento + "-" + mesFechaNacimiento + "-" + yearFechaNacimiento;
                string sexo = comboBox8.Text;
                string usuario = textBox5.Text;
                string clave = textBox6.Text;
                string comentario = listBox1.Text;
                conexion.abrir();
                string consulta = "INSERT INTO usuarios (usuario,clave,tipo,nombre,apellidos,correo,telefono,fechadenacimiento,sexo,comentario)" +
                    "VALUES" +
                    "('" + usuario + "','" + clave + "','" + tipo + "','" + nombre + "','" + apellido + "','" + correo + "','" + celular + "','" + fecha + "','"+sexo+"','" + comentario + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.inform("Usuario agregado");
                conexion.cerrar();
            }
            catch (Exception ex) {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally {
                conexion.cerrar();
            }

            /*
             * [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [usuario] VARCHAR(50) NULL, 
    [clave] VARCHAR(50) NULL, 
    [tipo] VARCHAR(50) NULL, 
    [nombre] VARCHAR(50) NULL, 
    [apellidos] VARCHAR(50) NULL, 
    [correo] VARCHAR(50) NULL, 
    [telefono] VARCHAR(50) NULL, 
    [fechadenacimiento] VARCHAR(50) NULL, 
    [sexo] VARCHAR(50) NULL, 
    [comentario] TEXT NULL
)
*/

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            enviar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enviar();
        }

        private void nuevoUsr_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Agregar nuevo usuario cargado.");
        }
    }
}
