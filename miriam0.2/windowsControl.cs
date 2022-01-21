using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace riku
{
    class windowsControl
    { 

        public void Minimizar(Form formulario)
        {
            if (formulario.WindowState != FormWindowState.Minimized)
            {
                formulario.WindowState = FormWindowState.Minimized;
                updateButtons(formulario);
            }
        }

        public void Maximizar(Form formulario)
        {
            if (formulario.WindowState != FormWindowState.Maximized)
            {
                formulario.WindowState = FormWindowState.Maximized;
                updateButtons(formulario);
            }
        }

        public void normalizar(Form formulario)
        {
            if (formulario.WindowState != FormWindowState.Normal)
            {
                formulario.StartPosition = FormStartPosition.CenterScreen;

                formulario.WindowState = FormWindowState.Normal;
                
                updateButtons(formulario);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public void mover(Form formulario)
        {
            ReleaseCapture();
            SendMessage(formulario.Handle, 0x112, 0xf012, 0);
            updateButtons(formulario);
        }

        public void updateButtons(Form formulario)
        {                       
            Panel panel = formulario.Controls["barraPrincipal"] as Panel;
            panel.Width = formulario.Width+50;
            PictureBox n = panel.Controls["ventana_btn_normal"] as PictureBox;
            PictureBox i = panel.Controls["ventana_btn_min"] as PictureBox;
            PictureBox a = panel.Controls["ventana_btn_max"] as PictureBox;

            switch (formulario.WindowState)
            {                

                case FormWindowState.Normal:
                    n.Visible = false;
                    i.Visible = true;
                    a.Visible = true;
                    break;
                case FormWindowState.Minimized:
                    n.Visible = true;
                    i.Visible = true;
                    a.Visible = true;
                    break;
                case FormWindowState.Maximized:
                    a.Visible = false;
                    n.Visible = true;
                    i.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
