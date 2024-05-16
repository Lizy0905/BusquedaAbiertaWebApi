using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static (bool, string, ML.Libro, Exception) GetAll()
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.AutorGetAll().ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor;
                            libro1.Autor.NombreAutor = registros.Nombre;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro.Libros.Add(libro1);
                        }
                        return (true, "Registros encontrados", libro, null);
                    }
                    else
                    {
                        return (false, "Registros encontrados", libro, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, libro, ex);
            }
        }


      

        public static (bool, string, ML.Autor, Exception) AutorGetAll()
        {
            ML.Autor autor = new ML.Autor();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllAutor().ToList();

                    if (query != null)
                    {
                        autor.Autores = new List<ML.Autor>();
                        foreach (var registros in query)
                        {
                            ML.Autor autor1 = new ML.Autor();
                            autor1.IdAutor = registros.IdAutor;
                            autor1.NombreAutor = registros.Nombre;
                            autor1.ApellidoPaterno = registros.ApellidoPaterno;
                            autor1.ApellidoMaterno = registros.ApellidoMaterno;

                            autor.Autores.Add(autor1);
                        }
                        return (true, "Registros encontrados", autor, null);
                    }
                    else
                    {
                        return (false, "Registros no encontrados", autor, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        //public static (bool, string, Exception) AutorByNPM(ML.Autor autor)
        //{

        //    try
        //    {
        //        using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
        //        {
        //            var query = context.ExistAutor(autor.NombreAutor, autor.ApellidoPaterno, autor.ApellidoMaterno).ToList();

        //            if (query != null)
        //            {
        //                return (true, "Registros encontrados", null);
        //            }
        //            else
        //            {
        //                return (false, "Registros no encontrados", null);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, ex);
        //    }
        //}

    }
}
