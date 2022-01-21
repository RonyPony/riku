using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Net.NetworkInformation;
using System.Data;
using riku;

namespace miriam0._2
{
    class onlineCnn
    {
        
        //string lineaConexion = "server=localhost;database=2725554_ronelcc;uid=root;pwd=;";
        //MySqlConnection conexion = new MySqlConnection("server=localhost;database=2725554_ronelcc;uid=root;pwd=;");
        //MySqlConnection cnn = new MySqlConnection("server=fdb20.runhosting.com;database=2725554_ronelcc;uid=2725554_ronelcc;pwd=ronel8099036257;");
 // MySqlConnection cnn = new MySqlConnection("Server=http:/fdb20.runhosting.com; Port=3306; Database=2725554_ronelcc; Uid=2725554_ronelcc; Pwd=ronel8099036257;");
        // Server=myServerAddress; Port=1234; Database=myDataBase; Uid=myUsername; Pwd=myPassword;
        //MySqlConnection cnn = new MySqlConnection("server=localhost;database=2725554_ronelcc;uid=root;");
        

int storeId;

        public bool checkInter(int storeid)
        {
            storeId = storeid;
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

        public void abrir()
        {
            try
            {//Server=fdb20.runhosting.com; Port=1234; Database=2725554_ronelcc; Uid=2725554_ronelcc; Pwd=ronel8099036257;");
              //  cnn.Open();
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
        }

        public void cerrar()
        {
            try
            {
             //  cnn.Close();
            }
            catch (Exception ex)
            {
                errorManager rr = new errorManager(string.Empty, ex);
                rr.Show();
            }
        }

        /*
        public MySqlConnection ver()
        {
            try
            {
                return cnn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(vv.ToString());
                return null;
            }
        }
        */
        public string licenceCheck()
        {
            try {
                string licencia;
                //MessageBox.Show("Storeid:" + storeId.ToString());
                /*
                string Query2 = "select * from licenciasRiku where storeId='"+storeId+"';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query2, cnn);
                MySqlDataReader lector;
                cnn.Open();
                lector = MyCommand2.ExecuteReader();
                
                while (lector.Read())
                {
                    licencia = lector["estado"].ToString();
                    // MessageBox.Show(storeId.ToString());
                    //MessageBox.Show(acceso.ToString());
                    //MessageBox.Show("Licencia "+licencia);
                    return licencia;
                }
                return "";
                */
                return "";
            } catch (Exception ex){
             ex.ToString();
                return "";
            }finally {
        //    cnn.Close();
            }
            
        }

        public string getExpiredLicenceReason()
        {/*
            //try{
                string rason;
                string Query3 = "select * from licenciasRiku where storeId='" + storeId + "';";
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, cnn);
                MySqlDataReader lector2;
                cnn.Open();
                lector2 = MyCommand3.ExecuteReader();
                while (lector2.Read())
                {
                    rason = lector2["razon"].ToString();
                   // MessageBox.Show(storeId.ToString());
                    return rason;
                }
                return "Sin Datos";
            //}catch (Exception ex){
              //  cc.ToString();
              //  return "ERROR"+cc.ToString();
            //}finally{
                cnn.Close();
            //}
            */
            return "";
        }

        public bool PingNetwork(string hostNameOrAddress)
        {
            bool pingStatus = false;

            using (Ping p = new Ping())
            {
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    pingStatus = (reply.Status == IPStatus.Success);
                }
                catch (Exception)
                {
                    pingStatus = false;
                }
            }
            return pingStatus;

        }
    }
}
