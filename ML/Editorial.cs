using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Editorial
    {
        public int IdEditorial { get; set; }

        [Display(Name = "Nombre Editorial")]
        public string NombreEdit { get; set; }
        public string Ciudad { get; set; }

        public List<ML.Editorial> Editoriales { get; set; }

    }
}
