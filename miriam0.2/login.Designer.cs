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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.ComboBox();
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
            this.button1.Location = new System.Drawing.Point(483, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar Sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(675, 241);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 49);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '▼';
            this.textBox2.Size = new System.Drawing.Size(229, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(452, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(360, 95);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.FormattingEnabled = true;
            this.textBox1.Location = new System.Drawing.Point(92, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.SelectedIndexChanged += new System.EventHandler(this.textBox1_SelectedIndexChanged);
            this.textBox1.ImeModeChanged += new System.EventHandler(this.textBox1_ImeModeChanged);
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
            this.pantalla.Location = new System.Drawing.Point(16, 234);
            this.pantalla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pantalla.Name = "pantalla";
            this.pantalla.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pantalla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pantalla.Size = new System.Drawing.Size(835, 383);
            this.pantalla.TabIndex = 9;
            this.pantalla.TabStop = false;
            this.pantalla.Text = "Iniciar Sesion";
            // 
            // opciones
            // 
            this.opciones.AutoSize = true;
            this.opciones.Location = new System.Drawing.Point(35, 358);
            this.opciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(68, 17);
            this.opciones.TabIndex = 11;
            this.opciones.TabStop = true;
            this.opciones.Text = "Opciones";
            this.opciones.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // servidor
            // 
            this.servidor.AutoSize = true;
            this.servidor.Location = new System.Drawing.Point(35, 335);
            this.servidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.servidor.Name = "servidor";
            this.servidor.Size = new System.Drawing.Size(181, 17);
            this.servidor.TabIndex = 10;
            this.servidor.TabStop = true;
            this.servidor.Text = "Probar conexion al servidor";
            this.servidor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.servidor_LinkClicked);
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(265, 335);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(43, 17);
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
            this.appPhr.Location = new System.Drawing.Point(308, 194);
            this.appPhr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appPhr.Name = "appPhr";
            this.appPhr.Size = new System.Drawing.Size(302, 36);
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
            this.appName.Location = new System.Drawing.Point(296, 84);
            this.appName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(302, 135);
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
            this.barraPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.barraPrincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Size = new System.Drawing.Size(895, 41);
            this.barraPrincipal.TabIndex = 14;
            this.barraPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.barraPrincipal_Paint);
            this.barraPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraPrincipal_MouseDown_1);
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titulo.Location = new System.Drawing.Point(16, 7);
            this.titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(122, 24);
            this.titulo.TabIndex = 13;
            this.titulo.Text = "Riku - Login";
            this.titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titulo_MouseDown);
            // 
            // ventana_btn_cerrar
            // 
            this.ventana_btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_cerrar.Image")));
            this.ventana_btn_cerrar.Location = new System.Drawing.Point(837, 2);
            this.ventana_btn_cerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ventana_btn_cerrar.Name = "ventana_btn_cerrar";
            this.ventana_btn_cerrar.Size = new System.Drawing.Size(41, 37);
            this.ventana_btn_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_cerrar.TabIndex = 15;
            this.ventana_btn_cerrar.TabStop = false;
            this.ventana_btn_cerrar.Click += new System.EventHandler(this.ventana_btn_cerrar_Click);
            // 
            // ventana_btn_min
            // 
            this.ventana_btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_min.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_min.Image")));
            this.ventana_btn_min.Location = new System.Drawing.Point(736, 2);
            this.ventana_btn_min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ventana_btn_min.Name = "ventana_btn_min";
            this.ventana_btn_min.Size = new System.Drawing.Size(41, 37);
            this.ventana_btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_min.TabIndex = 14;
            this.ventana_btn_min.TabStop = false;
            this.ventana_btn_min.Click += new System.EventHandler(this.ventana_btn_min_Click);
            // 
            // ventana_btn_max
            // 
            this.ventana_btn_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_max.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_max.Image")));
            this.ventana_btn_max.Location = new System.Drawing.Point(785, 2);
            this.ventana_btn_max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ventana_btn_max.Name = "ventana_btn_max";
            this.ventana_btn_max.Size = new System.Drawing.Size(41, 37);
            this.ventana_btn_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_max.TabIndex = 13;
            this.ventana_btn_max.TabStop = false;
            this.ventana_btn_max.Click += new System.EventHandler(this.ventana_btn_max_Click_1);
            // 
            // ventana_btn_normal
            // 
            this.ventana_btn_normal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_normal.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_normal.Image")));
            this.ventana_btn_normal.Location = new System.Drawing.Point(785, 2);
            this.ventana_btn_normal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ventana_btn_normal.Name = "ventana_btn_normal";
            this.ventana_btn_normal.Size = new System.Drawing.Size(41, 37);
            this.ventana_btn_normal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_normal.TabIndex = 15;
            this.ventana_btn_normal.TabStop = false;
            this.ventana_btn_normal.Click += new System.EventHandler(this.ventana_btn_normal_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(895, 631);
            this.Controls.Add(this.barraPrincipal);
            this.Controls.Add(this.appPhr);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.pantalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.LinkLabel opciones;
        private System.Windows.Forms.Panel barraPrincipal;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.PictureBox ventana_btn_cerrar;
        private System.Windows.Forms.PictureBox ventana_btn_min;
        private System.Windows.Forms.PictureBox ventana_btn_max;
        private System.Windows.Forms.PictureBox ventana_btn_normal;
        private System.Windows.Forms.ComboBox textBox1;
    }
}

