using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        //Se utilizan librerias .net Http
        //Newtonsoft json 
        //Install-Package Microsoft.AspNet.WebApi.Client
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/");
                var responseTask = client.GetAsync("Api/Libro/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Libro>();
                    readTask.Wait();

                    libro.Libros = new List<ML.Libro>();
                    foreach (var registros in readTask.Result.Libros)
                    {
                      //var objDeserializado = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(registros.ToString());
                        libro.Libros.Add(registros);
                    }
                    return View(libro);
                }
                else
                {
                    return View(libro);
                }
            }
            //ML.Libro libro = new ML.Libro();
            //var result = BL.Libro.GetAll();
            //if (result.Item1)
            //{
            //    libro.Libros = result.Item3.Libros;
            //}
            //return View(libro);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Libro libro)
        {

            //if (ModelState.IsValid)
            //{

                //ML.Libro libro = new ML.Libro();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.PostAsJsonAsync<ML.Libro>("Api/Libro/GetAll", libro);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Libro>();
                        readTask.Wait();

                        libro.Libros = new List<ML.Libro>();
                        foreach (var registros in readTask.Result.Libros)
                        {
                            libro.Libros.Add(registros);
                        }
                        return View(libro);
                    }

                    else
                    {
                        return View(libro);
                    }


                }
            //}
            //else
            //{
            //    return View(libro);
            //}

                ////if(libro.FechaPublic != ) toshorttime
                //if (libro.Autor.NombreAutor != null && libro.Autor.ApellidoPaterno != null && libro.Autor.ApellidoMaterno != null && libro.FechaPublic != null)
                //{    //Operador ternario
                //    ////Si el nombre del autor es igual a null entonces de va vacio "" y si no se va su valor
                //    libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                //    libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                //    libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                //    var resul = BL.Libro.BusquedaAutor(libro);
                //    libro.Libros = new List<ML.Libro>();
                //    libro.Libros = resul.Item3.Libros;
                //    return View(libro);

                //}
                //else
                //{
                //    if (libro.Autor.NombreAutor != null || libro.Autor.ApellidoPaterno != null | libro.Autor.ApellidoMaterno != null)
                //    {
                //        libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                //        libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                //        libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                //        var resul = BL.Libro.BusquedaAutor(libro);
                //        libro.Libros = new List<ML.Libro>();
                //        libro.Libros = resul.Item3.Libros;
                //        return View(libro);
                //    }
                //    else
                //    {
                //        if (libro.Titulo != null && libro.Titulo != "")
                //        {
                //            libro.Titulo = libro.Titulo == null ? "" : libro.Titulo;

                //            var result = BL.Libro.BusquedaTitulo(libro.Titulo);

                //                libro.Libros = new List<ML.Libro>();
                //                libro.Libros = result.Item3.Libros;
                //                return View(libro);
                //        }
                //        else
                //        {

                //            if (libro.Editorial.NombreEdit != null)
                //            {
                //                var editorial = BL.Libro.BusquedaEditorial(libro.Editorial.NombreEdit);
                //                if (editorial.Item1)
                //                {
                //                    libro.Libros = new List<ML.Libro>();
                //                    libro.Libros = editorial.Item3.Libros;
                //                    return View(libro);
                //                }
                //                else
                //                {

                //                    return View();
                //                }
                //            }
                //            else
                //            {


                //                if (libro.FechaPublic.ToString("yyyy") != null)
                //                {
                //                    var resultado = BL.Libro.BusquedaFecha(libro.FechaPublic);
                //                    if (resultado.Item1)
                //                    {
                //                        libro.Libros = new List<ML.Libro>();
                //                        libro.Libros = resultado.Item3.Libros;
                //                        return View(libro);
                //                    }
                //                    else
                //                    {
                //                        return View(libro);
                //                    }
                //                }
                //                else
                //                {
                //                    return View();
                //                }
                //            }
                //            return View();
                //        }
                //    }
                //}
          
        }

        public ActionResult Description( int IdLibro)
        {
            ML.Libro libro1 = new ML.Libro();
            libro1.Autor = new ML.Autor();

            if (IdLibro > 0)
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.GetAsync($"Api/Libro/GetById/{IdLibro}");
                    responseTask.Wait();

                    var resultados = responseTask.Result;
                    if (resultados.IsSuccessStatusCode)
                    {
                        var readTask = resultados.Content.ReadAsAsync<ML.Libro>();
                        readTask.Wait();

                        if (readTask != null)
                        {
                            libro1 = readTask.Result;

                            //Dado a que las listas de los dropdownList aparecian como nulas es importante volver a 
                            //instanciarlas ademas de llenar las listas de valores para que puedan ser recuperador en la vista
                            //libro1.Editorial.Editoriales = new List<ML.Editorial>();
                            //libro1.Autor.Autores = new List<ML.Autor>();
                            //libro1.Autor.Autores = result.Item3.Autores;
                            //libro1.Editorial.Editoriales = resultado.Item3.Editoriales;
                        }
                        return View(libro1);
                    }
                    else
                    {
                        return View(libro1);
                    }
                }
            }
            else
            {
                return View(libro1);
            }
            //return View(libro1);
        }



    }
}