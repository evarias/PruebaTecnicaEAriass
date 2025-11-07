using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Tienda
    {
        public int IdTienda { get; set; }
        public string Sucursal { get; set; }

        public EL.Direccion Direccion { get; set; }
    }
}
