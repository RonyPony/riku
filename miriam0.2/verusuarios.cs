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
    public partial class verusuarios : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;

        public verusuarios(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grid();
        }

        public void grid()
        {
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
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void verusuarios_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Ver usuarios cargado.");
            grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
