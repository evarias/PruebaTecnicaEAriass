using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class Tienda
    {
        private readonly DL.PruebaTecnicaContext _context;
        public Tienda(DL.PruebaTecnicaContext context)
        {
            _context = context;
        }

        public EL.Result GetAll()
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.TiendaGetAllDTO.FromSqlRaw("EXEC TiendaGETAll").ToList();

                if (query.Count > 0)
                {
                    result.Objects = new List<object>();



                    foreach (var obj in query)
                    {
                        EL.Tienda tienda = new EL.Tienda();
                        tienda.Direccion = new EL.Direccion();
                        EL.Direccion direccion = new EL.Direccion();
                        direccion.Colonia = new EL.Colonia();
                        EL.Colonia colonia = new EL.Colonia();
                        colonia.Municipio = new EL.Municipio();
                        EL.Municipio municipio = new EL.Municipio();
                        municipio.Estado = new EL.Estado();

                        tienda.IdTienda = obj.IdTienda;
                        tienda.Sucursal = obj.Sucursal;
                        direccion.Calle = obj.Calle;
                        direccion.NumeroInterior = obj.NumeroInterior;
                        direccion.NumeroExterior = obj.NumeroeExterior;
                        direccion.Colonia.Nombre = obj.ColoniaNombre;
                        colonia.Municipio.Nombre = obj.MunicipioNombre;
                        municipio.Estado.Nombre = obj.EstadoNombre;


                        result.Objects.Add(tienda);
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
        public EL.Result GetById(int IdTienda)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from tienda in _context.Tienda
                             join direccion in _context.DireccionTienda on tienda.IdTienda equals direccion.IdTienda
                             join colonia in _context.Colonia on direccion.IdColonia equals colonia.IdColonia
                             join municipio in _context.Municipio on colonia.IdMunicipio equals municipio.IdMunicipio
                             join estado in _context.Estado on municipio.IdEstado equals estado.IdEstado
                             where tienda.IdTienda == IdTienda
                             select new
                             {
                                 tienda.IdTienda,
                                 tienda.Sucursal,
                                 direccion.Calle,
                                 direccion.NumeroInterior,
                                 direccion.NumeroeExterior,
                                 ColoniaNombre = colonia.Nombre,
                                 MunicipioNombre = municipio.Nombre,
                                 EstadoNombre = estado.Nombre
                             }).SingleOrDefault();

                if (query != null)
                {
                    EL.Tienda tienda = new EL.Tienda();
                    tienda.Direccion = new EL.Direccion();
                    tienda.Direccion.Colonia = new EL.Colonia();
                    tienda.Direccion.Colonia.Municipio = new EL.Municipio();
                    tienda.Direccion.Colonia.Municipio.Estado = new EL.Estado();

                    tienda.IdTienda = query.IdTienda;
                    tienda.Sucursal = query.Sucursal;

                    tienda.Direccion.Calle = query.Calle;
                    tienda.Direccion.NumeroInterior = query.NumeroInterior;
                    tienda.Direccion.NumeroExterior = query.NumeroeExterior;
                    tienda.Direccion.Colonia.Nombre = query.ColoniaNombre;
                    tienda.Direccion.Colonia.Municipio.Nombre = query.MunicipioNombre;
                    tienda.Direccion.Colonia.Municipio.Estado.Nombre = query.EstadoNombre;

                    result.Object = tienda;
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

        public EL.Result Add(string Sucursal)
        {
            var Calle = "16 sur";
            var NumeroInterior = "1703";
            var NumeroExterior = "";
            var IdColonia = 5;
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.Database.ExecuteSqlRaw(
                    @"EXEC TiendaAdd 
                @Sucursal,
                @Calle,
                @NumeroInterior,
                @NumeroExterior,
                @IdColonia",
                    new SqlParameter("@Sucursal", Sucursal),
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

        public EL.Result Update(EL.Tienda tienda)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from tiendaDB in _context.Tienda
                             where tiendaDB.IdTienda == tienda.IdTienda
                             select tiendaDB).SingleOrDefault();

                if (query != null)
                {
                    query.Sucursal = tienda.Sucursal;

                   

                    int filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Object = tienda;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó la tienda.";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró la tienda.";
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

        public EL.Result Delete(int IdTienda)
        {
            EL.Result result = new EL.Result();

            try
            {
                var var = (from ta in _context.ArticuloTienda
                                           where ta.IdTienda == IdTienda
                                           select ta).ToList();

                if (var != null && var.Count > 0)
                {
                    foreach (var ta in var)
                    {
                        _context.ArticuloTienda.Remove(ta);
                    }
                }
                //bl.direcciontienda.delete()
                var direccionList = (from d in _context.DireccionTienda
                                     where d.IdTienda == IdTienda
                                     select d).ToList();

                if (direccionList != null && direccionList.Count > 0)
                {
                    foreach (var d in direccionList)
                    {
                        _context.DireccionTienda.Remove(d);
                    }
                }

                var tienda = (from tiendaDB in _context.Tienda
                               where tiendaDB.IdTienda == IdTienda
                              select tiendaDB).SingleOrDefault();

                if (tienda != null)
                {
                    _context.Tienda.Remove(tienda);
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
