using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using riku;

namespace miriam0._2
{
    public partial class inventario : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        int productostotal = 30;
        string suplidor = "[*********]";
        int totalComprado = 0;
        string peso = "RD$:";
        string selected = "[-]";
        string generaluser;
        string tipo;
        string usuario;

        public inventario(string uusuario)
        {
            InitializeComponent();
            this.Text = "Inventario ["+usuario+"]";
            txtusuario.Text = "Usuario: ["+usuario+"]";
            generaluser = usuario;
            usuario = uusuario;
        }
        public void actualizarEstadisticas()
        {            
            getTotal();
            txt_totalproductosactual.Text = productostotal.ToString();

            log.notificacion(usuario,"Se han actualizado los conteos ");
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Seleccionar") { conexion.inform("Primero seleccione un criterio de busqueda"); }
                else
                {
                    string texto = text.Text;
                    string colu = comboBox1.Text;
                    string query = "SELECT * FROM inventario WHERE " + colu + " LIKE '%" + texto + "%';";
                    conexion.abrir();
                    SqlCommand cmd = new SqlCommand(query, conexion.ver());
                    
                    cmd.ExecuteNonQuery();
                    conexion.cerrar();
                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    dt.Fill(tb);
                    dtgconsulta.DataSource = tb;
                    
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

            /*
                try
                {
                    if (comboBox1.Text == "Seleccionar") { MessageBox.Show("Primero seleccione un criterio de busqueda"); }
                    else
                    {
                        foreach (DataGridViewRow Row in dtgconsulta.Rows)
                        {

                            string strFila = Row.Index.ToString();
                            string Valor = Convert.ToString(Row.Cells[comboBox1.Text].Value);
                            //MessageBox.Show(Valor);
                            if (Valor == this.text.Text)
                            {
                                dtgconsulta.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Green;
                                dtgconsulta.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                dtgconsulta.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }  
                }
                catch (Exception exp) {
                    MessageBox.Show(exp.ToString());
                }

            */
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            log.notificacion(generaluser, "Inventario cargado.");
            cargar();
            getmes();
            actualizarEstadisticas();
        }

        public void getmes()
        {
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("MM");
            radioButton2.Text = "Este mes ("+fecha_actual+")";
            //label12.Text = "Se muestran resultados solo del mes " + fecha_actual;
        }

        public void getTotal()
        {
                try {                
                productostotal = conexion.getCount("inventario",string.Empty);
                }catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        
        }

        public void markRed()
        {
            try
            {
                foreach (DataGridViewRow fila in dtgconsulta.Rows)
                {
                    int existente = int.Parse(fila.Cells[3].Value.ToString());

                    if (existente == 0)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Red;
                        fila.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cargar()
        {
            try
            {
                conexion.abrir();
                //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                string comando = "select * from inventario";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dtgconsulta.DataSource = table;
                conexion.cerrar();
                getTotal();                
                label24.Text = productostotal.ToString() + " productos en total";
                markRed();
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

        public void updateWarning(string mensaje) {
            label12.Text = mensaje;
        }
        

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                groupBox1.Enabled = true;
                string mensaje = "Se muestran resultados solo comprado en fechas entre " + dateTimePicker1.Text+" y "+dateTimePicker2.Text;
                updateWarning(mensaje);
            } else {
                groupBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) {
                DateTime Hoy = DateTime.Today;
                string fecha_actual = Hoy.ToString("MM");
                string mensaje ="Se muestran resultados solo del mes " + fecha_actual;
                updateWarning(mensaje);
                try
                {
                    conexion.abrir();
                    //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                    string comando = "select * from inventario where fechadecompra = ";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                    dtgconsulta.DataSource = table;
                    conexion.cerrar();
                    getTotal();
                    label24.Text = productostotal.ToString() + " productos en total";
                }
                catch (Exception)
                {

                    throw;
                }
               

                
            }
            else {
               
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string mensaje = "Se muestran resultados solo comprado en fechas entre " + dateTimePicker1.Text + " y " + dateTimePicker2.Text;
            updateWarning(mensaje);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string mensaje = "Se muestran resultados solo comprado en fechas entre " + dateTimePicker1.Text + " y " + dateTimePicker2.Text;
            updateWarning(mensaje);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                groupBox4.Enabled = true;
                
            }
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        public void getSuplidor()
        {
            if (textBox1.Text == "")
            {
                cargar();
            }
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from suplidores where idsuplidor = '" + textBox1.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    textBox1.BackColor = Color.Green;
                   // conexion.abrir();
                    while (lector.Read())
                    {
                        //conexion.cerrar();
                        
                        label25.Text = lector["nombre"].ToString().ToUpper();
                        suplidor = lector["nombre"].ToString().ToUpper();
                        string mensaje = "Se muestran resultados solo comprados a " + suplidor;
                        updateWarning(mensaje);
                        //buscarporsuplidor();
                        //MessageBox.Show(lector["nombre"].ToString());                        
                    }
                    try
                    {
                        string supli = textBox1.Text;
                        string query = "SELECT * FROM inventario WHERE idsuplidor = '" + supli + "';";
                        SqlCommand cmd = new SqlCommand(query, conexion.ver());
                        // conexion.cerrar();
                        //onexion.abrir();
                        comando.Dispose();
                        lector.Close();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter dt2 = new SqlDataAdapter(cmd);
                        DataTable tb = new DataTable();
                        dt2.Fill(tb);
                        dtgconsulta.DataSource = tb;
                        //conexion.cerrar();

                    }
                    catch (Exception ex)
                    {
                        errorManager ho = new errorManager(string.Empty, ex);
                        ho.Show();
                    }
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                    label25.Text = "[Incorrecto]";
                    updateWarning("");
                }
                if (textBox1.Text == "") { textBox1.BackColor = Color.White;label25.Text = "--------------"; updateWarning("");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getSuplidor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizarEstadisticas();
            cargar();
            updateWarning("[-]");
        }

        private void dtgconsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //   string str = DataGridView1.Rows[DataGridView.SelectedRows[0].Index].Cells[X].Value.ToString();
         
        }

        static int f(int x)
        {
            return x * x;
        }

        static string getTotalVendido(string producto)
        {
            cnn conexion = new cnn();
            try
            {
               // MessageBox.Show(producto);
                conexion.abrir();
                string query = "SELECT COUNT(*) FROM facturas where producto = '" + producto + "'";
                SqlCommand comm = new SqlCommand(query,conexion.ver());
                //Int32 count = (Int32)comm.ExecuteScalar();
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                int vendidos = count;
                return vendidos.ToString();
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
                return "/0/";
            }
            finally
            {
                conexion.cerrar();
            }

        }

        public void enviaralpanel()
        {
            try
            {
                txtedittitulo.Text = "Editar " + dtgconsulta.CurrentRow.Cells["nombredeproducto"].Value.ToString() + "]";
                conexion.abrir();
                DataTable dt = new DataTable();
                int id = Convert.ToInt32(dtgconsulta.CurrentRow.Cells["Idproducto"].Value.ToString());
                txtid.Text = id.ToString();
                string consulta = "select * from inventario where idproducto = '" + dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    while (lector.Read())
                    {
                        txtid.Text = dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString();
                        txtnombre.Text = lector["nombredeproducto"].ToString().ToUpper();
                        txtcantitad2.Text = lector["medida"].ToString();
                        txtmarca.Text = lector["marca"].ToString().ToUpper();
                        txtidsupli.Text = lector["idsuplidor"].ToString();
                        txtfecha.Text = lector["fechadecompra"].ToString();
                        string x = lector["precioventa"].ToString();
                        var venta = Decimal.Parse(x,NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                        txtventa.Text = lector["precioventa"].ToString();
                        txtunidaddemedida.Text = lector["unidaddemedida"].ToString().ToUpper();
                        txtuni.Text = lector["unidaddemedida"].ToString().ToUpper();
                        label20.Text = "Precio de compra (" + lector["unidaddemedida"].ToString()+")";
                        string prcompra = lector["preciocomprapormedida"].ToString();
                        var preciodecompraX = Decimal.Parse(prcompra, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                        preciodecompra.Text = lector["preciocomprapormedida"].ToString();
                        label26.Text = "Precio de venta (" + lector["unidaddemedida"].ToString() + ")";
                        preciodeventa.Text = lector["precioventapormedida"].ToString();
                        txtitbis.Text = "N/A";
                        txtdescripcion.Text = lector["descripcion"].ToString().ToUpper();
                        
                    }
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

        public void getSupli()
        {
            try
            {
                conexion.abrir();
                DataTable table = new DataTable();
                string id = dtgconsulta.CurrentRow.Cells["idsuplidor"].Value.ToString();
                string query = "select nombre from suplidores where idsuplidor=" + Convert.ToInt32(id) + ";";
                SqlCommand komando = new SqlCommand(query, conexion.ver());
                SqlDataReader reader;
                reader = komando.ExecuteReader();
                foreach (DataRow dtRow in table.Rows) ;
                Boolean hay = reader.HasRows;
                //MessageBox.Show(id);
                //MessageBox.Show(reader["nombre"].ToString());
                if (hay)
                {
                    while (reader.Read())
                    {
                        txtsupli.Text = reader["nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("ERROR cargando los suplidores, quiere ver detalles del error?", "Ups!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) { MessageBox.Show(ex.ToString()); }

            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void dtgconsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getSupli();
            enviaralpanel();
            acciones.Enabled = true;

            try
            {
                groupBox3.Text = "Estadisticas individuales de "+dtgconsulta.CurrentRow.Cells["nombredeproducto"].Value.ToString();

                string precioUnidad = dtgconsulta.CurrentRow.Cells["preciocomprapormedida"].Value.ToString();

                string unidades = Convert.ToString(dtgconsulta.CurrentRow.Cells["medida"].Value);

                string unidaddemedida = dtgconsulta.CurrentRow.Cells["unidaddemedida"].Value.ToString();

                string idproductotxt = dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString();

                selected = dtgconsulta.CurrentRow.Cells["idproducto"].Value.ToString();

                int idproducto = Convert.ToInt32(dtgconsulta.CurrentRow.Cells["idproducto"].Value);

                // Double preciocomprapormedida = Convert.ToDouble(dtgconsulta.CurrentRow.Cells["preciocomprapormedida"].Value);

                Decimal preciocomprapormedida = decimal.Parse(dtgconsulta.CurrentRow.Cells["preciocomprapormedida"].Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);

                Decimal precioventapormedida = decimal.Parse(dtgconsulta.CurrentRow.Cells["precioventapormedida"].Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);

                Decimal enexistencia = decimal.Parse(dtgconsulta.CurrentRow.Cells["medida"].Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);

                // Double precioventapormedida = Convert.ToDouble(dtgconsulta.CurrentRow.Cells["precioventapormedida"].ToString());

                //  Double a = Convert.ToDouble(precioUnidad);

                Double a = (double.Parse(precioUnidad, CultureInfo.InvariantCulture));

                Double b = (double.Parse(unidades, CultureInfo.InvariantCulture));

                Double total = a*b;

                //if (b==1) { total = a * b; } else { total = a * b / 10; }
                //if (a == 1) { total = a * b; } else { total = a * b / 10; }
                //MessageBox.Show(total.ToString());

                txt_preciototaldelacompra.Text = precioUnidad+"X"+unidades+"="+peso+total;

                label15.Text = unidaddemedida + " Vendidas";

                txt_unidadesvendidas.Text = peso+"--";

                string vendido = getTotalVendido(dtgconsulta.CurrentRow.Cells["nombredeproducto"].Value.ToString()+" "+ dtgconsulta.CurrentRow.Cells["marca"].Value.ToString());

                txt_totalvendido.Text = vendido.ToString();

                label19.Text = "Ganancias por "+ unidaddemedida;               

                Double gananciasxunidades = Convert.ToDouble(precioventapormedida- preciocomprapormedida);

                Double existente = Convert.ToDouble(enexistencia);

               // MessageBox.Show(precioventapormedida + "-" + preciocomprapormedida + "="+gananciasxunidades);

                //MessageBox.Show( precioventapormedida.ToString()+ "-" +preciocomprapormedida.ToString()+"="+ gananciasxunidades.ToString());

                txt_gananciasporunidades.Text = gananciasxunidades.ToString();

                btneliminar.Text = "["+selected+"]";
                gananciastotales.Text = (gananciasxunidades * existente).ToString();
            }
            catch (Exception ex) {
                errorManager ho = new errorManager(string.Empty,ex);
                ho.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (conexion.getCount("inventario",string.Empty) >= 1)
                {
                    if (MessageBox.Show("Estas seguro que desea elimnar " + dtgconsulta.CurrentRow.Cells["nombredeproducto"].Value.ToString().ToUpper() + " de manera permanente del inventario?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        conexion.abrir();
                        string consulta = "delete from inventario where idproducto= '" + selected + "';";
                        SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                        comando.ExecuteNonQuery();

                        conexion.inform("Elemento eliminado");
                    }
                }
                else
                {
                    errorManager aviso = new errorManager("info",new Exception("Aun no hay productos, debe existir un minimo de (1) producto."));
                    aviso.Show();
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
                cargar();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarainventario aa = new agregarainventario(generaluser);
            aa.MdiParent = this.ParentForm;
            aa.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarSuplidor ss = new consultarSuplidor(generaluser);
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Modificar Producto")
            {
                panelModificar.Enabled = true;
                button3.Text = "Guardar Cambios";
            }
            else if(button3.Text == "Guardar Cambios")
            {
                enviar();
                panelModificar.Enabled = false;
                button3.Text = "Modificar Producto";
            }

        }

        public void enviar()
        {
            try
            {
                string id = txtid.Text;
                string nombre = txtnombre.Text;
                string marca = txtmarca.Text;
                string unidaddemedida;

                if (txtunidaddemedida.Text == "Otra...")
                {
                    unidaddemedida = txtotramedida.Text;
                }
                else
                {
                    unidaddemedida = txtunidaddemedida.Text;
                }

                //decimal cantidadexistente = decimal.Parse(txtcantitad2.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                string cantidadexistente = txtcantitad2.Text;          
                string preciocompra = preciodecompra.Text;
                string precioventa = preciodeventa.Text;
                string precioentero = txtventa.Text;
                int idsuplidor = Convert.ToInt32(txtidsupli.Text);
                string fecha = txtfecha.Text;
                string descripcion = txtdescripcion.Text;
                conexion.abrir();
                string query = "update inventario set nombredeproducto = '" + nombre + "',marca ='" + marca + "'" +
                    ",medida='" + cantidadexistente + "',preciocomprapormedida='" + preciocompra + "'," +
                    "precioventa='" + precioentero + "',idsuplidor='" + idsuplidor + "'," +
                    "precioventapormedida='" + precioventa + "',descripcion='" + descripcion + "'," +
                    "unidaddemedida='" + unidaddemedida + "',fechadecompra='" + fecha + "'" +
                    " where Idproducto='" + txtid.Text+"';";
                SqlCommand comando = new SqlCommand(query, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();
                cargar();
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarSuplidor cc = new consultarSuplidor(generaluser);
            cc.Show();
        }

        private void txtidsupli_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.abrir();
                DataTable table = new DataTable();
                string id = txtidsupli.Text;
                string query = "select nombre from suplidores where idsuplidor=" + Convert.ToInt32(id) + ";";
                SqlCommand komando = new SqlCommand(query, conexion.ver());
                SqlDataReader reader;
                reader = komando.ExecuteReader();
                foreach (DataRow dtRow in table.Rows) ;
                Boolean hay = reader.HasRows;
                //MessageBox.Show(id);
                //MessageBox.Show(reader["nombre"].ToString());
                if (hay)
                {
                    while (reader.Read())
                    {
                        txtsupli.Text = reader["nombre"].ToString();
                    }
                }
                conexion.cerrar();
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

        private void txtunidaddemedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtunidaddemedida.Text == "Otra...")
            {
                txtotramedida.Enabled = true;
            }
            else
            {
                txtotramedida.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            salidadeinventario ss = new salidadeinventario(generaluser);
            ss.MdiParent = this.ParentForm;
            ss.Show();
        }

        private void txt_unidadesvendidas_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            calculadora cc = new calculadora(generaluser);
            cc.MdiParent = this.ParentForm;
            cc.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conversor cv = new conversor(generaluser);
            cv.MdiParent = this.ParentForm;
            cv.Show();
        }

        private void txt_preciototaldelacompra_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Estas seguro de cerrar el inventario ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
                this.Close();
            //}
        }

        private void btneliminar_MouseEnter(object sender, EventArgs e)
        {
            label35.Text = "Eliminar producto";
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            label35.Text = "Agregar producto";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            label35.Text = "Salida de producto";
        }
    }
}
