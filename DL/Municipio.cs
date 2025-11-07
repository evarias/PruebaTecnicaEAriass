using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Municipio
    {
        public Municipio()
        {
            Colonia = new HashSet<Colonia>();
        }

        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Colonia> Colonia { get; set; }
    }
}
