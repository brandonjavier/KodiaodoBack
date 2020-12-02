using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kodiaodo.Entidades.Almacen
{
    public class Enfermedad
    {
        public int idenfermedad { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="El nombre no debe tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(250)]
        public string descripcion{ get; set; }
        public bool condicion { get; set; }

        public ICollection<Signo> signo { get; set; }


    }
}
