using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku
{
    public partial class select : Form
    {
        cnn conexion = new cnn();
        string table;

       
        public DataGridViewRow row { get; set; } 


        public select(string tablex)
        {
            InitializeComponent();
            table = tablex;
        }

        private void select_Load(object sender, EventArgs e)
        {
            cargar();
        }

        public void cargar()
        {
            try
            {
                dataGridView1.DataSource = conexion.getTable(table, string.Empty);
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    comboBox1.Items.Add(item.HeaderText);
                }
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void button1_Click(object sender, EventArgs e)
        {        
            row = dataGridView1.CurrentRow;
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void select_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text!="")
            {
                dataGridView1.DataSource = conexion.getTable(table, comboBox1.Text + " like '%" + textBox1.Text + "%'");
            }
            else
            {
                conexion.inform("Ingrese el texto y el criterio de busqueda para poder continuar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            row = dataGridView1.CurrentRow;
            this.Close();
        }
    }
}
