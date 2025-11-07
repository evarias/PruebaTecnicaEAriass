using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class ClienteArticulo
    {
        public int IdClienteArticulo { get; set; }
        public EL.Cliente Cliente { get; set; }
        public EL.Articulo Articulo { get; set; }

        public string Fecha { get; set; }
        public List<object> ClienteArticulos { get; set; }
    }
}
