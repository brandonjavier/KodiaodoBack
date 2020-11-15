using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kodiaodo.Web.Models.Almacen.Enfermedad
{
    public class CrearViewModel
    {
        
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(250)]
        public string descripcion { get; set; }
    }
}
