using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }

        [Display(Name = "Fecha de Publicacion")]
        //[DataType(DataType.Date)]
        public DateTime FechaPublic { get; set; }

      
        public int FechaPublicacion { get; set; }

        [Required(ErrorMessage = "Es necesario agregar la fecha para realizar la busqueda")]
        public int FechaPublicacionD { get; set; }

        public ML.Editorial Editorial { get; set; }
        public ML.Autor Autor { get; set; }

        public List<ML.Libro> Libros { get; set; }
        public string Descripcion { get; set; }

    }
}
