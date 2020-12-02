using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kodiaodo.Entidades.Almacen
{
    public class Signo
    {
        public int idsigno { get; set; }
        [Required]
        public int idenfermedad { get; set; }
        public string codigo { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [Required]
        public decimal value { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }
        

        public Enfermedad enfermedad { get; set; }
    }
}

