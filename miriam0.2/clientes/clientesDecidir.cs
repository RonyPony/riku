﻿using System;
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
    public partial class clientesDecidir : Form
    {
        string usuario;
        string tipo;

        public clientesDecidir(string uusuario,string ttipo)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = ttipo;
            this.Text = "Clientes ["+usuario+"] ["+tipo+"]";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            consultarCliente cc = new consultarCliente(usuario);
            cc.MdiParent = this.ParentForm;
            cc.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarCliente cc = new consultarCliente(usuario);
            cc.MdiParent = this.ParentForm;
            cc.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            agregarCliente aaa = new agregarCliente(usuario);
            aaa.MdiParent = this.ParentForm;
            aaa.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarCliente aaa = new agregarCliente(usuario);
            aaa.MdiParent = this.ParentForm;
            aaa.Show();
            this.Close();
        }

        private void clientesDecidir_Load(object sender, EventArgs e)
        {

        }
    }
}
