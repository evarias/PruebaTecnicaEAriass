using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Colonia
    {
        public int IdColonia { get; set; }

        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }

        public EL.Municipio Municipio { get; set; }

        public List<object> Colonias { get; set; }



    }
}
