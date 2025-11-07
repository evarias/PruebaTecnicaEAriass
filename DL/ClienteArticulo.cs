using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class ClienteArticulo
    {
        public int IdClienteArticulo { get; set; }
        public int? IdCliente { get; set; }
        public int? IdArticulo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
