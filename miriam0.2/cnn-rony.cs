using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace miriam0._2
{
    class cnn
    {
        SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=riku;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlConnection conexion = new SqlConnection("Data Source=rony-pc\\ronelcruzceballo;Initial Catalog=manadedios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlConnection conexion = new SqlConnection("Data Source=elmanadedios-pc\\ronelcruzceballo;Initial Catalog=manadedios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void abrir()
        {           
            conexion.Open();
        }

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
                return false;
            }
        }

        public SqlConnection ver()
        {
            return conexion;
        }

        public void cerrar()
        {

            conexion.Close();
        }

    }
}
