using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
