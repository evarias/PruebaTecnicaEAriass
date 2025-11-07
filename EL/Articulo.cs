using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public EL.ArticuloTienda? ArticuloTienda { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int Stock { get; set; }

        public List<object> Articulos { get; set; }
    }
}
