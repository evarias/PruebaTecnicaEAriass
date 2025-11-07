using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class ClienteArticuloGetAllDTO
    {
        public int IdClienteArticulo { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }

        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Descripcion { get; set; }
    }
}
