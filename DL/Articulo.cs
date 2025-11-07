using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Articulo
    {
        public Articulo()
        {
            ArticuloTienda = new HashSet<ArticuloTienda>();
            ClienteArticulo = new HashSet<ClienteArticulo>();
        }

        public int IdArticulo { get; set; }
        public string Código { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<ArticuloTienda> ArticuloTienda { get; set; }
        public virtual ICollection<ClienteArticulo> ClienteArticulo { get; set; }
    }
}
