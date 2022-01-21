using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using miriam0._2;
using System.IO;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace riku
{
    class cnn
    {
        static string db = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\RIKU.FDB";
        SqlConnection con = new SqlConnection(@"Server="+ riku.Properties.Settings.Default.instance + ";Database="+riku.Properties.Settings.Default.database+";User Id="+riku.Properties.Settings.Default.dbUser+";Password="+riku.Properties.Settings.Default.dbPass+";");
        public string activeUserId = "No Identificado";

        public bool probar()
        {
            try
            {
                this.abrir();
                this.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                string p = ex.ToString();
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
                return false;
            }
        }

        public bool yesnoDialog(string question)
        {
            if (question.Length >= 1)
            {
                bool resp;
                errorManager error = new errorManager("yesno", new Exception(question));                
                error.ShowDialog();
                resp = error.respuesta;
                return resp;
            }
            else
            {
                return false;
            }
        }

        public string rnc(string campo)
        {
            return campo;
        }

        public void borrarTabla(string tabla)
        {
            try
            {
                    string query = "delete from " + tabla+";";
                    abrir();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = query;
                    comando.Connection = ver();
                    comando.ExecuteNonQuery();
                    cerrar();

            }
            catch (Exception ex)
            {
                showError(ex);
            }
            finally
            {
                cerrar();
            }
        }

        public void delete(string tabla,string conditionals)
        {
            try
            {
                if (conditionals == "")
                {
                    return;
                }
                else
                {
                    string query = "delete from "+tabla+" where "+conditionals+";";
                    abrir();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = query;
                    comando.Connection = ver();
                    comando.ExecuteNonQuery();
                    cerrar();
                }
                
            }
            catch (Exception ex)
            {
                showError(ex);
            }
            finally
            {
                cerrar();
            }
        }



            public List<string> getUserInfo(string id)
        {
            try
            {
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from usuarios where id = '" + id + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dl = new DataTable();
                adaptador.Fill(dl);

                if (dl.Rows.Count == 1)
                {
                    //string tipo = dl.Rows[0][0].ToString().ToUpper();
                    var datox = new List<string>();
                    foreach (var ddfrs in dl.Rows)
                    {
                        datox.Add(dl.Rows[0][0].ToString().ToUpper());
                        datox.Add(dl.Rows[0][1].ToString().ToUpper());
                        datox.Add(dl.Rows[0][2].ToString().ToUpper());
                        datox.Add(dl.Rows[0][3].ToString().ToUpper());
                        datox.Add(dl.Rows[0][4].ToString().ToUpper());
                        datox.Add(dl.Rows[0][5].ToString().ToUpper());
                        datox.Add(dl.Rows[0][6].ToString().ToUpper());
                        datox.Add(dl.Rows[0][7].ToString().ToUpper());
                        datox.Add(dl.Rows[0][8].ToString().ToUpper());
                        datox.Add(dl.Rows[0][9].ToString().ToUpper());
                        datox.Add(dl.Rows[0][10].ToString().ToUpper());
                        datox.Add(dl.Rows[0][11].ToString().ToUpper());
                    }
                    return datox;


                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                errorManager jj = new errorManager("", ex);
                jj.Show();
                return null;
            }
            finally
            {
                cerrar();
            }
        }

        public string getCliente(string id)
        {
            try
            {
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select nombre from clientes where idcliente = '" + id + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dl = new DataTable();
                adaptador.Fill(dl);
                if (dl.Rows.Count == 1)
                {
                    string tipo = dl.Rows[0][0].ToString().ToUpper();
                    return tipo;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                errorManager jj = new errorManager("", ex);
                jj.Show();
                return null;
            }
            finally
            {
                cerrar();
            }
        }

        public void inform(string texto)
        {
            if (texto.Length>=1)
            {
                errorManager error = new errorManager("info", new Exception(texto));
                error.Show();
            }
        }

        public void showError(Exception f)
        {
            errorManager error = new errorManager(string.Empty,f );
            log log = new log();
            log.errorLog(activeUserId,f.Message);
            error.Show();
            
        }

        public bool saveMultiple(string table, string fields, string values)
        {
            try
            {
                //string sql = "INSERT or REPLACE INTO " + table + " (" + fields + ")VALUES" + values + "";
                string sql = "INSERT INTO " + table + " (" + fields + ")VALUES" + values + "";
                abrir();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = sql;
                comando.Connection = ver();
                comando.ExecuteNonQuery();
                cerrar();
                return true;
            }
            catch (Exception ex)
            {
                showError(ex);
                return false;
            }
            finally
            {
                cerrar();
            }
        }

        public void save(string table,string fields,string values)
        {
            try
            {
                string sql = "INSERT INTO "+table+" ("+fields+")VALUES("+values+ ")";
                abrir();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = sql;
                comando.Connection = ver();
                comando.ExecuteNonQuery();
                cerrar();
            }
            catch (Exception ex)
            {
                showError(ex);
            }
            finally
            {
                cerrar();
            }
        }

        public bool update(string table, string modifications, string conditionals)
        {
            try
            {
                if (conditionals!="")
                {
                    string sql = "update " + table + " set " + modifications + " where " + conditionals;
                    abrir();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = sql;
                    comando.Connection = ver();
                    comando.ExecuteNonQuery();
                    cerrar();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                showError(ex);
                return false;
            }
            finally
            {
                cerrar();
            }
        }

        public string[] getContribuyentes(string id)
        {
            try
            {
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select * from contribuyentes where rnc = '" + id + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dl = new DataTable();
                adaptador.Fill(dl);
                if (dl.Rows.Count == 1)
                {
                    string nombre = dl.Rows[0][1].ToString().ToUpper();
                    string descripcion = dl.Rows[0][2].ToString().ToUpper();
                    string fecha = dl.Rows[0][3].ToString().ToUpper();
                    string estado = dl.Rows[0][4].ToString().ToUpper();
                    string condicion = dl.Rows[0][5].ToString().ToUpper();
                    string[] paquete = { nombre, descripcion, fecha, estado, condicion };
                    return paquete;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                errorManager jj = new errorManager("", ex);
                jj.Show();
                return null;
            }
            finally
            {
                cerrar();
            }
        }

        public bool login(string user, string pass)
        {

            try
            {
                if (user == "" || pass == "")
                {
                    return false;
                }
                string mSQL = "select * from usuarios where usuario = '" + user + "' and clave = '" + pass + "';";
                abrir();
                SqlCommand cmd = new SqlCommand(mSQL, ver());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader lector;
                lector = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean hayRegistros = lector.HasRows;
                if (hayRegistros)
                {
                    //MessageBox.Show("Bienvenido al sistema " + textBox1.Text);
                    cerrar();
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                //string error = Convert.ToString(ex);
                //MessageBox.Show("ERROR         " + error);

                errorManager err = new errorManager(string.Empty, ex);
                err.Show();
                return false;
            }
            finally
            {
                cerrar();
            }
        }

        public void abrir()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            else
            {
                cerrar();
                abrir();
            }
        }
        public void cerrar()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }


        public string selector(string table,string returnField)
        {
            try
            {
                select formOptions = new select(table);
                formOptions.ShowDialog();
                if (formOptions.row != null)
                {
                    DataGridViewRow myString = formOptions.row;
                    return myString.Cells[returnField].Value.ToString();
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                errorManager jj = new errorManager("", ex);
                jj.Show();
                return null;
            }
        }
        public string getTipo(string usuario)
        {
            try
            {
                string id = getIdUsuario(usuario);
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select tipo from usuarios where id = '" + id + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dl = new DataTable();
                adaptador.Fill(dl);
                if (dl.Rows.Count == 1)
                {
                    string tipo = dl.Rows[0][0].ToString().ToUpper();
                    return tipo;
                }
                else
                {                    
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                errorManager jj = new errorManager("",ex);
                jj.Show();
                return null;
            }
        }

        public string getIdUsuario(string usuario)
        {
            try
            {
                if (usuario != null)
                {
                    abrir();
                    DataTable dt = new DataTable();
                    string consulta = "select id from usuarios where usuario = '" + usuario + "';";
                    SqlCommand comando = new SqlCommand(consulta, ver());
                    SqlDataAdapter adap = new SqlDataAdapter(comando);
                    DataTable ff = new DataTable();
                    adap.Fill(ff);
                    if (ff.Rows.Count == 1)
                    {
                        string id = ff.Rows[0][0].ToString();
                        return id;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string getModuloById(string id)
        {
            try
            {
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select name from modulos where id = '" + id + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adap = new SqlDataAdapter(comando);
                DataTable ff = new DataTable();
                adap.Fill(ff);
                if (ff.Rows.Count == 1)
                {
                    string name = ff.Rows[0][0].ToString();
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string getModuleIdByname(string name)
        {
            try
            {
                abrir();
                DataTable dt = new DataTable();
                string consulta = "select id from modulos where name = '" + name + "';";
                SqlCommand comando = new SqlCommand(consulta, ver());
                SqlDataAdapter adap = new SqlDataAdapter(comando);
                DataTable ff = new DataTable();
                adap.Fill(ff);
                if (ff.Rows.Count == 1)
                {
                    string id = ff.Rows[0][0].ToString();
                    return id;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public Form getForm(string formText,string user)
        {
            try
            {
                Form formulario = null;

                switch (formText)
                {
                    #region ADMINISTRACION
                    case "inicio":
                        formulario = new home(user, checkInter(), 0);
                        break;
                    case "administrador de usuarios":
                        admUsuarios adm = new admUsuarios(user);
                        adm.tabControl1.SelectedTab = adm.tabControl1.TabPages[2];
                        formulario = adm;
                        break;
                    case "eliminar usuario":
                        admUsuarios usr = new admUsuarios(user);
                        usr.tabControl1.SelectedTab = usr.tabControl1.TabPages[1];
                        formulario = usr;
                        break;
                    case "nuevo usuario":
                        admUsuarios jj = new admUsuarios(user);
                        jj.tabControl1.SelectedTab = jj.tabControl1.TabPages[0];
                        formulario = jj;
                        break;
                    case "consultar clientes":
                        consultarCliente cc = new consultarCliente(user);
                        formulario = cc;
                        break;
                    case "nuevo cliente":
                        agregarCliente ac = new agregarCliente(user);
                        formulario = ac;
                        break;
                    case "agregar suplidor":
                        formulario = new agregarSuplidor(user);
                        break;
                    case "consultar suplidores":
                        formulario = new consultarSuplidor(user);
                        break;
                    #endregion
                    #region TRANSACCIONES
                    case "facturar":
                        formulario = new facturar(user);
                        break;
                    case "registrar venta del dia":
                        formulario = new agregarVentaDeldia(user);
                        break;
                    case "registrar actividad":
                        formulario = new agregarActividad(user);
                        break;
                    case "consultar venta del dia":
                        formulario = new consultarVentasDiaria(user);
                        break;
                    case "consultar una actividad":
                        formulario = new consultarActividades(user);
                        break;
                    #endregion
                    #region CONSULTAS
                    case "consultar ventas":
                        formulario = new consultarVentas(user);
                        break;
                    case "consultar una factura":
                        formulario = new facturaNo(user);
                        break;
                    case "inventario":
                        formulario = new inventario(user);
                        break;
                    #endregion
                    #region REPORTES
                    case "administrador de reportes":
                        formulario = new reporteInventario(user);
                        break;
                    case "auditoria de sistema - sdi":
                        formulario = new logview();
                        break;
                    #endregion
                    #region HERRAMIENTAS
                    case "calculadora":
                        formulario = new calculadora(user);
                        break;
                    case "conversor de unidades":
                        formulario = new conversor(user);
                        break;
                    case "navegador":
                        formulario = new webBrowser(user);
                        break;
                    case "consultar contribuyentes dgii":
                        formulario = new DGII.consultarContribuyente(user);
                        break;
                    #endregion
                    #region CATALOGOS
                    case "administrar unidades de medida":
                        formulario = new units(user);
                        break;
                    case "agregar unidad de medida":
                        formulario = new addUnit(user);
                        break;
                    #endregion
                    #region CONFIGURACION
                    case "configuracion":
                        formulario = new settings(user);
                        break;
                    #endregion
                    default:
                        break;
                }
                return formulario;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool isAdmin(string usuario)
        {
            try
            {
                if (usuario == string.Empty || usuario == null)
                {
                    return false;
                }
                //string comando = "select * from usuarios where ;", connect;
                abrir();
                SqlCommand command = new SqlCommand("select * from usuarios where usuario = '" + usuario + "';", ver());
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    string field = dt.Rows[0][3].ToString();
                    if (field.ToLower() == "administrador")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    Exception rr = new Exception("Este usuario tiene duplicidad en la base de datos.");
                    errorManager ff = new errorManager("info", rr);
                    ff.Show();
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorManager gg = new errorManager(string.Empty, ex);
                gg.Show();
                return false;
            }
            finally
            {
                cerrar();
            }
        }

        

        public bool checkInter()
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            bool acceso = false;
            if (connection == true)
            {
                acceso = true;
            }
            else
            {
                acceso = false;
            }
            return acceso;
        }


        public SqlConnection ver()
        {
            return con;
        }

        public int getCount(string table,string conditionals)
        {
            try
            {
                if (conditionals == string.Empty)
                {
                    conditionals = " where 1=1;";
                }
                else
                {
                    conditionals = " where " + conditionals;
                }
                abrir();
                //SqlCommand comm = new SqlCommand("SELECT * FROM "+table+conditionals, ver()) ;
                ////Int32 countk = (Int32)comm.ExecuteScalar();
                //int count = Convert.ToInt32(comm.ExecuteScalar());
                //return count;
                SqlCommand cmd = new SqlCommand("select count(*) from " + table + conditionals,ver());
                int kount = Convert.ToInt32(cmd.ExecuteScalar());
                //int total_rows_in_resultset = reader.StepCount;
                int total_rows_in_resultset = kount;
                return total_rows_in_resultset;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR" + ex.ToString());
                errorManager ho = new errorManager(string.Empty, ex);
                ho.Show();
                return 0;
            }
            finally
            {
                cerrar();
            }

        }

       

        public DataTable getTable(string table, string conditionals)
        {
            try
            {
                if (conditionals == string.Empty)
                {
                    conditionals = "1=1";
                }
                
                abrir();
                string mSQL = "Select * from " + table + " where " + conditionals;
                SqlCommand cmd = new SqlCommand(mSQL, ver());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException fbex)
            {
                //throw fbex;
                showError(fbex);
                return null;
            }
            finally
            {
                cerrar();
            }
        }


    }
}
