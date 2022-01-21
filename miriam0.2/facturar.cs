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
using riku.Models;

namespace miriam0._2
{
    public partial class facturar : Form
    {
        cnn conexion = new cnn();
        log log = new log();
        string usuario;
        string tipo;
        int productosTotal;
        string peso = "RD$:";
        string unidaddemedida;
        double descuentoT = 0;
        int calculofinal = 0;
        double descFinal = 0;

        public facturar(string uusuario)
        {
            InitializeComponent();
            usuario = uusuario;
            tipo = conexion.getTipo(usuario);
            this.Text = "Facturar ["+uusuario+"] ["+tipo+"]";
        }

        private void facturar_Load(object sender, EventArgs e)
        {
            log.notificacion(usuario, "Facturar cargado.");
            cargarProductos();
            generar();
            
        }

       
        public void markRed()
        {
            try
            {
                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    int existente = int.Parse(fila.Cells[3].Value.ToString());

                    if (existente == 0)
                    {
                        fila.DefaultCellStyle.BackColor = Color.Red;
                        fila.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                log.errorLog(usuario, "Error marcando los productos sin existencia en inventario");
            }
        }
        public void cargarProductos()
        {
            try
            {
                conexion.abrir();
                //string comando = "select idProducto,descripcion,tamaño,referencia,marca,garantia,gananciaxUnidad,precioCompra,precioVenta,nombreSuplidor,cantidad,total,tipoArticulo,tipoCompra,nombreProducto from compraSuplidores";
                string comando = "select idproducto,nombredeproducto,marca,precioventa,medida from inventario";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conexion.ver());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                dataGridView2.DataSource = table;
                conexion.cerrar();
                productosTotal = conexion.getCount("inventario",string.Empty);
                totalpro.Text = productosTotal.ToString() + " productos en total";
                markRed();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + Convert.ToString(ex));
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public void generar()
        {
            Random rd = new Random();
            string numero = rd.Next(0, 99999).ToString();
            idventayfac.Text = numero;
            verificarID();
        }

        public void verificarID()
        {
            try
            {
                
                string consulta = "select * from ventas where idventa = '" + idventayfac.Text + "';";
                
                int count = conexion.getCount("ventas", "idventa = '" + idventayfac.Text + "'");
                
                
                //Boolean hayRegistros = lector.HasRows;
                if (count>=1)
                {
                    generar();
                }
                else
                {

                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            generar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (txtprecioporuni.Text != "" && txtcantidad.Text != "")
            {
                int precio = Convert.ToInt32(txtprecioporuni.Text);
                int cantidad = Convert.ToInt32(txtcantidad.Text);
                int res = (precio * cantidad);
                txtsubtotal.Text = res.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            buscarProducto();
        }

        public void buscarProducto()
        {
            try
            {
                if (comboBox2.Text == "") { MessageBox.Show("Seleccione un metodo de busqueda."); }
                else
                {
                    string texto = text.Text;
                    string colu = comboBox2.Text;
                    string query = "SELECT idproducto,nombredeproducto,marca,precioventa FROM inventario WHERE " + colu + " LIKE '%" + texto + "%';";
                    SqlCommand cmd = new SqlCommand(query, conexion.ver());
                    conexion.abrir();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    dt.Fill(tb);
                    dataGridView2.DataSource = tb;
                    conexion.cerrar();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            buscarProducto();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtunidaddemedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = "Precio por " + txtunidaddemedida.Text;
            //MessageBox.Show(unidaddemedida);
        }

        private void txtunidaddemedida_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtunidaddemedida.Text == "Otra...")
            {
                txtotramedida.Enabled = true;
                label9.Text = "Precio por ...";
            }
            else {
                txtotramedida.Enabled = false;
            }
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            try {
                if (txtcantidad.Text != "")
                {
                    double precio = (double.Parse(txtprecioporuni.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtprecioporuni.Text);
                    double kntidad = (double.Parse(txtcantidad.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtcantidad.Text);

                    double resultado = (precio * kntidad);
                    txtsubtotal.Text = peso + resultado;
                    calcularDescuento();
                }
                else
                {
                    txtsubtotal.Text = peso + "0.00";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(v.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conversor cn = new conversor(usuario);
            cn.MdiParent = this.ParentForm;
            cn.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarCliente cc = new consultarCliente(usuario);
            cc.MdiParent = this.ParentForm;
            cc.Show();
        }

        private void txtunidaddemedida_TextChanged(object sender, EventArgs e)
        {
            label9.Text = "Precio por " + unidaddemedida;
        }

        private void txtotramedida_TextChanged(object sender, EventArgs e)
        {
            label9.Text = "Precio por " + txtotramedida.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            stepOne();
        }

        public void stepOne()
        {
            try
            {
                groupBox3.Text = "Producto [" + dataGridView2.CurrentRow.Cells["nombredeproducto"].Value.ToString() + "]";
                conexion.abrir();
                DataTable dt = new DataTable();
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["idproducto"].Value.ToString());
                //MessageBox.Show(id.ToString());
                string consulta = "select * from inventario where idproducto = '" + dataGridView2.CurrentRow.Cells["idproducto"].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    while (lector.Read())
                    {
                        if (lector["medida"].ToString() == "0")
                        {
                            MessageBox.Show("Este producto esta agotado", "Elemento Sin Existencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        txtid.Text = dataGridView2.CurrentRow.Cells["idproducto"].Value.ToString();
                        txtnombre.Text = lector["nombredeproducto"].ToString().ToUpper();
                        txtmarca.Text = lector["marca"].ToString().ToUpper();
                        txtunidaddemedida.Text = lector["unidaddemedida"].ToString().ToUpper();
                        label9.Text = "Precio por " + lector["unidaddemedida"].ToString();
                        unidaddemedida = lector["unidaddemedida"].ToString();
                        txtprecioporuni.Text = lector["precioventapormedida"].ToString();
                        //txtprecioc.Text = lector["precioventapormedida"].ToString();
                        txtitbis.Text = "N/A";
                        txtdescripcion.Text = lector["descripcion"].ToString().ToUpper() + "       (" + lector["medida"].ToString() + ") Disponibles";
                        // string precioUnidad = dtgconsulta.CurrentRow.Cells["preciocomprapormedida"].Value.ToString();

                        /*int idproducto = Convert.ToInt32(dtgconsulta.CurrentRow.Cells["idproducto"].Value);
                        int preciocomprapormedida = Convert.ToInt32(dtgconsulta.CurrentRow.Cells["preciocomprapormedida"].Value);
                        int precioventapormedida = Convert.ToInt32(dtgconsulta.CurrentRow.Cells["precioventapormedida"].Value);
                        int a = Convert.ToInt32(precioUnidad);
                        int b = Convert.ToInt32(unidades);
                        int total = a * b;
                        txt_preciototaldelacompra.Text = precioUnidad + " X " + unidades + " = " + peso + total;
                        label15.Text = unidaddemedida + " Vendidas";
                        txt_unidadesvendidas.Text = peso + "--";
                        int vendido = getTotalVendido(idproducto);
                        txt_totalvendido.Text = vendido.ToString();
                        label19.Text = "Ganancias por " + unidaddemedida;
                        int gananciasxunidades = (precioventapormedida - preciocomprapormedida);
                        //MessageBox.Show( precioventapormedida.ToString()+ "-" +preciocomprapormedida.ToString()+"="+ gananciasxunidades.ToString());
                        txt_gananciasporunidades.Text = gananciasxunidades.ToString();
                       */
                    }
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show("ERROR " + x.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcantidad.Text == "0" || txtcantidad.Text == "")
                {
                    MessageBox.Show("No puedes agregar un producto con cero cantidad, ingrese al menos 1 producto", "Elemento Sin Canidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string producto = txtnombre.Text + " " + txtmarca.Text;
                string id = txtid.Text;
                string unidaddemedida;
                if (txtunidaddemedida.Text == "Otra...")
                {
                    unidaddemedida = txtotramedida.Text;
                }
                else
                {
                    unidaddemedida = txtunidaddemedida.Text;
                }
                string precio = peso + txtprecioporuni.Text + "/" + unidaddemedida;                
                string cantidad = txtcantidad.Text;
                double descuent = descuentoT;
                string subtotal2 = txtsubtotal.Text;
                string resultString = System.Text.RegularExpressions.Regex.Match(subtotal2, @"\d+").Value;
                int sb = Int32.Parse(resultString);
                double sbt = Convert.ToInt32(sb) - descuent;
                string subtotal = peso+sbt.ToString();
                string descuento = descuent.ToString() + " (" + txtdescuento.Text + ") ";
                
                bool repeated = false;
                foreach (DataGridViewRow f in dataGridView1.Rows)
                {
                   // MessageBox.Show("verificando a: "+f.Cells["producto"].Value.ToString());
                    if (f.Cells["producto"].Value.ToString() == producto) { MessageBox.Show("El elemento "+producto+" ya ha sido agregado a la factura anteriormente","Elemento Duplicado",MessageBoxButtons.OK,MessageBoxIcon.Error);repeated = true; }
                }
                if (!repeated || dataGridView1.Rows.Count == 0) {
                    dataGridView1.Rows.Add(producto, cantidad, precio, peso + sb.ToString(), descuento, subtotal);
                    dataGridView3.Rows.Add(id, producto, cantidad);
                }
                    calcularTotal();
                calcularDescuentoTotal();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(d.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        public void calcularTotal()
        {
            try
            {
                calculofinal = 0;
                if (dataGridView1.Rows.Count == 0) { lbtotal.Text = "0.00"; }
                //MessageBox.Show(dataGridView1.Rows.Count.ToString());
                foreach (DataGridViewRow f in dataGridView1.Rows)
                {
                    string x = f.Cells["Subtotal"].Value.ToString();
                    //System.Text.RegularExpressions.Regex
                    string resultString = System.Text.RegularExpressions.Regex.Match(x, @"\d+").Value;
                    int cantidad = Int32.Parse(resultString);
                    // MessageBox.Show(cantidad.ToString());
                    calculofinal = calculofinal + cantidad;
                    total.Text = peso + calculofinal.ToString();
                    lbtotal.Text = peso + calculofinal.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(m.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        private void txtprecioporuni_TextChanged(object sender, EventArgs e)
        {
            if (txtcantidad.Text!="" && txtprecioporuni.Text!="")
            {
                double precio = (double.Parse(txtprecioporuni.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtprecioporuni.Text);
                double kntidad = (double.Parse(txtcantidad.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtcantidad.Text);

                double resultado = (precio * kntidad);
                txtsubtotal.Text = peso + resultado;
                calcularDescuento();
            }
            else
            {
                txtsubtotal.Text = peso + "0.00";
            }
        }

        public void calcularDescuentoTotal()
        {
            try
            {
                descFinal = 0.00;
                if (dataGridView1.Rows.Count == 0) { lbdescuento.Text = "0.00"; }
                foreach (DataGridViewRow f in dataGridView1.Rows)
                {
                    string x = f.Cells["descuento"].Value.ToString();
                    string resultString = System.Text.RegularExpressions.Regex.Match(x, @"\d+").Value;
                    double cantidad = Double.Parse(resultString);
                    descFinal += cantidad;
                    lbdescuento.Text = descFinal.ToString();
                    //MessageBox.Show(cantidad.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(m.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        public void calcularDescuento()
        {
            try
            {
                string subtotalfull = System.Text.RegularExpressions.Regex.Match(txtsubtotal.Text, @"\d+").Value;
                int subtotallimpio = Int32.Parse(subtotalfull);
                double subtotal = Convert.ToDouble(subtotallimpio);

                string resultString = System.Text.RegularExpressions.Regex.Match(txtdescuento.Text, @"\d+").Value;
                int cantidad = Int32.Parse(resultString);
                double desc = Convert.ToDouble(cantidad);
                double descpuro = (desc / 100);
                double descuentoFinalito = (subtotal * descpuro);
                descuentoT = descuentoFinalito;
                double estesieselfinal = subtotal - descuentoFinalito;
                //MessageBox.Show(descuentoFinalito.ToString());
                txtsubtotaldescuento.Text = peso+estesieselfinal.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             inventario invv = new inventario(usuario);
            invv.MdiParent = this.ParentForm;
            invv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getCliente();
        }

        public void getCliente()
        {
            try
            {
                conexion.abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from clientes where idcliente = '" + txtidcliente.Text + "';";
                SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                SqlDataReader lector;
                lector = comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    txtidcliente.BackColor = Color.Green;
                    //conexion.Open();
                    while (lector.Read())
                    {
                        lbcliente.Text = lector["nombre"].ToString()+" "+ lector["apellidos"].ToString(); ;
                    }
                   
                }
                else
                {
                    txtidcliente.BackColor = Color.Red;
                    lbcliente.Text = "[Cliente no idenificado]";
                }
                if (txtidcliente.Text == "")
                {
                    txtidcliente.BackColor = Color.White; lbcliente.Text = "__________________";
                }
            }
            catch (Exception ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {
            getCliente();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agregarCliente aa = new agregarCliente(usuario);
            aa.MdiParent = this.ParentForm;
            aa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool clientOk = false;
            bool productsOk = false;

            if (lbcliente.Text == "[Cliente no idenificado]" || lbcliente.Text == "" || lbcliente.Text == "__________________")
            {
                if (MessageBox.Show("No se ha establecido ningun cliente, Desea crear la factura y la venta a nombre de cliente generico?", "No cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clientOk = true;
                }
                else
                {
                    txtidcliente.Text = conexion.selector("clientes", "Idcliente");
                }
            }
            else
            {
                clientOk = true;
            }
            if (dataGridView1.Rows.Count>=1)
            {
                productsOk = true;
            }
            else
            {
                conexion.showError(new Exception("No se puede realizar una venta que no tiene productos."));
                productsOk = false;
            }

            if (clientOk && productsOk)
            {
                calcularTotal();
                calcularDescuentoTotal();
                descontarInventario();
                imprimirFactura();
                
            }
            
            
        }

        private void imprimirFactura()
        {
            FacturaViewer pp = new FacturaViewer(usuario,idventayfac.Text);
            pp.imprimir();
        }

        public void descontarInventario()
        {
            String existente = "0";
            String restante = "0";
            bool disponible = true;
            try
            {
                foreach (DataGridViewRow f in dataGridView3.Rows)
                {
                    conexion.cerrar();
                    conexion.abrir();
                    DataTable dt = new DataTable();
                    string producto = f.Cells["prod"].Value.ToString();
                    string id = f.Cells["idprod"].Value.ToString();
                    string cantidad = f.Cells["cant"].Value.ToString();
                    //MessageBox.Show(producto+id+cantidad);
                    string consulta = "select * from inventario where idproducto = '" +id+ "'";
                    SqlCommand comando = new SqlCommand(consulta, conexion.ver());
                    SqlDataReader lector22;
                    lector22 = comando.ExecuteReader();
                    foreach (DataRow dtRow in dt.Rows) ;
                    Boolean hayRegistros = lector22.HasRows;
                    if (hayRegistros)
                    {
                        while (lector22.Read())
                        {
                            existente = lector22["medida"].ToString();
                           // MessageBox.Show("Cantidad Existente de "+producto+" es "+existente.ToString());
                        }
                        //float aquitar = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                        String aquitar = f.Cells["cant"].Value.ToString();
                        System.Console.WriteLine("Existente " + existente);
                        System.Console.WriteLine("A quitar " + aquitar);
                        //Double cantidadResultante;
                        restante = Convert.ToString(double.Parse(existente, CultureInfo.InvariantCulture) - double.Parse(aquitar, CultureInfo.InvariantCulture));
                        // textBox3.Text = textBox3.Text.Replace(',','.');
                        System.Console.WriteLine("Cantidad restante " + restante.ToString().Replace(',', '.'));
                        restante = restante.ToString().Replace(',', '.');
                        //System.Console.WriteLine("=" +(double.Parse(cantidadexistente, CultureInfo.InvariantCulture)- double.Parse(aquitar, CultureInfo.InvariantCulture)));
                        if (double.Parse(aquitar, CultureInfo.InvariantCulture) > double.Parse(existente, CultureInfo.InvariantCulture)) { MessageBox.Show("No tienes "+producto+"(s) Suficientes.", ", Reajuste la factura",MessageBoxButtons.OK,MessageBoxIcon.Warning);disponible = false; }
                        else
                        {
                           /* string um = " " + label3.Text;
                            if (MessageBox.Show("En inventario tienes " + existente+", se sacarán " + aquitar+ ". Quedará un total de " + restante+ " disponible. Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                               
                              //  this.Close();
                            }
                            */
                        }
                    }
                    else { MessageBox.Show("No hay datos"); }
                }
                if (disponible)
                {
                    conexion.cerrar();
                    foreach (DataGridViewRow r in dataGridView3.Rows)
                    {
                        try {
                            conexion.abrir();
                            string query = "update inventario set medida = '" + restante + "' where idproducto='" + r.Cells["idprod"].Value.ToString() + "';";
                            SqlCommand komando = new SqlCommand(query, conexion.ver());
                            komando.ExecuteNonQuery();
                            conexion.cerrar();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(e.ToString());
                            errorManager ho = new errorManager(string.Empty, ex);
                            ho.Show();
                        }
                        finally
                        {
                            conexion.cerrar();
                        }
                    }
                    crearfactura();
                    crearVenta();

                    
                }
            }
            catch (Exception ex) {
                //    MessageBox.Show("ERROR " + x.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }
        }

       

        public void crearVenta()
        {
            try
            {
                string idventa = idventayfac.Text;
                string empleado = usuario;
                string fech = dateTimePicker1.Value.ToString();
                string idcliente = txtidcliente.Text;
                string tipodeventa = txttipodeventa.Text;
                int elementos = dataGridView1.RowCount;
                string totalito = lbtotal.Text;

                if (riku.Properties.Settings.Default.rikuNetworkSyncActive)
                {
                    rikuNetwork rn = new rikuNetwork();
                    Sale venta = new Sale();
                    venta.id = idventa;
                    venta.cajero = empleado;
                    venta.cantidadItems = elementos;
                    venta.clienteId = Convert.ToInt32(idcliente);
                    venta.fecha = DateTime.Now;
                    venta.storeId = riku.Properties.Settings.Default.rikuNetworkBussinessCode;
                    venta.storePass = riku.Properties.Settings.Default.rikuNetworkPassword;
                    venta.tipoVenta=tipodeventa;
                    venta.total = totalito;
                    rn.sendSingleSale(venta);
                }


                conexion.abrir();
                string query = "insert into ventas (idventa,empleado,fecha,idcliente,tipodeventa,elementosfacturados,total)" +
                        "values('"+idventa+"','" + empleado + "','" + fech + "','" + idcliente + "','" + tipodeventa + "','" + elementos + "','"+totalito+"')";
                SqlCommand comando = new SqlCommand(query, conexion.ver());
                comando.ExecuteNonQuery();
                conexion.cerrar();

                conexion.inform("Venta Realizada");
                log.venta(usuario,"Venta realizada al ciente "+lbcliente.Text, idventayfac.Text);
                consultarVentas cv = new consultarVentas(usuario);
                cv.Show();
                FacturaViewer fv = new FacturaViewer(usuario, idventayfac.Text);
                fv.Show();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(v.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
            finally
            {
                conexion.cerrar();
            }          

        }

        public void crearfactura()
        {
            conexion.cerrar();
            foreach (DataGridViewRow f in dataGridView1.Rows)
            {
                try
                {
                    string idventa = idventayfac.Text;
                    string producto = f.Cells["producto"].Value.ToString();
                    string canti = f.Cells["cantidad"].Value.ToString();
                    string precio = f.Cells["precio"].Value.ToString();
                    string saldo = f.Cells["saldo"].Value.ToString();
                    string descuento = f.Cells["descuento"].Value.ToString();
                    string subtotal = f.Cells["subtotal"].Value.ToString();
                    string fech = dateTimePicker1.Text;
                    string idcliente = txtidcliente.Text;
                    string tipodeventa = txttipodeventa.Text;
                    //System.Text.RegularExpressions.Regex
                    conexion.abrir();
                    string query = "insert into facturas (idventa,producto,cantidad,precio,saldo,descuento,subtotal)" +
                        "values('"+idventa+"','"+producto+"','"+canti+"','"+precio+"','"+saldo+"','"+descuento+"','"+subtotal+"')";
                    SqlCommand comando = new SqlCommand(query,conexion.ver());
                    comando.ExecuteNonQuery();
                    conexion.cerrar();
                    /*string resultString = System.Text.RegularExpressions.Regex.Match(x, @"\d+").Value;
                    int cantidad = Int32.Parse(resultString);
                    // MessageBox.Show(cantidad.ToString());
                    calculofinal = calculofinal + cantidad;
                    total.Text = peso + calculofinal.ToString();
                    lbtotal.Text = peso + calculofinal.ToString();
                    */
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(v.ToString());
                    errorManager ho = new errorManager(string.Empty, ex);
                    ho.Show();
                }
                finally
                {
                    conexion.cerrar();
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            string resultString = System.Text.RegularExpressions.Regex.Match(txtdescuento.Text, @"\d+").Value;
            int cantidad = Int32.Parse(resultString);
            txtdescuento.Text = cantidad.ToString() + "%";
        }

        private void txtdescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtdescuento.Text == "%")
                {
                    txtdescuento.BackColor = Color.Red;
                    return;
                }
                if (txtcantidad.Text != "")
                {
                    txtdescuento.BackColor = Color.White;
                    double precio = (double.Parse(txtprecioporuni.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtprecioporuni.Text);
                    double kntidad = (double.Parse(txtcantidad.Text, CultureInfo.InvariantCulture));//Convert.ToDouble(txtcantidad.Text);

                    double resultado = (precio * kntidad);
                    txtsubtotal.Text = peso + resultado;
                    calcularDescuento();
                }
                else
                {
                    txtsubtotal.Text = peso + "0.00";
                }
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }

        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay productos en la factura", "Nada para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string producto = dataGridView1.CurrentRow.Cells["producto"].Value.ToString();                
               // MessageBox.Show(producto);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == producto)
                    {
                       // MessageBox.Show(i.ToString());
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        dataGridView3.Rows.RemoveAt(i);
                    }
                }
                //dataGridView3.Rows.RemoveAt();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                calcularTotal();
                calcularDescuentoTotal();
            }
            catch (Exception ex)
            {
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            calculadora cc = new calculadora(usuario);
            cc.MdiParent = this.ParentForm;
            cc.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consultarVentas cv = new consultarVentas(usuario);
            cv.MdiParent = this.ParentForm;
            cv.Show();
        }

        private void idventayfac_TextChanged(object sender, EventArgs e)
        {
            verificarID();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            stepOne();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtidcliente.Text = conexion.selector("clientes","Idcliente");
        }
    }
}
