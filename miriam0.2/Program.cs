using riku;
using riku.DGII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miriam0._2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Exception f = new Exception();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new admUsuarios("Rony.Tuquizz"));
            //Application.Run(new consultarVentas("Rony.Tuquizz","Administrador"));
            //Application.Run(new home("public-user",false,2345));
            //Application.Run(new salidadeinventario("prueba","administrador"));
            //Application.Run(new inventario("Prueba","administrador"));
            Application.Run(new splash());
            //Application.Run(new navegador("ronel"));
            //Application.Run(new units("ronel"));
            //Application.Run(new reporteInventario("Ronel"));
            //Application.Run(new reporteInventario("ronel"));
            //Application.Run(new consultarVentas("ronel"));
            //Application.Run(new agregarainventario("ronel"));
            //Application.Run(new consultarCliente("ronel"));
            //Application.Run(new agregarCliente("d"));
            //Application.Run(new homeMDI("ronel"));
            //Application.Run(new newHome());
            //Application.Run(new consultarContribuyente("test"));
            //Application.Run(new errorManager("",new Exception("este es un error probocado")));
            //Application.Run(new settings("ronel"));
            //Application.Run(new agregarSuplidor("fd","fol"));
            //Application.Run(new agregarActividad("prueba", "administrador"));
            //Application.Run(new compraAsuplidor("ronel","administrador"));
            //Application.Run(new consultarActividades("prueba", "administrador"));
            //Application.Run(new agregarVentaDeldia("Prueba"));
            //Application.Run(new agregarainventario("prueba","prueba"));
            //Application.Run(new logview());
            //Application.Run(new suplidoresdecidir("prueba","administrador"));
            //Application.Run(new conversor());
            //Application.Run(new FacturaViewer("prueba","administrador"));
            //Application.Run(new facturar("Prueba","administrador"));
            //Application.Run(new reporteInventario("prueba","Administrador"));
            //Application.Run(new agregarainventario("Prueba"));
            //Application.Run(new calculadora("s","d"));
            //Application.Run(new nuevoUsr());
            //Application.Run(new generador());
            //Application.Run(new Form1(true,0808));
            //Application.Run(new eliminar());
        }
    }
}
