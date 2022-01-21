using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using riku;

namespace miriam0._2
{
    class log
    {
        cnn conexion = new cnn();
        string ruta = @"C:\RikuFiles\Log\";
        string rutaReportes = @"C:\RikuFiles\Reportes\";
        public string rutaErrors = @"C:\RikuFiles\Errors\";
        public string fileError = "Errors.txt";
        string filex = "Log.txt";
        string fecha = DateTime.Now.ToString("G");
        int productostotal;
        Double precioavenderpormedidatotal;
        Double gananciaseninventario;
        Double VDEtotal;
        int repinventariototal;
        string peso = "RD$:";

        int usuariostotal;

        public void notificacion(string usuario,string mensaje)
        {
            string history = File.ReadAllText(ruta + filex);
            using (var fs = new FileStream(ruta + filex, FileMode.Truncate))
            {
            }
            StreamWriter div = File.AppendText(ruta + filex);
            string divi = "_________________________________________________________________________________________";
            
            string linea = "[NOTIFICACION] ["+usuario+"] ["+fecha+"] ["+mensaje+"]";
            div.WriteLine(divi);
            div.WriteLine(linea);
            div.WriteLine(history);
            div.Close();
            //string table,string fields,string values
            string fields = "logType,user,datetime,info";
            string values = "'Notificacion','"+usuario+"','"+fecha+"','"+mensaje+"'";
            //conexion.save("log",fields,values);
        }

        public void errorLog(string usuario, string mensaje)
        {
            mensaje = mensaje.Replace("'", "-");
            usuario = usuario.Replace("'", "-");
            string history = File.ReadAllText(ruta + filex);
            using (var fs = new FileStream(ruta + filex, FileMode.Truncate))
            {
            }
            StreamWriter div = File.AppendText(ruta + filex);
            string divi = "_________________________________________________________________________________________";

            string linea = "[ERROR] [" + usuario + "] [" + fecha + "] [" + mensaje + "]";
            div.WriteLine(divi);
            div.WriteLine(linea);
            div.WriteLine(history);
            div.Close();
            //string table,string fields,string values
            string fields = "logType,usuario,datetime,info";
            string values = "'ERROR','" + usuario + "','" + fecha + "','" + mensaje + "'";
            conexion.save("log", fields, values);
        }

        public string getLogFile()
        {
            return ruta+filex;
        }

        public void venta(string usuario, string mensaje,string idfacvent)
        {
            string history = File.ReadAllText(ruta + filex);
            using (var fs = new FileStream(ruta + filex, FileMode.Truncate))
            {
            }
            StreamWriter div = File.AppendText(ruta + filex);
            string divi = "=========================================================================================";
            string linea = "[VENTA] ["+usuario+"] ["+fecha+"] ["+mensaje+"] [ Factura No. "+idfacvent+"]";
            div.WriteLine(divi);
            div.WriteLine(divi);
            div.WriteLine(linea);
            div.WriteLine(divi);
            div.WriteLine(divi);
            div.WriteLine(history);
            div.Close();
        }
        public void crearReporte(string date, string fuente)
            {
            fuente=fuente.ToLower();
            if (fuente=="inventario") { crearreportedeinventario(date); }
            if (fuente == "usuarios") { crearreportedeusuarios(date); }
            if (fuente == "flujo de inventario") { crearreportedeflujoinventario(date); }
            if (fuente == "venta diaria esp") { cearreporteVDE(date); }            
            if (fuente == "venta diaria total") { cearreporteVDT(date); }
            if (fuente == "actividades") { cearreporteACT(date); }
            if (fuente == "ventas") { crearreportedeventas(date); }

        }

