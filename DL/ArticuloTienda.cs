using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class ArticuloTienda
    {
        public int IdArticuloTienda { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdTienda { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Tienda IdTiendaNavigation { get; set; }
    }
}
