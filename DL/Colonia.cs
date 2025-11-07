using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Colonia
    {
        public Colonia()
        {
            DireccionCliente = new HashSet<DireccionCliente>();
            DireccionTienda = new HashSet<DireccionTienda>();
        }

        public int IdColonia { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public int? IdMunicipio { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; }
        public virtual ICollection<DireccionCliente> DireccionCliente { get; set; }
        public virtual ICollection<DireccionTienda> DireccionTienda { get; set; }
    }
}
