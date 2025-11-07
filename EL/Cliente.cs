using System;

namespace EL
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public EL.Direccion Direccion { get; set; }
    }
}
