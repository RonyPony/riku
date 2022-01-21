using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miriam0;

namespace riku
{
    public partial class units : Form
    {
        cnn conexion = new cnn();
        miriam0._2.log log = new miriam0._2.log();

        string usuario;

        public units(string user)
        {
            usuario = user;
            InitializeComponent();
        }

        private void units_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Administrador de unidades de medidas cargado.");
            cargar();
            loadCombo();
        }

        public void loadCombo()
        {
            try
            {
                comboBox1.Items.Clear();
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    comboBox1.Items.Add(columna.HeaderText);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cargar()
        {
            dataGridView1.DataSource = conexion.getTable("units","");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscar();
        }

        public void buscar()
        {
            if (comboBox1.Text == "Seleccionar..." || comboBox1.Text == "")
            {
                conexion.inform("Elige un criterio de busqueda primero");
            }
            else
            {
                dataGridView1.DataSource = conexion.getTable("units",comboBox1.Text+" like '%"+textBox1.Text+"%'");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conexion.yesnoDialog("Seguro que quiere eliminar esta unidad."))
            {
                conexion.delete("units","id="+dataGridView1.CurrentRow.Cells[0].Value.ToString());
                conexion.inform("Unidad de medida eliminada");
            }
            cargar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (conexion.isAdmin(usuario))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addUnit nuev = new addUnit(usuario);
            nuev.Show();
        }
    }
}
