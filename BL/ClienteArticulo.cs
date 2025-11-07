using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class ClienteArticulo
    {
        private readonly DL.PruebaTecnicaContext _context;

        public ClienteArticulo(DL.PruebaTecnicaContext context)
        {
            _context = context;
        }

        public EL.Result GetAll()
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.ClienteArticuloGetAllDTO.FromSqlRaw("EXEC ClienteArticuloGetAll").ToList();

                if (query.Count > 0)
                {
                    result.Objects = new List<object>();



                    foreach (var obj in query)
                    {
                        EL.ClienteArticulo clienteArticulo = new EL.ClienteArticulo();
                        clienteArticulo.Cliente = new EL.Cliente();
                        clienteArticulo.Articulo = new EL.Articulo();

                        clienteArticulo.IdClienteArticulo = obj.IdClienteArticulo;
                        clienteArticulo.Fecha = obj.Fecha;
                        clienteArticulo.Cliente.IdCliente = obj.IdCliente;
                        clienteArticulo.Cliente.Nombre = obj.Nombre;
                        clienteArticulo.Cliente.ApellidoPaterno = obj.ApellidoPaterno;
                        clienteArticulo.Articulo.IdArticulo = obj.IdArticulo;
                        clienteArticulo.Articulo.Descripcion = obj.Descripcion;
                        


                        result.Objects.Add(clienteArticulo);
                    }
                    result.Correct = true;
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

        public EL.Result Add(int IdCliente, int IdArticulo)
        {
           
            EL.Result result = new EL.Result();

            try
            {
                var Fecha = "";
                var query = _context.Database.ExecuteSqlRaw(
                    @"EXEC ClienteArticuloAdd 
                @IdCliente,
                @IdArticulo,
                @Fecha",
                    new SqlParameter("@IdCliente", IdCliente),
                    new SqlParameter("@IdArticulo", IdArticulo),
                    new SqlParameter("@Fecha", Fecha)
                );

                if (query > 0)
                {
                    
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se insertó";
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
