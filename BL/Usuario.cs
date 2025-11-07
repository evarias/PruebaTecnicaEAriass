using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Usuario
    {
        private readonly DL.PruebaTecnicaContext _context;
        public Usuario(DL.PruebaTecnicaContext context)
        {
            _context = context;
        }

        public EL.Result GetUser(EL.Usuario usuario)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from userDB in _context.Usuario
                             join clienteDB in _context.Cliente on userDB.IdCliente equals clienteDB.IdCliente
                             where userDB.Email == usuario.Email && userDB.Password == usuario.Password
                             select userDB).SingleOrDefault();

                if (query != null)
                {
                    result.Objects = new List<object>();

                    EL.Usuario usuariologin = new EL.Usuario();
                    usuariologin.Cliente = new EL.Cliente();


                    usuariologin.Email = query.Email;
                    usuariologin.Password = query.Password;
                    usuariologin.Cliente.IdCliente = Convert.ToInt32(query.IdCliente);
                        


                        result.Objects.Add(usuariologin);
                    
                    result.Correct = true;
                    result.Object = usuariologin;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
