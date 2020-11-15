using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodiaodo.Web.Models.Almacen.Enfermedad
{
    public class EnfermedadViewModel
    {
        public int idenfermedad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }
}
