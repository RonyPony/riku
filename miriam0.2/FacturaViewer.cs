using riku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace miriam0._2
{
    public partial class FacturaViewer : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;
        string factura;
        string divisor = "=================================";
        string divisorb = "________________________________";

        public FacturaViewer(string uusuario,string id)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
            factura = id;
            generar(factura);
        }

        public void generar(string id)
        {
            string hr = "\n";
            
            string businessName = riku.Properties.Settings.Default.receiptName;
            string linea1 = businessName;
            string linea2 = "Factura numero "+id;
            data.AppendText(linea1.ToUpper());
            data.AppendText(hr);
            data.AppendText("‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾");
            data.AppendText(hr);
            data.AppendText(hr);
            data.AppendText(linea2);
            data.AppendText(hr);
            data.AppendText(hr);
            data.AppendText(hr);
            data.AppendText(divisor);
            data.AppendText(hr);
            data.AppendText("  Producto | Cantidad | Precio");
            data.AppendText(hr);
            data.AppendText(divisor);
            data.AppendText(hr);

            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from facturas where idventa = '" + id + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    foreach (IDataRecord elemento in lector)
                    {
                        //MessageBox.Show(lector["producto"].ToString());
                        string producto = lector["producto"].ToString().Substring(0, Math.Min(13, lector["producto"].ToString().Length));
                        if (producto.Length <13)
                        {
                            producto += multiSpace(13-producto.Length);
                        }
                        var prod = producto+ "      "+lector["cantidad"].ToString();
                        data.AppendText(hr);
                        data.AppendText(prod+"    "+ log.moneyFormat(lector["subtotal"].ToString()));
                        data.AppendText(hr);
                       // txtid.Text = dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString();
                       // txtnombre.Text = lector["nombredeproducto"].ToString().ToUpper();
                    }
                    data.AppendText(hr);
                    lector.Close();
                    conexion.cerrar();
                    getTotal(id);
                }
            }
            catch (Exception ex) {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }


        }

        private string multiSpace(int v)
        {
            string space = string.Empty;
            for (int i = 0; i < v; i++)
            {
                space += " ";
            }
            return space;
        }

        public string getTotal(string id)
        {
            conexion.abrir();
            string ttl = log.moneyFormat("0");
            DataTable tabladedatos = new DataTable();
            string query = "select * from ventas where idventa = '" + id + "';";
            SqlCommand komand = new SqlCommand(query, conexion.ver());
            SqlDataReader reader;
            reader = komand.ExecuteReader();
            Boolean hay = reader.HasRows;
            if (hay)
            {
                while (reader.Read())
                {
                    ttl = log.moneyFormat(reader["total"].ToString());
                }
                
            }
            else
            {

            }
            return ttl;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FacturaViewer_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario,"Se abrio la factura numero "+factura);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //a trabajar mas luego
           
            string s = data.Text;
            imprimir();            
        }

        public string StringLimit(string str, int limit, bool AlingLeft)
        {
            string Ans = string.Empty;


            if (str.Length < limit)
            {
                if (AlingLeft)
                {
                    Ans = str + multiSpace(limit - str.Length);
                }
                else
                {
                    Ans = multiSpace(limit - str.Length) + str;
                }
            }
            else if (str.Length > limit)
            {
                Ans = str.Substring(0, limit);
            }
            else if (str.Length == limit)
            {
                Ans = str;
            }
            return Ans;
        }

        public void imprimir()
        {
            string businessName = riku.Properties.Settings.Default.receiptName;
            string footercustom = riku.Properties.Settings.Default.customReceiptFooter;
            string company = StringLimit(businessName, 32, true);
            string linea2 = "Factura numero " + factura;
            string receiptString = "==================================\n" +
                                   "|" + company + "|\n" +
                                   "==================================\n" +
                                   "Factura No."+ StringLimit(factura, 32, true) + "\n" +
                                   "                                  \n" +
                                   "----------------------------------\n" +
                                   "Item          Cant.         Precio\n" +
                                   "----------------------------------\n";
            
            string footer =        "----------------------------------\n" +
                                   "Total                   "+getTotal(factura)+"\n";

            string customFooter = "----------------------------------\n "+
                                  "Le atendió: " + getUser() + "\n \n \n" + footercustom;


            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from facturas where idventa = '" + factura + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    foreach (IDataRecord elemento in lector)
                    {
                        //MessageBox.Show(lector["producto"].ToString());
                        string producto = lector["producto"].ToString().Substring(0, Math.Min(10, lector["producto"].ToString().Length));
                        if (producto.Length < 13)
                        {
                            producto += multiSpace(10 - producto.Length);
                        }
                        var prod = producto + "      " + lector["cantidad"].ToString();
                        receiptString+= prod+multiSpace(10)+ log.moneyFormat(lector["subtotal"].ToString())+ "\n";
                        // txtid.Text = dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString();
                        // txtnombre.Text = lector["nombredeproducto"].ToString().ToUpper();
                    }
                    lector.Close();
                    conexion.cerrar();
                    
                    receiptString += footer;
                    receiptString += customFooter;
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

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(receiptString, new Font("OCR A Extended", 10), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                if (true)
                {
                    p.Print();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        public string getUser()
        {
            List<string> userinfo = conexion.getUserInfo(conexion.getIdUsuario(usuario));
            return userinfo[4]+" "+userinfo[4];
        }
    }
}
