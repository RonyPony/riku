using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riku.Models
{
    class Sale
    {
        public int storeId { get; set; }
        public string storePass { get; set; }
        public string id { get; set; }
        public string cajero { get; set; }
        public DateTime fecha { get; set; }
        public int clienteId { get; set; }
        public string tipoVenta { get; set; }
        public int cantidadItems { get; set; }
        public string total { get; set; }
    }
}
