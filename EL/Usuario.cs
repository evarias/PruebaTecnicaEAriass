using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public EL.Cliente Cliente { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
