using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Tienda
    {
        public Tienda()
        {
            ArticuloTienda = new HashSet<ArticuloTienda>();
            DireccionTienda = new HashSet<DireccionTienda>();
        }

        public int IdTienda { get; set; }
        public string Sucursal { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; }
        public virtual ICollection<DireccionTienda> DireccionTienda { get; set; }
    }
}
