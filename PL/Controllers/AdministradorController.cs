using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Administrador()
        {
            ML.Libro libro = new ML.Libro();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/");
                var responseTask = client.GetAsync("Api/Admin/GetAll");
                responseTask.Wait();

                var resultTask = responseTask.Result;
                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<ML.Libro>();
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
            //var result = BL.Libro.GetAll();
            //if (result.Item1)
            //{
            //    libro.Libros = result.Item3.Libros;
            //}
            //return View(libro);
        }


        public ActionResult AddLibro(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            ML.Libro libro1 = new ML.Libro();
            libro1.Autor = new ML.Autor();
            libro1.Editorial = new ML.Editorial();
            var result = BL.Autor.AutorGetAll();
            var resultado = BL.Editorial.EditorialGetAll();
            libro1.Editorial.Editoriales = new List<ML.Editorial>();
            libro1.Autor.Autores = new List<ML.Autor>();
            libro1.Autor.Autores = result.Item3.Autores;
            libro1.Editorial.Editoriales = resultado.Item3.Editoriales;


            if (IdLibro > 0)
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.GetAsync($"Api/Admin/GetById/{IdLibro}");
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
                            libro1.Editorial.Editoriales = new List<ML.Editorial>();
                            libro1.Autor.Autores = new List<ML.Autor>();
                            libro1.Autor.Autores = result.Item3.Autores;
                            libro1.Editorial.Editoriales = resultado.Item3.Editoriales;
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
        }

        [HttpPost]
        public ActionResult AddLibro(ML.Libro libro)
        {
            var resultado = BL.Libro.GetById(libro.IdLibro);
            if (libro.Imagen == null)
            {
                libro.Imagen = resultado.Item3.Imagen;
            }

            HttpPostedFileBase file = Request.Files["Imagen"];
            if (file.ContentLength > 0)
            {
                libro.Imagen = ConvertirABase64(file);
            }
            if (libro.IdLibro > 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.PutAsJsonAsync<ML.Libro>("Api/Admin/Update", libro);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Text = "Registro Actualizado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Text = "Registro No Actualizado";
                        return PartialView("Modal");

                    }
                }
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.PostAsJsonAsync<ML.Libro>("Api/Admin/Add", libro);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Text = "Registro Agregado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Text = "Registro No Agregado";
                        return PartialView("Modal");
                    }
                }
            }
        }




        //listo
        public ActionResult Delete(int IdLibro, int IdAutor, int IdEditorial)
        {
            if (IdLibro > 0 & IdAutor > 0 & IdEditorial > 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44311/");
                    var responseTask = client.DeleteAsync($"Api/Admin/Delete/{IdLibro},{IdAutor}, {IdEditorial}");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Text = "Registro Eliminado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Text = "Registro No Eliminado";
                        return PartialView("Modal");
                    }
                }

            }
            else
            {
                ViewBag.Text = "No hay ningun Id";
                return PartialView("Modal");
            }
        }

        //Metodo para convertir a string una imagen 
        public string ConvertirABase64(HttpPostedFileBase imagen)
        {
            // Paso 1: Crear un BinaryReader para leer el archivo de imagen en formato binario.
            System.IO.BinaryReader reader = new System.IO.BinaryReader(imagen.InputStream);
            // Paso 2: Leer los bytes de la imagen y almacenarlos en un arreglo de bytes.
            byte[] data = reader.ReadBytes((int)imagen.ContentLength);
            // Paso 3: Convertir los bytes de la imagen a una cadena en formato Base64.
            string foto = Convert.ToBase64String(data);
            // Paso 4: Devolver la cadena en formato Base64 que representa la imagen.
            return foto;
        }




    }
}