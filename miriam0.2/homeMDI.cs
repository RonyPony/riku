using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miriam0._2;
using System.IO;

namespace riku
{
    public partial class homeMDI : Form
    {
        private int childFormNumber = 0;
        onlineCnn internet = new onlineCnn();
        cnn data = new cnn();
        int storeId = 0;
        public string user, type; 
        

        public homeMDI(String usser)
        {
            InitializeComponent();
            
            if (data.isAdmin(usser))
            {
                 type = "Administrador";
            }
            else
            {
                type = "Usuario General";
            }

            user = usser;
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            
        }

        public bool launch(Form formulario)
        {
            try
            {
                if (formulario !=null)
                {
                    //formulario form = new formulario(usuario.Text, tipo.Text);
                    formulario.MdiParent = this;
                    formulario.Show();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                status(ex.Message);
                return false;
            }
        } 
        public void status(string txt)
        {
            statux.Text = txt;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            launch(new agregarVentaDeldia(user));
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new consultarCliente(user));
        }

        private void homeMDI_Load(object sender, EventArgs e)
        {
            usuario.Text = user.ToUpper();
            tipo.Text = type.ToUpper();
            casa();
            timer1.Start();
            string initialModule;
            try
            {
               initialModule = data.getModuloById(data.getTable("usuarios", "id=" + data.getIdUsuario(user)).Rows[0][11].ToString());
            }
            catch (Exception)
            {
                initialModule = "Ninguno";
            }
             
            Form startUp = data.getForm(initialModule, user);
            if (startUp != null)
            {
                launch(startUp);
            }

            data.activeUserId = data.getIdUsuario(user);

        }
        public void casa()
        {
            home hh = new home(user, internet.checkInter(storeId), 123);
            // Set the Parent Form of the Child window.
            hh.MdiParent = this;
            // Display the new form.
            hh.Show();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.yesnoDialog("Estas seguro que desea salir?"))
            {
                Application.Exit();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateHora();
        }
        public void updateHora()
        {
            hora.Text = DateTime.Now.ToString("hh:mm:ss");
            
            fecha.Text = DateTime.Now.ToShortDateString();
            int ventanas = this.MdiChildren.Length-1;
            if (ventanas>1)
            {
                windowsMenu.Text = "Ventanas (" +ventanas.ToString() + ")";
            }
            else
            {
                windowsMenu.Text = "Ventanas";
            }
            //update status
            log procesos = new log();
            try
            {
                string[] lines = File.ReadAllLines(procesos.getLogFile());
                int tama = lines.Length;
                statux.Text = lines[1];
                Console.WriteLine(lines[1]);
            }
            catch (Exception)
            {

               // throw;
            }
            

            if (!internet.checkInter(storeId))
                {
                    toolStripLabel5.Text = "Desconectado".ToUpper();
                    toolStripLabel5.ForeColor = Color.Red;
                }
                else
                {
                    toolStripLabel5.Text = "Conectado".ToUpper();
                    toolStripLabel5.ForeColor = Color.Green;
                }
            if (MdiChildren.Length==0)
            {
                casa();
            }
            
        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (data.yesnoDialog("Estas seguro que desea salir?"))
            {
                Application.Exit();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 login = new Form1(internet.checkInter(storeId),storeId);
            login.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();
            admUsuarios usr = new admUsuarios(user);
            usr.MdiParent = this;
            usr.Show();
        }

        private void eliminarUnUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admUsuarios usr = new admUsuarios(user);
            usr.MdiParent = this;
            usr.Show();
            usr.tabControl1.SelectedTab = usr.tabControl1.TabPages[1];
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admUsuarios usr = new admUsuarios(user);
            usr.MdiParent = this;
            usr.Show();
            usr.tabControl1.SelectedTab = usr.tabControl1.TabPages[0];
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new consultarVentas(user));
        }

        private void consultarVentaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new consultarVentasDiaria(user));
        }

        private void registrarUnaActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new agregarActividad(user));
        }

        private void consultarActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new consultarActividades(user));
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new agregarCliente(user));
        }

        private void nuevoSuplidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new agregarSuplidor(user));
        }

        private void consultarSuplidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new consultarSuplidor(user));
        }

        private void administradorDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new reporteInventario(user));
        }

        private void sistemaDeDepuracionInternaSDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new logview());
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new facturaNo(user));
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new settings(user));
        }

        private void navegadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new navegador(user));
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new calculadora(user));
        }

        private void conversorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new conversor(user));
        }

        private void generadorDeNumerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new generador());
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int ultimo = MdiChildren.Length;
            MdiChildren[ultimo-1].Close();
        }

        private void unidadesDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new units(user));
        }

        private void agregarUnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new addUnit(user));
        }

        private void administrarUnidadesDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new units(user));
        }

        private void consultarContribuyentesDGIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new DGII.consultarContribuyente(user));
        }

        private void statux_Click(object sender, EventArgs e)
        {

        }

        private void menuContextual1_Load(object sender, EventArgs e)
        {

        }

        private void menuContextual1_Load_1(object sender, EventArgs e)
        {

        }

        private void menuContextual1_contextOption(object sender, EventArgs e)
        {
            string selectedOption = ((TreeViewEventArgs)e).Node.Text.ToLower();
            //MessageBox.Show(selectedOption);
            launch(data.getForm(selectedOption,user));
        }

       

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launch(new facturar(user));
        }
    }
}
