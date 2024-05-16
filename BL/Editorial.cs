using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static (bool, string, ML.Libro, Exception) GetAll()
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.EditorialGetAll().ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial;
                            libro1.Editorial.NombreEdit = registros.Nombre;
                            libro1.Editorial.Ciudad = registros.ciudad;
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



        public static (bool, string, ML.Editorial, Exception) EditorialGetAll()
        {
            ML.Editorial editorial = new ML.Editorial();
            try
            {   
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllEditorial().ToList();

                    if(query != null)
                    {
                        editorial.Editoriales = new List<ML.Editorial>();
                        foreach(var registros in query)
                        {
                            ML.Editorial objEditorial = new ML.Editorial();
                            objEditorial.IdEditorial = registros.IdEditorial;
                            objEditorial.NombreEdit = registros.Nombre;
                            objEditorial.Ciudad = registros.Ciudad;
                   

                            editorial.Editoriales.Add(objEditorial);
                        }
                        return (true, "Registros encontrados", editorial, null);
                    }
                    else
                    {
                        return (false, "Registros no encontrados", editorial, null);
                    }
                }
            }
            catch(Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        //public static (bool, string, Exception) EditorialNC(ML.Editorial editorial)
        //{
           
        //    try
        //    {
        //        using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
        //        {
        //            var query = context.ExistEditorial(editorial.NombreEdit, editorial.Ciudad).ToList();

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
