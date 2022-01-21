using RestSharp;
using riku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace riku
{
    class rikuNetwork
    {
        cnn conexion = new cnn();
        private static readonly HttpClient client = new HttpClient();

        async public void sendSingleSale(Sale venta)
        {
            var client = new RestClient("http://rikubackendapi88.apphb.com/api/sales/create");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("storeId", "1");
            request.AddParameter("storePass", venta.storePass);
            request.AddParameter("id", venta.id);
            request.AddParameter("cashier", venta.cajero);
            request.AddParameter("date", venta.fecha);
            request.AddParameter("customerId", venta.clienteId);
            request.AddParameter("saleType", venta.tipoVenta);
            request.AddParameter("amountOfItems", venta.cantidadItems);
            request.AddParameter("total", venta.total);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string fields = "logType,usuario,datetime,info";
            string values = "'API Response','Not Necesary','" + DateTime.Now + "','" + response.Content+" # Status Code"+response.StatusCode + "'";
            conexion.save("log", fields, values);
        }
    }
}
