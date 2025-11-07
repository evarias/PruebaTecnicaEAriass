using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteArticulo = new HashSet<ClienteArticulo>();
            DireccionCliente = new HashSet<DireccionCliente>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdCliente { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ClienteArticulo> ClienteArticulo { get; set; }
        public virtual ICollection<DireccionCliente> DireccionCliente { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
