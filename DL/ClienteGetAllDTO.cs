using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class ClienteGetAllDTO
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroeExterior { get; set; }
        public string ColoniaNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public string EstadoNombre { get; set; }
    }
}
