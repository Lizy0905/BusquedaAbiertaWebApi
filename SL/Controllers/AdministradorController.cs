using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class AdministradorController : ApiController
    {
        [HttpGet]
        [Route("Api/Admin/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            var result = BL.Libro.GetAllLibro();
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }


        [HttpGet]
        [Route("Api/Admin/GetById/{IdLibro}")]
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




        [HttpPost]
        [Route("Api/Admin/Add")]
        public IHttpActionResult Add([FromBody] ML.Libro libro)
        {
            var result = BL.Libro.Add(libro);
            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpPut]
        [Route("Api/Admin/Update")]
        public IHttpActionResult Update([FromBody] ML.Libro libro)
        {
            var result = BL.Libro.Update(libro);
            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpDelete]
        [Route("Api/Admin/Delete/{IdLibro},{IdAutor}, {IdEditorial}")]
        public IHttpActionResult Delete(int IdLibro, int IdAutor, int IdEditorial)
        {
            var result = BL.Libro.Delete(IdLibro, IdAutor, IdEditorial);
            if (result.Item1)
            {
                return Ok(result.Item1);
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }
    }
}
