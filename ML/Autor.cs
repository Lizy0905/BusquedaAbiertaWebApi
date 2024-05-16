using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Es necesario agregar la fecha para realizar la busqueda")]
        [Display(Name = "Nombre del Autor")]
        public string NombreAutor { get; set; }

        [Required(ErrorMessage = "Es necesario agregar la fecha para realizar la busqueda")]
        [Display(Name ="Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; } = null;
        public List<ML.Autor> Autores {get; set;} 

       
    }
}
