using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        public string Calle { get; set; }

        public string NumeroInterior { get; set; }

        public string NumeroExterior { get; set; }

        public EL.Colonia Colonia { get; set; }

    }
}
