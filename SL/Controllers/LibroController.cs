using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class LibroController : ApiController
    {

        [HttpGet]
        [Route("Api/Libro/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Libro.GetAllLibro();
            if (result.Item1)
            {
                return Ok(result.Item3);
                //return Content(HttpStatusCode.OK, result.Item3.Libros);
            }
            else
            {
                // return Content(HttpStatusCode.BadRequest, result.Item2);
                return BadRequest(result.Item2);
            }
        }

        [HttpPost]
        [Route("Api/Libro/GetAll")]
        public IHttpActionResult GetAll([FromBody] ML.Libro libro)
        {

            if (libro != null)
            {
                //Titulo
                if (libro.Titulo != null && libro.Titulo != "")
                {
                    var resultado = BL.Libro.BusquedaTitulo(libro.Titulo);
                    if (resultado.Item1)
                    {
                        return Ok(resultado.Item3);
                    }
                    else
                    {
                        return BadRequest(resultado.Item2);
                    }
                }
                else
                {
                    //Editorial
                    if (libro.Editorial.NombreEdit != null && libro.Editorial.NombreEdit != "")
                    {
                        var editorial = BL.Libro.BusquedaEditorial(libro.Editorial.NombreEdit);
                        return Ok(editorial.Item3);
                    }
                    else
                    {


                        if(libro.FechaPublicacion > 0)
                        {
                          
                            if (libro.Autor.NombreAutor != null || libro.Autor.ApellidoPaterno != null)
                            {
                                libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                                libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                                libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                                var result = BL.Libro.BusquedaFechaAutor(libro.FechaPublicacion, libro.Autor.NombreAutor, libro.Autor.ApellidoPaterno);
                                if (result.Item1)
                                {
                                    return Ok(result.Item3);
                                }
                                else
                                {
                                    return BadRequest(result.Item2);
                                }
                            }
                            else
                            {
                                libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                                libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                                libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                                var result = BL.Libro.BusquedaFechaAutor(libro.FechaPublicacion, libro.Autor.NombreAutor, libro.Autor.ApellidoPaterno);
                                if (result.Item1)
                                {
                                    return Ok(result.Item3);
                                }
                                else
                                {
                                    return BadRequest(result.Item2);
                                }


                            }
                        }
                        else
                        {
                            if (libro.Autor.NombreAutor != null || libro.Autor.ApellidoPaterno != null || libro.Autor.ApellidoMaterno != null)
                            {
                                libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                                libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                                libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                                var result = BL.Libro.BusquedaAutor(libro);
                                if (result.Item1)
                                {
                                    return Ok(result.Item3);
                                }
                                else
                                {
                                    return BadRequest(result.Item2);
                                }
                            }
                            else
                            {

                                if (libro.FechaPublicacionD > 0)
                                {
                                    var fechaP = BL.Libro.BusquedaFecha(libro.FechaPublicacionD);
                                    if (fechaP.Item1)
                                    {
                                        return Ok(fechaP.Item3);
                                    }
                                    else
                                    {
                                        return BadRequest(fechaP.Item2);
                                    }
                                }
                                else
                                {
                                    return BadRequest();
                                }
                            }

                        }



                        //entra si tiene ambos
                        // autor b-nombre and apeP &&
                        //Si hay una entidad diferente a la principal hay que mandar el json con la propiedad en nullo o vacia
                          //libro.Autor.NombreAutor != null || libro.Autor.ApellidoPaterno != null && libro.FechaPublicacion > 0
                        //if (libro.Autor.NombreAutor != null  || libro.Autor.ApellidoPaterno != null )
                        //{
                        //    libro.Autor.NombreAutor = libro.Autor.NombreAutor == null ? "" : libro.Autor.NombreAutor;
                        //    libro.Autor.ApellidoPaterno = libro.Autor.ApellidoPaterno == null ? "" : libro.Autor.ApellidoPaterno;
                        //    libro.Autor.ApellidoMaterno = libro.Autor.ApellidoMaterno == null ? "" : libro.Autor.ApellidoMaterno;

                        //    var result = BL.Libro.BusquedaFechaAutor( libro.FechaPublicacion, libro.Autor.NombreAutor, libro.Autor.ApellidoPaterno);
                        //    if (result.Item1)
                        //    {
                        //        return Ok(result.Item3);
                        //    }
                        //    else
                        //    {
                        //        return BadRequest(result.Item2);
                        //    }
                        //}
                        //else
                        //{
                        //    
                        //}
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("Api/Libro/GetById/{IdLibro}")]
        public IHttpActionResult GetById(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            var result = BL.Libro.GetById(IdLibro);
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }



    }
}

