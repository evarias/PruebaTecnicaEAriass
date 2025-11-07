using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Cliente
    {
        private readonly DL.PruebaTecnicaContext _context;

        public Cliente(DL.PruebaTecnicaContext context)
        {
            _context = context;
        }

        public EL.Result GetAll()
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.ClienteGetAllDTO.FromSqlRaw("EXEC ClienteGetAll").ToList();

                if (query.Count > 0)
                {
                    result.Objects = new List<object>();



                    foreach (var obj in query)
                    {
                        EL.Cliente cliente = new EL.Cliente();
                        cliente.Direccion = new EL.Direccion();
                        EL.Direccion direccion = new EL.Direccion();
                        direccion.Colonia = new EL.Colonia();
                        EL.Colonia colonia = new EL.Colonia();
                        colonia.Municipio = new EL.Municipio();
                        EL.Municipio municipio = new EL.Municipio();
                        municipio.Estado = new EL.Estado();

                        cliente.IdCliente = obj.IdCliente;
                        cliente.Nombre = obj.Nombre;
                        cliente.ApellidoPaterno = obj.ApellidoPaterno;
                        cliente.ApellidoMaterno = obj.ApellidoMaterno;
                        direccion.Calle = obj.Calle;
                        direccion.NumeroInterior = obj.NumeroInterior;
                        direccion.NumeroExterior = obj.NumeroeExterior;
                        direccion.Colonia.Nombre = obj.ColoniaNombre;
                        colonia.Municipio.Nombre = obj.MunicipioNombre;
                        municipio.Estado.Nombre = obj.EstadoNombre;
                       

                        result.Objects.Add(cliente);
                        result.Objects.Add(direccion);
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
        public EL.Result GetById(int IdCliente)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from cliente in _context.Cliente
                             join direccion in _context.DireccionCliente on cliente.IdCliente equals direccion.IdCliente
                             join colonia in _context.Colonia on direccion.IdColonia equals colonia.IdColonia
                             join municipio in _context.Municipio on colonia.IdMunicipio equals municipio.IdMunicipio
                             join estado in _context.Estado on municipio.IdEstado equals estado.IdEstado
                             where cliente.IdCliente == IdCliente
                             select new
                             {
                                 cliente.IdCliente,
                                 cliente.Nombre,
                                 cliente.ApellidoPaterno,
                                 cliente.ApellidoMaterno,
                                 direccion.Calle,
                                 direccion.NumeroInterior,
                                 direccion.NumeroeExterior,
                                 ColoniaNombre = colonia.Nombre,
                                 MunicipioNombre = municipio.Nombre,
                                 EstadoNombre = estado.Nombre
                             }).SingleOrDefault();

                if (query != null)
                {
                    EL.Cliente cliente = new EL.Cliente();
                    cliente.Direccion = new EL.Direccion();
                    cliente.Direccion.Colonia = new EL.Colonia();
                    cliente.Direccion.Colonia.Municipio = new EL.Municipio();
                    cliente.Direccion.Colonia.Municipio.Estado = new EL.Estado();

                    cliente.IdCliente = query.IdCliente;
                    cliente.Nombre = query.Nombre;
                    cliente.ApellidoPaterno = query.ApellidoPaterno;
                    cliente.ApellidoMaterno = query.ApellidoMaterno;

                    cliente.Direccion.Calle = query.Calle;
                    cliente.Direccion.NumeroInterior = query.NumeroInterior;
                    cliente.Direccion.NumeroExterior = query.NumeroeExterior; 
                    cliente.Direccion.Colonia.Nombre = query.ColoniaNombre;
                    cliente.Direccion.Colonia.Municipio.Nombre = query.MunicipioNombre;
                    cliente.Direccion.Colonia.Municipio.Estado.Nombre = query.EstadoNombre;

                    result.Object = cliente;

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el cliente.";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public EL.Result Add(string Nombre, string ApellidoPaterno, string ApellidoMaterno)
        {
            var Calle = "16 sur";
            var NumeroInterior = "1703";
            var NumeroExterior = "";
            var IdColonia = 5;
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.Database.ExecuteSqlRaw(
                    @"EXEC ClienteAdd 
                @Nombre,
                @ApellidoPaterno,
                @ApellidoMaterno,
                @Calle,
                @NumeroInterior,
                @NumeroExterior,
                @IdColonia",
                    new SqlParameter("@Nombre", Nombre),
                    new SqlParameter("@ApellidoPaterno", ApellidoPaterno),
                    new SqlParameter("@ApellidoMaterno", ApellidoMaterno),
                    new SqlParameter("@Calle", Calle),
                    new SqlParameter("@NumeroInterior", NumeroInterior),
                    new SqlParameter("@NumeroExterior", NumeroExterior),
                    new SqlParameter("@IdColonia", IdColonia)
                );

                if (query > 0)
                {
                   
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se insertó el cliente.";
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

        public EL.Result Update(EL.Cliente cliente)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from clienteDB in _context.Cliente
                             where clienteDB.IdCliente == cliente.IdCliente
                             select clienteDB).SingleOrDefault();

                if (query != null)
                {
                    query.Nombre = cliente.Nombre;
                    query.ApellidoPaterno = cliente.ApellidoPaterno;
                    query.ApellidoMaterno = cliente.ApellidoMaterno;

                    var direccionQuery = (from direccionDB in _context.DireccionCliente
                                          where direccionDB.IdCliente == cliente.IdCliente
                                          select direccionDB).SingleOrDefault();

                    //mi direccion no estatica
                    //if (direccionQuery != null)
                    //{

                    //    direccionQuery.Calle = cliente.Direccion.Calle;
                    //    direccionQuery.NumeroInterior = cliente.Direccion.NumeroInterior;
                    //    direccionQuery.NumeroeExterior = cliente.Direccion.NumeroExterior;
                    //    direccionQuery.IdColonia = cliente.Direccion.Colonia.IdColonia;
                    //}

                    int filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Object = cliente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el cliente.";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el cliente.";
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


        public EL.Result Delete(int IdCliente)
        {
            EL.Result result = new EL.Result();

            try
            {
                var clienteArticuloList = (from ca in _context.ClienteArticulo
                                           where ca.IdCliente == IdCliente
                                           select ca).ToList();

                if (clienteArticuloList != null && clienteArticuloList.Count > 0)
                {
                    foreach (var ca in clienteArticuloList)
                    {
                        _context.ClienteArticulo.Remove(ca);
                    }
                }

                var direccionList = (from d in _context.DireccionCliente
                                     where d.IdCliente == IdCliente
                                     select d).ToList();

                if (direccionList != null && direccionList.Count > 0)
                {
                    foreach (var d in direccionList)
                    {
                        _context.DireccionCliente.Remove(d);
                    }
                }

                var cliente = (from c in _context.Cliente
                               where c.IdCliente == IdCliente
                               select c).SingleOrDefault();

                if (cliente != null)
                {
                    _context.Cliente.Remove(cliente);
                    int filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el cliente.";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el cliente.";
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
