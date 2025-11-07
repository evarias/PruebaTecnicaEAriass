using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class Articulo
    {
        private readonly DL.PruebaTecnicaContext _context;

        public Articulo(DL.PruebaTecnicaContext context)
        {
            _context = context;
        }
        public EL.Result GetAll()
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.Articulo.FromSqlRaw("EXEC ArticuloGETAll").ToList();

                if (query.Count > 0)
                {
                    result.Objects = new List<object>();



                    foreach (var obj in query)
                    {
                        EL.Articulo articulo = new EL.Articulo();

                        articulo.IdArticulo = obj.IdArticulo;
                        articulo.Codigo = obj.Código;
                        articulo.Descripcion = obj.Descripcion;
                        articulo.Precio = obj.Precio;
                        articulo.Imagen = obj.Imagen;
                        articulo.Stock = Convert.ToInt16(obj.Stock);




                        result.Objects.Add(articulo);
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
        public EL.Result GetById(int IdArticulo)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from artculoDB in _context.Articulo
                             
                             where artculoDB.IdArticulo == IdArticulo
                             select new
                             {
                                 artculoDB
                             }).SingleOrDefault();

                if (query != null)
                {
                    EL.Articulo articulo = new EL.Articulo();

                    articulo.Codigo = query.artculoDB.Código;
                    articulo.Descripcion = query.artculoDB.Descripcion;
                    articulo.Precio = query.artculoDB.Precio;
                    articulo.Imagen = query.artculoDB.Imagen;
                    articulo.Stock = Convert.ToInt16(query.artculoDB.Stock);

                    result.Object = articulo;
                    
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el articulo.";
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

        public EL.Result Add(EL.Articulo articulo)
        {
           
            byte[] Imagen = new byte[0];
            if (articulo.Imagen != null) 
            {
                Imagen = articulo.Imagen;
            
            }
            

            object IdTienda = DBNull.Value, Fecha = DBNull.Value;
            if (articulo.ArticuloTienda != null)
            {
                IdTienda = articulo.ArticuloTienda.IdTienda;
                Fecha = articulo.ArticuloTienda.Fecha;
            }
            EL.Result result = new EL.Result();

            try
            {
                var query = _context.Database.ExecuteSqlRaw(
                    @"EXEC ArticuloAdd 
                @Codigo,
                @Descripcion,
                @Precio,
                @Imagen,
                @Stock,
                @IdTienda,
                @Fecha",
                    new SqlParameter("@Codigo", articulo.Codigo),
                    new SqlParameter("@Descripcion", articulo.Descripcion),
                    new SqlParameter("@Precio", articulo.Precio),
                    new SqlParameter("@Imagen", Imagen),
                    new SqlParameter("@Stock", articulo.Stock),
                    new SqlParameter("@IdTienda", IdTienda),
                    new SqlParameter("@Fecha", Fecha)
                );

                if (query > 0)
                {
                    result.Object = articulo;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se insertó el articulo.";
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

        public EL.Result Update(EL.Articulo articulo)
        {
            EL.Result result = new EL.Result();

            try
            {
                var query = (from articuloDB in _context.Articulo
                             where articuloDB.IdArticulo == articulo.IdArticulo
                             select articuloDB).SingleOrDefault();

                if (query != null)
                {
                    query.Código = articulo.Codigo;
                    query.Descripcion = articulo.Descripcion;
                    query.Precio = articulo.Precio;
                    query.Imagen = articulo.Imagen;
                    query.Stock = articulo.Stock;

                    int filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Object = articulo;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el artículo.";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el artículo.";
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

        public EL.Result Delete(int IdArticulo)
        {
            EL.Result result = new EL.Result();

            try
            {
                var var = (from at in _context.ArticuloTienda
                           where at.IdArticulo == IdArticulo
                           select at).ToList();

                if (var != null && var.Count > 0)
                {
                    foreach (var at in var)
                    {
                        _context.ArticuloTienda.Remove(at);
                    }
                }

                var articulo = (from articuloDB in _context.Articulo
                                where articuloDB.IdArticulo == IdArticulo
                                select articuloDB).SingleOrDefault();

                if (articulo != null)
                {
                    _context.Articulo.Remove(articulo);
                    int filasAfectadas = _context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el artículo.";
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el artículo.";
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
