namespace miriam0._2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pantalla = new System.Windows.Forms.GroupBox();
            this.opciones = new System.Windows.Forms.LinkLabel();
            this.servidor = new System.Windows.Forms.LinkLabel();
            this.txt = new System.Windows.Forms.LinkLabel();
            this.server = new System.Windows.Forms.Timer(this.components);
            this.login = new System.Windows.Forms.Timer(this.components);
            this.appPhr = new System.Windows.Forms.Label();
            this.appName = new System.Windows.Forms.Label();
            this.barraPrincipal = new System.Windows.Forms.Panel();
            this.titulo = new System.Windows.Forms.Label();
            this.ventana_btn_cerrar = new System.Windows.Forms.PictureBox();
            this.ventana_btn_min = new System.Windows.Forms.PictureBox();
            this.ventana_btn_max = new System.Windows.Forms.PictureBox();
            this.ventana_btn_normal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pantalla.SuspendLayout();
            this.barraPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_normal)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(362, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar Sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(506, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '▼';
            this.textBox2.Size = new System.Drawing.Size(173, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(339, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(270, 77);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pantalla
            // 
            this.pantalla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pantalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pantalla.Controls.Add(this.opciones);
            this.pantalla.Controls.Add(this.servidor);
            this.pantalla.Controls.Add(this.txt);
            this.pantalla.Controls.Add(this.pictureBox1);
            this.pantalla.Controls.Add(this.groupBox1);
            this.pantalla.Controls.Add(this.button1);
            this.pantalla.Controls.Add(this.button2);
            this.pantalla.Location = new System.Drawing.Point(12, 190);
            this.pantalla.Name = "pantalla";
            this.pantalla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pantalla.Size = new System.Drawing.Size(626, 311);
            this.pantalla.TabIndex = 9;
            this.pantalla.TabStop = false;
            this.pantalla.Text = "Iniciar Sesion";
            // 
            // opciones
            // 
            this.opciones.AutoSize = true;
            this.opciones.Location = new System.Drawing.Point(26, 291);
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(52, 13);
            this.opciones.TabIndex = 11;
            this.opciones.TabStop = true;
            this.opciones.Text = "Opciones";
            this.opciones.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // servidor
            // 
            this.servidor.AutoSize = true;
            this.servidor.Location = new System.Drawing.Point(26, 272);
            this.servidor.Name = "servidor";
            this.servidor.Size = new System.Drawing.Size(135, 13);
            this.servidor.TabIndex = 10;
            this.servidor.TabStop = true;
            this.servidor.Text = "Probar conexion al servidor";
            this.servidor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.servidor_LinkClicked);
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(199, 272);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(34, 13);
            this.txt.TabIndex = 9;
            this.txt.TabStop = true;
            this.txt.Text = "Mode";
            this.txt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt_LinkClicked);
            // 
            // server
            // 
            this.server.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // login
            // 
            this.login.Tick += new System.EventHandler(this.login_Tick);
            // 
            // appPhr
            // 
            this.appPhr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.appPhr.AutoSize = true;
            this.appPhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appPhr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.appPhr.Location = new System.Drawing.Point(231, 158);
            this.appPhr.Name = "appPhr";
            this.appPhr.Size = new System.Drawing.Size(250, 29);
            this.appPhr.TabIndex = 11;
            this.appPhr.Text = "Version Empresarial";
            this.appPhr.Click += new System.EventHandler(this.appPhr_Click);
            // 
            // appName
            // 
            this.appName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.appName.AutoSize = true;
            this.appName.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.appName.Location = new System.Drawing.Point(222, 68);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(240, 108);
            this.appName.TabIndex = 10;
            this.appName.Text = "Riku";
            this.appName.Click += new System.EventHandler(this.appName_Click);
            this.appName.DoubleClick += new System.EventHandler(this.appName_DoubleClick);
            // 
            // barraPrincipal
            // 
            this.barraPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.barraPrincipal.Controls.Add(this.titulo);
            this.barraPrincipal.Controls.Add(this.ventana_btn_cerrar);
            this.barraPrincipal.Controls.Add(this.ventana_btn_min);
            this.barraPrincipal.Controls.Add(this.ventana_btn_max);
            this.barraPrincipal.Controls.Add(this.ventana_btn_normal);
            this.barraPrincipal.Location = new System.Drawing.Point(-3, -1);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Size = new System.Drawing.Size(735, 33);
            this.barraPrincipal.TabIndex = 12;
            this.barraPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraPrincipal_MouseDown);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titulo.Location = new System.Drawing.Point(12, 6);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(99, 18);
            this.titulo.TabIndex = 13;
            this.titulo.Text = "Riku - Login";
            // 
            // ventana_btn_cerrar
            // 
            this.ventana_btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_cerrar.Image")));
            this.ventana_btn_cerrar.Location = new System.Drawing.Point(642, 2);
            this.ventana_btn_cerrar.Name = "ventana_btn_cerrar";
            this.ventana_btn_cerrar.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_cerrar.TabIndex = 15;
            this.ventana_btn_cerrar.TabStop = false;
            this.ventana_btn_cerrar.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // ventana_btn_min
            // 
            this.ventana_btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_min.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_min.Image")));
            this.ventana_btn_min.Location = new System.Drawing.Point(566, 2);
            this.ventana_btn_min.Name = "ventana_btn_min";
            this.ventana_btn_min.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_min.TabIndex = 14;
            this.ventana_btn_min.TabStop = false;
            this.ventana_btn_min.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // ventana_btn_max
            // 
            this.ventana_btn_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_max.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_max.Image")));
            this.ventana_btn_max.Location = new System.Drawing.Point(603, 2);
            this.ventana_btn_max.Name = "ventana_btn_max";
            this.ventana_btn_max.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_max.TabIndex = 13;
            this.ventana_btn_max.TabStop = false;
            this.ventana_btn_max.Click += new System.EventHandler(this.ventana_btn_max_Click);
            // 
            // ventana_btn_normal
            // 
            this.ventana_btn_normal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_normal.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_normal.Image")));
            this.ventana_btn_normal.Location = new System.Drawing.Point(603, 2);
            this.ventana_btn_normal.Name = "ventana_btn_normal";
            this.ventana_btn_normal.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_normal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_normal.TabIndex = 15;
            this.ventana_btn_normal.TabStop = false;
            this.ventana_btn_normal.Click += new System.EventHandler(this.ventana_btn_normal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(671, 513);
            this.Controls.Add(this.barraPrincipal);
            this.Controls.Add(this.appPhr);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.pantalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pantalla.ResumeLayout(false);
            this.pantalla.PerformLayout();
            this.barraPrincipal.ResumeLayout(false);
            this.barraPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_normal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox pantalla;
        private System.Windows.Forms.LinkLabel txt;
        private System.Windows.Forms.LinkLabel servidor;
        private System.Windows.Forms.Timer server;
        private System.Windows.Forms.Timer login;
        private System.Windows.Forms.Label appPhr;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Panel barraPrincipal;
        private System.Windows.Forms.PictureBox ventana_btn_cerrar;
        private System.Windows.Forms.PictureBox ventana_btn_min;
        private System.Windows.Forms.PictureBox ventana_btn_max;
        private System.Windows.Forms.PictureBox ventana_btn_normal;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.LinkLabel opciones;
    }
}

