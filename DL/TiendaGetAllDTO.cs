using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class TiendaGetAllDTO
    {
        public int IdTienda { get; set; }

        public string Sucursal { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroeExterior { get; set; }
        public string ColoniaNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public string EstadoNombre { get; set; }
    }
}
