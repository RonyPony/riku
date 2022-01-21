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
using riku;

namespace miriam0._2
{
    public partial class admUsuarios : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;
        List<string> informacion;

        public admUsuarios(string pusuario)
        {
            InitializeComponent();
            grid();
            usuario = pusuario;
            tipo = conexion.getTipo(usuario);
        }

        private void admUsuarios_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Administrador de usuarios cargado.");
            this.Text = "Administrador de usuarios ["+usuario+"]";
        }

        public void obtenerId()
        {
            conexion.abrir();
            string comando = "SELECT MAX(idusuario)";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid();
        }

        public void grid() {
            try
            {
                conexion.abrir();
                string comando = "select * from usuarios";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            loginValidate();
        }

        public void enviar()
        {

            try
            {
                string nombre = txt_nombre.Text;
                string apellido = txt_apellidos.Text;
                string correo = txtcorreo.Text;
                string tipo = txttipo.Text;
                string fecha = txtfecha.Text;
                string sexo = txtsexo.Text;
                string xusuario = txt_usuario.Text;
                string clave = txtcontrase.Text;
                string telefono = txttelefono.Text;
                string comentario = txtcomentario.Text;
                conexion.abrir();
                string consulta = "INSERT INTO usuarios (usuario,clave,tipo,nombre,apellidos,correo,telefono,fechadenacimiento,sexo,comentario)" +
                    "VALUES" +
                    "('" + xusuario + "','" + clave + "','" + tipo + "','" + nombre + "','" + apellido + "','" + correo + "','" + telefono + "','" + fecha + "','" + sexo + "','" + comentario + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                log.notificacion(usuario,"Se ha agregado un nuevo usuario ("+xusuario+"["+tipo+"]"+")");
                conexion.inform("Usuario agregado.");
                //this.Close();
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }
        }
            public void loginValidate()
        {
            string pass1 = txtcontrase.Text;
            string pass2 = txtcontrase2.Text;

            if (pass1 == pass2 && pass1 != "")
            {
                if (txt_nombre.Text != "" && txt_usuario.Text != "" && txtcontrase.Text != "" && txt_apellidos.Text != "" && txtcontrase2.Text != "" && txtcomentario.Text != "")
                {
                    error.Text = "Enviando Datos...";
                    enviar();
                }
                else {
                    error.Text = "Complete todos los campos del formulario.";
                }
            }
            else
            {
                error.Text = "Las contraseñas no coinciden.";
                txtcontrase.Text = "";
                txtcontrase2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void getUsuario()
        {
            try
            {
                conexion.cerrar();
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from usuarios where usuario = '" + txt_usuario.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    txt_usuario.BackColor = Color.Red;
                    //txt_usuario.Text = "";
                    error.Text = "Este usuario ya esta en uso";
                    button4.Enabled = false;
                }
                else
                {
                    txt_usuario.BackColor = Color.Green;
                    error.Text = "____________________________________________________________";
                    button4.Enabled = true;
                }
                if (txt_usuario.Text == "")
                {
                    txt_nombre.BackColor = Color.White; error.Text = "____________________________________________________________";
                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }

        }

        public void getdelete()
        {
            try
            {
                conexion.cerrar();
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from usuarios where idusurio = '" + txtidusuario.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    txtidusuario.BackColor = Color.Green;
                    aeliminar.Text = lector["usuario"].ToString().ToUpper();
                }
                else
                {
                    txtidusuario.BackColor = Color.Red;
                    aeliminar.Text = "[-]";
                }
                if (txt_usuario.Text == "")
                {
                    txt_nombre.BackColor = Color.White; error.Text = "____________________________________________________________";
                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            getUsuario();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> username = conexion.getUserInfo(txtidusuario.Text);
                if (username != null)
                {
                    if (conexion.yesnoDialog("Estas seguro que desea eliminar a " + username[1]))
                    {
                        conexion.abrir();
                        DataTable dt = new DataTable();
                        string consulta = "delete from usuarios where id = '" + txtidusuario.Text + "';";
                        SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                        comando.ExecuteNonQuery();
                        conexion.inform("Usuario Elimindo");

                        log.notificacion(usuario, "Se ha eliminado un usuario (usuario eliminado:" + aeliminar.Text + ")");
                        txtidusuario.Text = "";
                    }
                    
                }
                else
                {
                    conexion.showError(new Exception("No se puede eliminar un usuario si no ingresas un ID correcto."));
                }
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verusuarios vu = new verusuarios(usuario);
            vu.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtidusuario.Text = conexion.selector("usuarios", "id");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aeliminar_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txtidusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcomentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontrase2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_apellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontrase_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void error_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtsexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtfecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txttelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txttipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        public void cargarInfoEditar()
        {
            try
            {
                string id = conexion.selector("usuarios", "id");
                label19.Text = id;
                if (label19.Text == "")
                {
                    label19.Text = "[Seleccione un usuario]";
                }
                if (id != null)
                {
                    informacion = conexion.getUserInfo(id);

                    txtusernameupdate.Text = informacion[1];
                    //txtpasswordupdate.Text = informacion[2];
                    txtcombotipoupdate.Text = informacion[3];
                    txtnameupdate.Text = informacion[4];
                    txtlastnameupdate.Text = informacion[5];
                    txtcorreoelectronicoupdate.Text = informacion[6];
                    txtmaskedtelefonoupdate.Text = informacion[7];
                    txtdatetimefechadenacimientoupdate.Text = informacion[8].ToString();
                    txtcombosexoupdate.Text = informacion[9];
                    txtcomentupdate.Text = informacion[10];
                }
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreoelectronicoupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcomentupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtreppassupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlastnameupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpasswordupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusernameupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnameupdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void txterrorupdate_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void txtcombosexoupdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void txtdatetimefechadenacimientoupdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void txtmaskedtelefonoupdate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void txtcombotipoupdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            if (validar())
            {
                if (conexion.update("usuarios", "nombre='"+txtnameupdate.Text+"',usuario='" + txtusernameupdate.Text + "',clave='" + txtpasswordupdate.Text + "',tipo='"+txtcombotipoupdate.Text+"',apellidos='"+txtlastnameupdate.Text+"',correo='"+txtcorreoelectronicoupdate.Text+"',telefono='"+txtmaskedtelefonoupdate.Text+"',fechadenacimiento='"+txtdatetimefechadenacimientoupdate.Text+"',sexo='"+txtcombosexoupdate.Text+"',comentario='"+txtcomentupdate.Text+"'", "id='" + label19.Text + "'"))
                {//pendiente aqui que falta
                    conexion.inform("Informacion del usuario actualizada");
                    txterrorupdate.Text = "Informacion Actualizada";
                }
            }

        }


        public bool validar()
        {
            int controles = groupBox1.Controls.Count;
            if (label19.Text == "[Seleccione un usuario]")
            {

                txterrorupdate.Text = "Primero seleccione un usuario";
                return false;
            }
            if (txtpasswordupdate.Text!= txtreppassupdate.Text)
            {

                txterrorupdate.Text = "Las Claves no coiciden";
                return false;
            }
            foreach (Control item in groupBox1.Controls)
            {
                
                if (item.Text == "")
                {
                    txterrorupdate.Text = "Complete todos los campos";
                    return false;
                }
            }
            return true;
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cargarInfoEditar();
        }
    }
}
