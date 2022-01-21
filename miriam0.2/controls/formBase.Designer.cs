namespace riku.controls
{
    partial class formBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBase));
            this.barraPrincipal = new System.Windows.Forms.Panel();
            this.titulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ventana_btn_cerrar = new System.Windows.Forms.PictureBox();
            this.ventana_btn_min = new System.Windows.Forms.PictureBox();
            this.ventana_btn_max = new System.Windows.Forms.PictureBox();
            this.ventana_btn_normal = new System.Windows.Forms.PictureBox();
            this.barraPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_normal)).BeginInit();
            this.SuspendLayout();
            // 
            // barraPrincipal
            // 
            this.barraPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.barraPrincipal.Controls.Add(this.pictureBox1);
            this.barraPrincipal.Controls.Add(this.titulo);
            this.barraPrincipal.Controls.Add(this.ventana_btn_cerrar);
            this.barraPrincipal.Controls.Add(this.ventana_btn_min);
            this.barraPrincipal.Controls.Add(this.ventana_btn_max);
            this.barraPrincipal.Controls.Add(this.ventana_btn_normal);
            this.barraPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Size = new System.Drawing.Size(689, 36);
            this.barraPrincipal.TabIndex = 13;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titulo.Location = new System.Drawing.Point(42, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(99, 18);
            this.titulo.TabIndex = 13;
            this.titulo.Text = "Riku - Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::riku.Properties.Resources.twotone_radio_button_unchecked_black_18dp;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // ventana_btn_cerrar
            // 
            this.ventana_btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_cerrar.Image")));
            this.ventana_btn_cerrar.Location = new System.Drawing.Point(648, 2);
            this.ventana_btn_cerrar.Name = "ventana_btn_cerrar";
            this.ventana_btn_cerrar.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_cerrar.TabIndex = 15;
            this.ventana_btn_cerrar.TabStop = false;
            // 
            // ventana_btn_min
            // 
            this.ventana_btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_min.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_min.Image")));
            this.ventana_btn_min.Location = new System.Drawing.Point(572, 2);
            this.ventana_btn_min.Name = "ventana_btn_min";
            this.ventana_btn_min.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_min.TabIndex = 14;
            this.ventana_btn_min.TabStop = false;
            // 
            // ventana_btn_max
            // 
            this.ventana_btn_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_max.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_max.Image")));
            this.ventana_btn_max.Location = new System.Drawing.Point(609, 2);
            this.ventana_btn_max.Name = "ventana_btn_max";
            this.ventana_btn_max.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_max.TabIndex = 13;
            this.ventana_btn_max.TabStop = false;
            // 
            // ventana_btn_normal
            // 
            this.ventana_btn_normal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ventana_btn_normal.Image = ((System.Drawing.Image)(resources.GetObject("ventana_btn_normal.Image")));
            this.ventana_btn_normal.Location = new System.Drawing.Point(609, 2);
            this.ventana_btn_normal.Name = "ventana_btn_normal";
            this.ventana_btn_normal.Size = new System.Drawing.Size(31, 30);
            this.ventana_btn_normal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ventana_btn_normal.TabIndex = 15;
            this.ventana_btn_normal.TabStop = false;
            // 
            // formBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 323);
            this.Controls.Add(this.barraPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formBase";
            this.Text = "formBase";
            this.Load += new System.EventHandler(this.formBase_Load);
            this.barraPrincipal.ResumeLayout(false);
            this.barraPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventana_btn_normal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barraPrincipal;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.PictureBox ventana_btn_cerrar;
        private System.Windows.Forms.PictureBox ventana_btn_min;
        private System.Windows.Forms.PictureBox ventana_btn_max;
        private System.Windows.Forms.PictureBox ventana_btn_normal;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}