using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class DireccionTienda
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroeExterior { get; set; }
        public int? IdColonia { get; set; }
        public int? IdTienda { get; set; }

        public virtual Colonia IdColoniaNavigation { get; set; }
        public virtual Tienda IdTiendaNavigation { get; set; }
    }
}
