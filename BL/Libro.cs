using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {

        //public static(bool, string, ML.Libro, Exception) GetAll()
        //{
        //    ML.Libro libro = new ML.Libro();
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(DL.Conexion.GetConnection());
        //        string query = "LibroGetAll";
        //        SqlCommand sqlCommand = new SqlCommand(query, connection);

        //        DataTable tableLibros = new DataTable();
        //        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        //        adapter.Fill(tableLibros);
        //        if(tableLibros.Rows.Count != null)
        //        {
        //            libro.Libros = new List<ML.Libro>();

        //            foreach(DataRow fila in tableLibros.Rows)
        //            {
        //                ML.Libro objLibro = new ML.Libro();
        //                objLibro.Titulo = fila[0].ToString();
        //                objLibro.FechaPublic = DateTime.Parse(fila[1].ToString());
        //                objLibro.Autor = new ML.Autor();
        //                objLibro.Autor.IdAutor = int.Parse(fila[2].ToString());
        //                objLibro.Editorial = new ML.Editorial();
        //                objLibro.Editorial.IdEditorial = int.Parse(fila[3].ToString());
        //                objLibro.Editorial.NombreEdit = fila[4].ToString();
        //                objLibro.Editorial.Ciudad = fila[5].ToString();
        //                objLibro.Autor.NombreAutor = fila[6].ToString();
        //                objLibro.Autor.ApellidoPaterno = fila[7].ToString();
        //                objLibro.Autor.ApellidoMaterno = fila[8].ToString();
        //                objLibro.Imagen = fila[9].ToString();
                       
                        
        //                libro.Libros.Add(objLibro);
        //            }
        //            return (true, "registros ", libro, null);
        //        }
        //        else
        //        {
        //            return (true, "registros ", libro, null);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return (false, ex.Message, libro, ex);
        //    }
        //}

        //public static (bool, string, ML.Libro, Exception) GetAllByTitulo(string Titulo)
        //{
        //    ML.Libro libro = new ML.Libro();
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(DL.Conexion.GetConnection());
        //        string query = "GetAllBusqTitulo";
        //        SqlCommand sqlCommand = new SqlCommand(query, connection);
        //        SqlParameter[] sqlParameters = new SqlParameter[1];
        //        sqlParameters[0] = new SqlParameter("Titulo", System.Data.SqlDbType.VarChar,50);
        //        sqlParameters[0].Value = Titulo;

        //        sqlCommand.Parameters.AddRange(sqlParameters);

        //        DataTable tableLibros = new DataTable();
        //        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        //        adapter.Fill(tableLibros);
        //        if (tableLibros != null)
        //        {
        //            //Se agrega data row para almacenar las filas de la tabla y se agrega la fila [0]
        //            DataRow fila = tableLibros.Rows[0];

        //            ML.Libro objLibro = new ML.Libro();
        //            objLibro.Titulo = fila[0].ToString();
        //            objLibro.FechaPublic = DateTime.Parse(fila[1].ToString());
        //            objLibro.Autor = new ML.Autor();
        //            objLibro.Autor.IdAutor = int.Parse(fila[2].ToString());
        //            objLibro.Editorial = new ML.Editorial();
        //            objLibro.Editorial.IdEditorial = int.Parse(fila[3].ToString());
        //            objLibro.Editorial.NombreEdit = fila[4].ToString();
        //            objLibro.Editorial.Ciudad = fila[5].ToString();
        //            objLibro.Autor.NombreAutor = fila[6].ToString();
        //            objLibro.Autor.ApellidoPaterno = fila[7].ToString();
        //            objLibro.Autor.ApellidoMaterno = fila[8].ToString();
        //            return (true, "registros ", libro, null);
        //        }
        //        else
        //        {
        //            return (true, "registros ", libro, null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, libro, ex);
        //    }
        //}
        public static (bool, string, ML.Libro, Exception) GetAllLibro()
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.LibroGetAll().ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
                            libro.Libros.Add(libro1);

                           // speacht manera de contestar en entrevista 
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


        public static (bool, string, ML.Libro, Exception) GetById(int IdLibro)
        {
            ML.Libro libro1 = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.LibroGetById(IdLibro).FirstOrDefault();
                    if (query != null)
                    {
                        
                            libro1.IdLibro = query.IdLibro;
                            libro1.Titulo = query.Titulo;
                            libro1.FechaPublic = query.FechaPublic.Value;
                            libro1.Imagen = query.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = query.IdAutor.Value;
                            libro1.Autor.NombreAutor = query.NombreAutor;
                            libro1.Autor.ApellidoPaterno = query.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = query.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = query.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = query.NombreEdit;
                            libro1.Editorial.Ciudad = query.Ciudad;
                            libro1.Descripcion = query.Descripcion;
                            
                      
                        return (true, "Registros encontrados", libro1, null);
                    }
                    else
                    {
                        return (false, "Registros encontrados", libro1, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, libro1, ex);
            }
        }


        public static (bool, string, ML.Libro, Exception) BusquedaTitulo(string titulo)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllBusqTitulo(titulo).ToList();
                    if(query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach(var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
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
            catch(Exception ex)
            {
                return (false, ex.Message, libro, ex );
            }
        }


        public static (bool, string, ML.Libro, Exception) BusquedaAutor(ML.Libro autor)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllBusqAutor(autor.Autor.NombreAutor, autor.Autor.ApellidoPaterno, autor.Autor.ApellidoMaterno).ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
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

        public static (bool, string, ML.Libro, Exception) BusquedaFecha(int fecha)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllBusFechaPub(fecha).ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
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

        public static (bool, string, ML.Libro, Exception) BusquedaEditorial(string editorial)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllBusqEditorial(editorial).ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
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

        public static (bool, string, ML.Libro, Exception) BusquedaFechaAutor(int fecha, string nombre, string apellido)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var query = context.GetAllBusFechaPubAutor(nombre, apellido, fecha).ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in query)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = registros.IdLibro;
                            libro1.Titulo = registros.Titulo;
                            libro1.FechaPublic = registros.FechaPublic.Value;
                            libro1.Imagen = registros.Imagen;
                            libro1.Autor = new ML.Autor();
                            libro1.Autor.IdAutor = registros.IdAutor.Value;
                            libro1.Autor.NombreAutor = registros.NombreAutor;
                            libro1.Autor.ApellidoPaterno = registros.ApellidoPaterno;
                            libro1.Autor.ApellidoMaterno = registros.ApellidoMaterno;
                            libro1.Editorial = new ML.Editorial();
                            libro1.Editorial.IdEditorial = registros.IdEditorial.Value;
                            libro1.Editorial.NombreEdit = registros.NombreEdit;
                            libro1.Editorial.Ciudad = registros.Ciudad;
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

        public static (bool, string, Exception) Add(ML.Libro libro)
        {
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var rowAffected = context.LibroAdd(libro.Titulo, libro.FechaPublic, libro.Autor.IdAutor, libro.Editorial.IdEditorial, libro.Imagen, libro.Descripcion);
                    if (rowAffected > 0)
                    {
                        return (true, "Registro Agregado Correctamente", null);
                    }
                    else
                    {
                        return (false, "Registro No Agregado", null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }



        public static(bool, string, Exception) Update(ML.Libro libro)
        {
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var rowAffected = context.LibroUpdate(libro.Titulo, libro.FechaPublic, libro.Editorial.IdEditorial,libro.Autor.IdAutor, libro.IdLibro,libro.Imagen, libro.Descripcion);
                    if(rowAffected > 0)
                    {
                        return (true, "Registro Actualizado", null);
                    }
                    else
                    {
                        return (false, "Registro No Actualizado", null);
                    }
                }
            } catch(Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }

        public static(bool, string, Exception) Delete(int IdLibro, int IdAutor, int IdEditorial)
        {
            try
            {
                using (DL.PVillaBusquedaLibrosEntities context = new DL.PVillaBusquedaLibrosEntities())
                {
                    var rowAffected = context.LibroDeleteAutor(IdLibro, IdAutor, IdEditorial);
                    if(rowAffected > 0)
                    {
                        return (true, "Registro eliminado", null);
                    }
                    else
                    {
                        return (false, "Registro no eliminado", null);
                    }
                }
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex);
            }
        }




    }
}