        public void cearreporteACTE(string fecha,string act)
        {
            string header = "<meta http-equiv='Content-Type' content='text/html'; charset=utf-8/><html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><center><h1> Reporte de Actividades Especificas ("+act+")</h1>       <h4>Reporte generado el " + fecha + "</h4><hr><table><tr><th> ID </th><th> Fecha </th><th> Accion </th><th> Efectivo </th></tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html>";
            int cuenta;
            try
            {
                string archivo = "Actividades-Especificas-"+act+"-" + fecha + ".html";
                StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                //conexion.abrir();
                //SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM actividades where tipo = '"+act+"'", conexion.ver());
                //Int32 count = (Int32)comm.ExecuteScalar();
                cuenta = conexion.getCount("actividades", "tipo = '" + act + "'");
                conexion.cerrar();
                System.Console.WriteLine(fecha);
                System.Console.WriteLine(cuenta);

                if (cuenta == 0)
                {
                    Archivo.WriteLine("<h1>No existen registros del " + fecha + "</h1>");
                }
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from actividades where tipo = '" + act + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    while (lector.Read())
                    {
                        //"#,##0.00"                        
                        String s = lector["flujoefectivo"].ToString();
                        Double money = (double.Parse(s, CultureInfo.InvariantCulture));
                        // MessageBox.Show(s.ToString());
                        Archivo.WriteLine("<tr><td>" + lector["idactividad"].ToString() + "</td><td><strong>" + lector["fecha"].ToString() + "</td><td>" + lector["accion"].ToString() + "</td><td><strong>" + peso + " " + money.ToString().Replace(',', '.') + " </strong></td></tr><tr>");
                        //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                    }

                }
                else
                {

                }
                // Archivo.WriteLine(data1);
                Archivo.WriteLine(footer);
                Archivo.WriteLine("<br><br><br><strong>" + cuenta+" Actividades Registradas</strong>");
                Archivo.Flush();
                Archivo.Close();
                if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    Abrir(rutaReportes + archivo);
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void cearreporteACT(string fecha)
        {
            string header = "<meta http-equiv='Content-Type' content='text/html'; charset=utf-8/><html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><center><h1> Reporte de Actividades Totales</h1>       <h4>Reporte generado el " + fecha + "</h4><hr><table><tr><th> ID </th><th> Fecha </th>      <th> Tipo </th> <th> Accion </th><th> Efectivo </th></tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html>";
            int cuenta;
            try
            {
                string archivo = "Actividades-Totales-" + fecha + ".html";
                StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                Int32 count = conexion.getCount("actividades","");
                System.Console.WriteLine(fecha);
                System.Console.WriteLine(count);
                cuenta = count;
                if (count == 0)
                {
                    Archivo.WriteLine("<h1>No existen registros del " + fecha + "</h1>");
                }
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from actividades;";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    while (lector.Read())
                    {
                        //"#,##0.00"                        
                        String s = lector["flujoefectivo"].ToString();
                        Double money = (double.Parse(s, CultureInfo.InvariantCulture));
                        // MessageBox.Show(s.ToString());
                        Archivo.WriteLine("<tr><td>" + lector["idactividad"].ToString() + "</td><td><strong>" + lector["fecha"].ToString() + "</td><td>"+lector["tipo"].ToString()+ "</td><td>" + lector["accion"].ToString() + "</td><td><strong>" + peso + " " + money.ToString().Replace(',', '.') + " </strong></td></tr><tr>");
                        //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                    }
                }
                else
                {

                }
                // Archivo.WriteLine(data1);
                Archivo.WriteLine(footer);
                Archivo.WriteLine("<br><br><br><strong>" + cuenta + " Actividades Registradas</strong>");
                Archivo.Flush();
                Archivo.Close();
                if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    Abrir(rutaReportes + archivo);
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void cearreporteVDT(string fecha)
        {
            string header = "<meta http-equiv='Content-Type' content='text/html'; charset=utf-8/><html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de Ventas Diaria Totales</h1>       <h4>Reporte generado el " + fecha + "</h4><hr><table><tr><th> ID </th><th> Fecha </th>      <th> Effectivo Registrado </th></tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html>";
            try
            {
                string archivo = "Ventas-Diarias-Totales-"+fecha+".html";
                StreamWriter Archivo = new StreamWriter(rutaReportes+archivo);
                Int32 count = conexion.getCount("ventasdiarias","");
                System.Console.WriteLine(fecha);
                System.Console.WriteLine(count);
                if (count == 0)
                {
                    Archivo.WriteLine("<h1>No existen registros del " + fecha + "</h1>");
                }
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from ventasdiarias;";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    while (lector.Read())
                    {
                        //"#,##0.00"                        
                        String s = lector["dinero"].ToString();
                        Double money = (double.Parse(s, CultureInfo.InvariantCulture));
                       // MessageBox.Show(s.ToString());
                        Archivo.WriteLine("<tr><td>" + lector["idventadiaria"].ToString() + "</td><td><strong>" + lector["fecha"].ToString() + "</td><td><strong>" +peso+" "+ money.ToString().Replace(',', '.') + " </strong></td></tr><tr>");
                        //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                    }

                }
                else
                {

                }
                // Archivo.WriteLine(data1);
                Archivo.WriteLine(footer);
                Archivo.Flush();
                Archivo.Close();
                if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    Abrir(rutaReportes + archivo);
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void cearreporteVDE(string fecha)
        {            
            string header = "<html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de Venta Diaria</h1>       <h4>Reporte de " + fecha + "</h4>          <hr>   <table>     <tr>          <th> ID </th>      <th> Fecha </th>      <th> Effectivo Registrado </th>        </tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html> ";

            try
            {
                string archivo = "Venta-Diaria-Del-" + fecha + ".html";
                StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);                
                Int32 count = conexion.getCount("ventasdiarias", "fecha = '" + fecha + "'");
                
                System.Console.WriteLine(fecha);
                System.Console.WriteLine(count);
                if (count == 0)
                {
                    Archivo.WriteLine("<h1>No existen registros del " + fecha + "</h1>");
                }
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from ventasdiarias where fecha='"+fecha+"';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    while (lector.Read())
                    {
                        //"#,##0.00"                        
                        String s = lector["dinero"].ToString();
                        Double money = (double.Parse(s, CultureInfo.InvariantCulture));
                        //MessageBox.Show(s.ToString());
                        Archivo.WriteLine("<tr><td>" + lector["idventadiaria"].ToString() + "</td><td><strong>" + lector["fecha"].ToString() + "</td><td><strong>" +peso+" " +money.ToString().Replace(',','.') + " </strong></td></tr><tr>");
                        //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                    }

                }
                else
                {

                }
               // Archivo.WriteLine(data1);
                Archivo.WriteLine(footer);
                Archivo.Flush();
                Archivo.Close();
                if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    Abrir(rutaReportes + archivo);
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        public void crearreportedeflujoinventario(string fecha)
        {
            string header = "<html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de Flujo en inventario</h1>       <h4>Reporte de " + fecha + "</h4>          <hr>   <table>     <tr>          <th> Producto </th>      <th> Hora </th>      <th> Accion </th>        </tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html> ";

            try
            {
                string archivo = "Flujo-en-inventario-" + fecha + ".html";
                StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                //conexion.abrir();
                //SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM reporteinventario where fecha = '"+fecha+"'", conexion.ver());
                //Int32 count = (Int32)comm.ExecuteScalar();
                repinventariototal = conexion.getCount("reporteinventario", "fecha = '" + fecha + "'");                               
                conexion.cerrar();
                string data1 = "<tr><td>Acciones en total del " + fecha + "</td><td>   <strong>" + repinventariototal.ToString() + " acciones </strong></td></tr><tr>";
                if (repinventariototal == 0)
                {
                    Archivo.WriteLine("<h1>No existen registros del "+fecha+"</h1>");
                }


                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from reporteinventario where fecha = '"+fecha+"';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    while (lector.Read())
                    {
                        Archivo.WriteLine("<tr><td>" + lector["producto"].ToString() + "</td><td><strong>" + lector["hora"].ToString() + "</td><td><strong>" + lector["accion"].ToString() + "</strong></td></tr><tr>");
                        //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                    }

                }
                else
                {

                }
                Archivo.WriteLine(data1);
                Archivo.WriteLine(footer);
                Archivo.Flush();
                Archivo.Close();
                if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
                {
                    //MessageBox.Show("Abriendo");
                    Abrir(rutaReportes + archivo);
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        public void crearreportedeusuarios(string date)
        {
            string header = "<html><head><title> Reporte " + fecha + "</title><style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de Usuarios</h1>       <h4>Reporte generado el " + fecha + "</h4>          <hr>   <table>     <tr>          <th> Elemento </th>        <th> Valor </th>        </tr>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html> ";
            //getDatos();
            try
            {
                string archivo = "Usuarios-" + date + ".html";
                if (!Directory.Exists(rutaReportes))
                {
                    //MessageBox.Show("No Existe la carpeta");
                    Directory.CreateDirectory(rutaReportes);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    conexion.abrir();
                    SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM usuarios", conexion.ver());
                    Int32 count = (Int32)comm.ExecuteScalar();
                    usuariostotal = count;
                    conexion.cerrar();

                    conexion.abrir();
                    SqlCommand comm2 = new SqlCommand("SELECT SUM(preciocomprapormedida) AS Cantidad, Descripcion FROM inventario GROUP BY Descripcion", conexion.ver());
                    Int32 count2 = (Int32)comm2.ExecuteScalar();
                    int suma = count;
                    conexion.cerrar();
                    MessageBox.Show(suma.ToString());
                    string data = "<tr><td>Productos en total</td><td><strong> RD$:" + productostotal.ToString() + "</strong></td></tr><tr>";
                    Archivo.WriteLine(data);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }
                else
                {
                    //MessageBox.Show("Existe la carpeta" + archivo);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                    Int32 count = conexion.getCount("usuarios", "");
                    productostotal = count;

                    try
                    {
                        conexion.abrir();
                        DataTable dt = new DataTable();
                        string consulta = "select * from usuarios;";
                        SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                        SqlDataReader lector;
                        lector = comando.ExecuteReader();
                        foreach (DataRow dtRow in dt.Rows) ;
                        Boolean hayRegistros = lector.HasRows;
                        if (hayRegistros)
                        {
                            
                            Archivo.WriteLine(header);
                            Archivo.WriteLine("<center><table><tr><th>Usuario</th><th>Tipo de cuenta</th><th>Nombre</th><th>Apellidos</th><th>Correo</th><th>Telefono</th><th>Fecha de Nacimiento</th><th>Sexo</th><th>Comentarios</th></tr>");
                            while (lector.Read())
                            {
                                //Usuario</th><th>Tipo de cuenta</th><th>Nombre</th><th>Apellidos</th><th>Correo</th><th>Telefono</th><th>Fecha de Nacimiento</th><th>Sexo</th><th>Comentarios
                                Archivo.WriteLine("<tr><td>" + lector["usuario"].ToString() + "</td><td><strong>" + lector["tipo"].ToString() + "</strong></td><td>"+ lector["nombre"].ToString() + "</td><td>" + lector["apellidos"].ToString() + "</td><td>" + lector["correo"].ToString() + "</td><td>" + lector["telefono"].ToString() + "</td><td>" + lector["fechadenacimiento"].ToString() + "</td><td>" + lector["sexo"].ToString() + "</td><td>" + lector["comentario"].ToString() + "</td></tr><tr>");
                                //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());


                            }
                            
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        errorManager ho = new errorManager(string.Empty, ex);
                        ho.Show();
                    }
                    finally
                    {
                        conexion.cerrar();
                    }
                    string data1 = "<tr><td>Usuarios en total</td><td><strong>" + productostotal.ToString() + " Usuarios </strong></td></tr><tr>";
              
                    Archivo.WriteLine(body);
                    Archivo.WriteLine(data1);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }

            }
            catch (Exception ex) {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
            {
                //MessageBox.Show("Abriendo");
                Abrir(rutaReportes + "Inventario-" + date + ".html");
            }
        }
        public void crearreportedeventas(string date)
        {
            string header = "<html><head>    <title> Reporte " + fecha + "</title>    <style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de ventas <br>(" + riku.Properties.Settings.Default.receiptName + ")</h1>       <h4>Reporte generado el " + fecha + "</h4>          <hr>   <table>";
            // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html> ";
            //getDatos();
            try
            {
                string archivo = "Ventas-" + date + ".html";
                if (!Directory.Exists(rutaReportes))
                {
                    //MessageBox.Show("No Existe la carpeta");
                    Directory.CreateDirectory(rutaReportes);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                    Int32 count = conexion.getCount("ventas","");
                    int ventasTotal = count;

                    conexion.abrir();
                    SqlCommand comm2 = new SqlCommand("SELECT SUM(preciocomprapormedida) AS Cantidad, Descripcion FROM inventario GROUP BY Descripcion", conexion.ver());
                    Int32 count2 = (Int32)comm2.ExecuteScalar();
                    int suma = count;
                    conexion.cerrar();
                    MessageBox.Show(suma.ToString());
                    string data = "<tr><td>Ventas en total</td><td><strong> RD$:" + ventasTotal.ToString() + "</strong></td></tr><tr>";
                    Archivo.WriteLine(data);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }
                else
                {
                    //MessageBox.Show("Generando Reporte ... " + archivo);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);

                    productostotal = conexion.getCount("inventario", string.Empty);
                    conexion.cerrar();




                    double totalcomprado = 0;
                    double totalavender = 0;
                    try
                    {
                        conexion.abrir();
                        DataTable dt = new DataTable();
                        string consulta = "select * from ventas as v INNER JOIN clientes as c ON v.idcliente = c.idcliente; ";
                        SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                        SqlDataReader lector;
                        lector = comando.ExecuteReader();
                        foreach (DataRow dtRow in dt.Rows) ;
                        Boolean hayRegistros = lector.HasRows;
                        if (hayRegistros)
                        {
                            Archivo.WriteLine(header);
                            Archivo.WriteLine("<center><table><tr><th>Numero de factura</th><th>Empleado</th><th>Fecha de compra</th><th>Cliente</th><th>Tipo de venta</th><th>Total</th></tr>");
                            while (lector.Read())
                            {
                                //Archivo.WriteLine("<tr><td>" + lector["idventa"].ToString() + "</td><td><strong>" + lector["empleado"].ToString() + "<td style='color:red;'><strong>" + lector["fecha"].ToString() + " " + lector["idcliente"].ToString() + " </strong></td></strong></td><td>" + lector["tipodeventa"].ToString() + "</td><td>" + lector["elementos"].ToString() + "</td><td>" + lector["total"].ToString() + "</td></tr><tr>");
                                string cliente = lector["nombre"].ToString();
                                Archivo.WriteLine("<tr><td>"+lector["idventa"].ToString()+ "</td><td>" + lector["empleado"].ToString() + "</td><td>" + lector["fecha"].ToString() + "</td><td>" + cliente + "</td><td>" + lector["tipodeventa"].ToString() + "</td><td>" + lector["total"].ToString() + "</td></tr>");
                                //me quede trabajndo aqui
                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        errorManager ho = new errorManager(string.Empty, ex);
                        ho.Show();
                    }
                    finally
                    {
                        conexion.cerrar();
                    }
                    string data1 = "<tr><td>Total de productos vendidos </td><td><strong>" +000+ " Productos </strong></td></tr><tr>";
                    string data2 = "<tr><td>Total recaudado</td><td><strong> " + moneyFormat(getTotalSold()) + "</strong></td></tr><tr>";
                    
                    Archivo.WriteLine(body);
                    Archivo.WriteLine(data1);
                    Archivo.WriteLine(data2);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }

            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            if (conexion.yesnoDialog("Reporte Creado, ¿Desea abrirlo?"))
            {
                //MessageBox.Show("Abriendo");
                Abrir(rutaReportes + "Ventas-" + date + ".html");
            }
        }

        private string getTotalSold()
        {
            try
            {
                int total = 0;
                DataTable x = conexion.getTable("ventas",string.Empty);
                foreach (DataRow item in x.Rows)
                {
                    string strNum = purify(item[6].ToString());
                    if (strNum!="")
                    {
                        int inteado = Convert.ToInt32(strNum);
                        total += inteado;
                        //MessageBox.Show(strNum);
                    }
                }
                return total.ToString();
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
                return null;
            }
        }

        private string purify(string v)
        {
            try
            {
                char[] validNums = {'1','2'};
                char[] letras = v.ToArray();
                string finalString = string.Empty;
                foreach (char item in letras)
                {
                    if (validNums.Contains(item))
                    {
                        finalString += item;
                    }
                }
                return finalString;
            }
            catch (Exception pp)
            {
                conexion.showError(pp);
                return null;
            }
        }

        public void crearreportedeinventario(string date)
        {
            string header = "<html><head>    <title> Reporte " + fecha + "</title>    <style>h2{color: blue;}table {border-collapse: collapse;width: 80%;}hr{border: 10px solid blue;}.grad {background-image: linear-gradient(to left, rgba(255, 0, 0, 0), rgba(255, 0, 0, 1));}tr:nth-child(even) {background-image: linear-gradient(-90deg, pink, yellow);}th, td {padding: 8px;text-align: left;border-bottom: 1px solid #ddd;}</style></head>";
            string body = "<center><body><h1> Reporte de inventario <br>("+riku.Properties.Settings.Default.receiptName+")</h1>       <h4>Reporte generado el " + fecha + "</h4>          <hr>   <table>     <tr>          <th> Elemento </th>        <th> Valor </th>        </tr>";
           // string data = "  <tr><td> Dinero total pagado en compras</td>       <td><strong> RD$:50,000 </strong></td>          </tr>                  <tr>";
            string footer = "</table></center></body></html> ";
            //getDatos();
            try
            {
                string archivo = "Inventario-"+date + ".html";
                if (!Directory.Exists(rutaReportes))
                {
                    //MessageBox.Show("No Existe la carpeta");
                    Directory.CreateDirectory(rutaReportes);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);
                    Archivo.WriteLine(header);
                    Archivo.WriteLine(body);
                            conexion.abrir();
                            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM inventario", conexion.ver());
                            Int32 count = (Int32)comm.ExecuteScalar();
                            productostotal = count;
                            conexion.cerrar();

                            conexion.abrir();
                            SqlCommand comm2 = new SqlCommand("SELECT SUM(preciocomprapormedida) AS Cantidad, Descripcion FROM inventario GROUP BY Descripcion", conexion.ver());
                            Int32 count2 = (Int32)comm2.ExecuteScalar();
                            int suma = count;
                            conexion.cerrar();
                    MessageBox.Show(suma.ToString());
                    string data = "<tr><td>Productos en total</td><td><strong> RD$:"+productostotal.ToString()+"</strong></td></tr><tr>";
                    Archivo.WriteLine(data);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }
                else
                {
                    //MessageBox.Show("Generando Reporte ... " + archivo);
                    StreamWriter Archivo = new StreamWriter(rutaReportes + archivo);

                        productostotal = conexion.getCount("inventario",string.Empty);
                        conexion.cerrar();



                    
                    double totalcomprado = 0;
                    double totalavender = 0;
                    try
                    {
                        conexion.abrir();
                        DataTable dt = new DataTable();
                        string consulta = "select * from inventario;";
                        SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                        SqlDataReader lector;
                        lector = comando.ExecuteReader();
                        foreach (DataRow dtRow in dt.Rows) ;
                        Boolean hayRegistros = lector.HasRows;
                        if (hayRegistros)
                        {
                            Archivo.WriteLine(header);
                            Archivo.WriteLine("<center><table><tr><th>Producto</th><th>Fecha de Compra</th><th>Cantidad Existente</th></tr>");
                            while (lector.Read())
                            {
                                Archivo.WriteLine("<tr><td>"+ lector["nombredeproducto"].ToString() + "</td><td><strong>" + lector["fechadecompra"].ToString() + "<td style='color:red;'><strong>" + lector["medida"].ToString() + " " + lector["unidaddemedida"].ToString() + " </strong></td></strong></td></tr><tr>");
                                string unidadesx = lector["medida"].ToString();
                                double canti = (double.Parse(unidadesx, CultureInfo.InvariantCulture));
                                //double precioventaxmedida = Convert.ToDouble(lector["precioventapormedida"].ToString());
                                string pvpm = lector["precioventapormedida"].ToString();
                                double precioventaxmedida = (double.Parse(pvpm, CultureInfo.InvariantCulture));
                                string pcpm = lector["preciocomprapormedida"].ToString();
                                double preciocompraxmedida = (double.Parse(pcpm, CultureInfo.InvariantCulture));
                                double cuantity = Convert.ToDouble(preciocompraxmedida) * Convert.ToDouble(unidadesx);
                                double calculo1 = preciocompraxmedida * canti;
                                double calculo2 = precioventaxmedida * canti;
                                totalcomprado = totalcomprado + calculo1;
                                totalavender = totalavender + calculo2;

                                // MessageBox.Show("cantidad: "+ precioventaxmedida);
                                //.value

                                /*
                               //Archivo.WriteLine("<br>"+lector["nombredeproducto"].ToString());
                                double preciocompraporunidad = Convert.ToDouble(lector["preciocomprapormedida"].ToString());
                                double unidades = Convert.ToDouble(lector["medida"].ToString());
                                double precioventaporunidad = Convert.ToDouble(lector["precioventapormedida"].ToString());
                                cantidad = Convert.ToDouble(preciocompraporunidad * unidades);
                                cantidad2 = Convert.ToDouble(precioventaporunidad * unidades);
                                totalcomprado = totalcomprado + cantidad;
                                totalavender = totalavender + cantidad2;
                                //MessageBox.Show("Nuevo valor: "+cantidad.ToString()+"Total: "+total.ToString());
                                */
                            }

                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        errorManager ho = new errorManager(string.Empty, ex);
                        ho.Show();
                    }
                    finally
                    {
                        conexion.cerrar();
                    }                    
                    string data1 = "<tr><td>Productos en total</td><td><strong>" + productostotal.ToString() + " Productos </strong></td></tr><tr>";
                    string data2 = "<tr><td>Capital en compras</td><td><strong> " + moneyFormat(totalcomprado.ToString().Replace(',','.')) + "</strong></td></tr><tr>";
                    string data3 = "<tr><td>Capital a recaudar</td><td><strong> " + moneyFormat(totalavender.ToString().Replace(',', '.')) + "</strong></td></tr><tr>";
                    string data4 = "<tr><td>Ganancias en inventario</td><td><strong> " + moneyFormat((totalavender - totalcomprado).ToString().Replace(',', '.')) + "</strong></td></tr><tr>";
                    
                    Archivo.WriteLine(body);
                    Archivo.WriteLine(data1);
                    Archivo.WriteLine(data2);
                    Archivo.WriteLine(data3);
                    Archivo.WriteLine(data4);
                    Archivo.WriteLine(footer);
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(rutaReportes + archivo);
                    div.WriteLine("<center>------------------------------------------------<br>FIN DEL REPORTE</center>");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(rutaReportes + archivo);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }

            }
            catch (Exception ex) {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
            if (MessageBox.Show("Reporte Creado, ¿Desea abrirlo?", "Hecho", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                //MessageBox.Show("Abriendo");
                Abrir(rutaReportes+ "Inventario-" + date + ".html");
            }
        }

        public string moneyFormat(string amount)
        {
            amount = amount.Replace("RD$:","");
            decimal moneyvalue = decimal.Parse(amount);
            string h = moneyvalue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            return "RD"+h;
        }
        public void Abrir(string file)
        {
            try
            {
                System.Diagnostics.Process.Start(file);
                conexion.inform("Se ha cargado el reporte, al salir del sistema lo encontrara en el navegador");
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }  
        }


        public void eliminar(string file)
        {
            try
            {
                File.Delete(file);
                conexion.inform("Elemento Eliminado");
            }
            catch (Exception ex)
            {
                conexion.showError(ex);
            }
        }

        public void installErrors()
        {
            if (!Directory.Exists(rutaErrors))
            {
                Directory.CreateDirectory(rutaErrors);
            }
            if (!File.Exists(rutaErrors + fileError))
            {
                File.Create(rutaErrors + fileError);
                //errores
                string[] err = {
                "-23334",
                "-error buscando los datos",
                "-Ford",
                "-pokintol" };
                //escribir errores

                StreamWriter Archivo = new StreamWriter(rutaErrors + fileError);
                foreach (string item in err)
                {
                    Archivo.WriteLine(item);
                }

                Archivo.Flush();
                Archivo.Close();
                StreamWriter div = File.AppendText(rutaErrors + fileError);
                div.WriteLine("------------------------------------------------");
                div.Close();
                StreamWriter WriteReportFile = File.AppendText(rutaErrors + fileError);
                //WriteReportFile.WriteLine(linea);
                WriteReportFile.Close();
            }
           
        }

        public void instalar()
        {
            try
            {

                //string linea = "[" + fecha + "] [Usuario: " + usr + "] [Clave: " + pass.Length + " caracteres] [Acceso: " + acc + "]";
               
                
                // installErrors();


                if (!Directory.Exists(ruta))
                {
                   // MessageBox.Show("No Existe la carpeta");
                    Directory.CreateDirectory(ruta);
                    StreamWriter Archivo = new StreamWriter(ruta + filex);
                    Archivo.WriteLine("                   SISTEMA DE DEPURACION INTERNA DE RIKU V1.0");
                    Archivo.Flush();
                    Archivo.Close();
                    StreamWriter div = File.AppendText(ruta + filex);
                    div.WriteLine("------------------------------------------------");
                    div.Close();
                    StreamWriter WriteReportFile = File.AppendText(ruta + filex);
                    //WriteReportFile.WriteLine(linea);
                    WriteReportFile.Close();
                }
                else
                {
                    if (File.Exists(ruta + filex))
                    {
                       // MessageBox.Show("Existe");
                        StreamWriter WriteReportFile = File.AppendText(ruta + filex);
                       // WriteReportFile.WriteLine(linea);
                        WriteReportFile.Close();
                    }
                    else
                    {
                       // MessageBox.Show("No Existe el archivo");
                        StreamWriter Archivo = new StreamWriter(ruta + filex);
                        Archivo.WriteLine("SISTEMA DE DEPURACION INTERNA DE RIKU V1.0");
                        Archivo.Flush();
                        Archivo.Close();
                        StreamWriter div = File.AppendText(ruta + filex);
                        div.WriteLine("------------------------------------------------");
                        div.Close();
                        StreamWriter WriteReportFile = File.AppendText(ruta + filex);
                       // WriteReportFile.WriteLine(linea);
                        WriteReportFile.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
        }
    }
}
