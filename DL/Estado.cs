using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Estado
    {
        public Estado()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
