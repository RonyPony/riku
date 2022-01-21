namespace riku.controls
{
    partial class menuContextual
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Inicio");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Administrador de usuarios");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Nuevo usuario");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Eliminar usuario");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Consultar clientes");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Nuevo cliente");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Agregar suplidor");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Consultar suplidores");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Suplidores", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Administracion ", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode8,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Facturar");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Registrar venta del dia");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Registrar actividad");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Consultar venta del dia");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Consultar una actividad");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Registro Rapido", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Transacciones", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Consultar ventas");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Consultar una factura");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Inventario");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Consultas", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Administrador de reportes");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Auditoria de sistema - SDI");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Reportes", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Calculadora");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Conversor de unidades");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Navegador");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Consultar Contribuyentes DGII");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Herramientas", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Administrar unidades de medida");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Agregar unidad de medida");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Unidades de medida", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Catalogos", new System.Windows.Forms.TreeNode[] {
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Configuracion");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("MS Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.ItemHeight = 44;
            this.treeView1.LineColor = System.Drawing.Color.Lime;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Inicio";
            treeNode2.Name = "Node12";
            treeNode2.Text = "Administrador de usuarios";
            treeNode3.Name = "Node13";
            treeNode3.Text = "Nuevo usuario";
            treeNode4.Name = "Node14";
            treeNode4.Text = "Eliminar usuario";
            treeNode5.Name = "Node11";
            treeNode5.Text = "Usuarios";
            treeNode6.Name = "Node19";
            treeNode6.Text = "Consultar clientes";
            treeNode7.Name = "Node20";
            treeNode7.Text = "Nuevo cliente";
            treeNode8.Name = "Node18";
            treeNode8.Text = "Clientes";
            treeNode9.Name = "Node22";
            treeNode9.Text = "Agregar suplidor";
            treeNode10.Name = "Node23";
            treeNode10.Text = "Consultar suplidores";
            treeNode11.Name = "Node21";
            treeNode11.Text = "Suplidores";
            treeNode12.Name = "Administracion ";
            treeNode12.Text = "Administracion ";
            treeNode13.Name = "Node5";
            treeNode13.Text = "Facturar";
            treeNode14.Name = "Node7";
            treeNode14.Text = "Registrar venta del dia";
            treeNode15.Name = "Node10";
            treeNode15.Text = "Registrar actividad";
            treeNode16.Name = "Node9";
            treeNode16.Text = "Consultar venta del dia";
            treeNode17.Name = "Node8";
            treeNode17.Text = "Consultar una actividad";
            treeNode18.Name = "Node6";
            treeNode18.Text = "Registro Rapido";
            treeNode19.Name = "Node4";
            treeNode19.Text = "Transacciones";
            treeNode20.Name = "Node17";
            treeNode20.Text = "Consultar ventas";
            treeNode21.Name = "Node31";
            treeNode21.Text = "Consultar una factura";
            treeNode22.Name = "Node0";
            treeNode22.Text = "Inventario";
            treeNode23.Name = "Node16";
            treeNode23.Text = "Consultas";
            treeNode24.Name = "Node25";
            treeNode24.Text = "Administrador de reportes";
            treeNode25.Name = "Node26";
            treeNode25.Text = "Auditoria de sistema - SDI";
            treeNode26.Name = "Node24";
            treeNode26.Text = "Reportes";
            treeNode27.Name = "Node1";
            treeNode27.Text = "Calculadora";
            treeNode28.Name = "Node2";
            treeNode28.Text = "Conversor de unidades";
            treeNode29.Name = "Node3";
            treeNode29.Text = "Navegador";
            treeNode30.Name = "Node4";
            treeNode30.Text = "Consultar Contribuyentes DGII";
            treeNode31.Name = "Tools";
            treeNode31.Text = "Herramientas";
            treeNode32.Name = "Node29";
            treeNode32.Text = "Administrar unidades de medida";
            treeNode33.Name = "Node30";
            treeNode33.Text = "Agregar unidad de medida";
            treeNode34.Name = "Node28";
            treeNode34.Text = "Unidades de medida";
            treeNode35.Name = "Node27";
            treeNode35.Text = "Catalogos";
            treeNode36.Name = "Node32";
            treeNode36.Text = "Configuracion";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode19,
            treeNode23,
            treeNode26,
            treeNode31,
            treeNode35,
            treeNode36});
            this.treeView1.Size = new System.Drawing.Size(391, 444);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = global::riku.Properties.Resources.baseline_menu_black_18dp;
            this.button1.Location = new System.Drawing.Point(338, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 444);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuContextual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "menuContextual";
            this.Size = new System.Drawing.Size(391, 444);
            this.Load += new System.EventHandler(this.menuContextual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
    }
}
