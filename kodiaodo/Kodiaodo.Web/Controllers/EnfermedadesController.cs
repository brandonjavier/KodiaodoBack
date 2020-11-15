using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kodiaodo.Web.Models.Almacen.Enfermedad;
using Kodiaodo.Datos;
using Microsoft.EntityFrameworkCore;
using Kodiaodo.Entidades.Almacen;

namespace Kodiaodo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadesController : ControllerBase
    {
        private readonly DbContextKodiaodo _context;

        public EnfermedadesController(DbContextKodiaodo context)
        {
            _context = context;
        }

        // GET: api/Enfermedades/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<EnfermedadViewModel>> Listar()
        {
            var enfermedad = await _context.Enfermedades.ToListAsync();
            return enfermedad.Select(e => new EnfermedadViewModel
            {
                idenfermedad = e.idenfermedad,
                nombre = e.nombre,
                descripcion = e.descripcion,
                condicion = e.condicion
            });
        }

        // GET: api/Enfermedades/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> Mostrar ([FromRoute]int id)
        {
            var enfermedad = await _context.Enfermedades.FindAsync(id);
            if(enfermedad == null)
            {
                return NotFound();
            }
            
            return Ok(new EnfermedadViewModel
            {
                idenfermedad = enfermedad.idenfermedad,
                nombre = enfermedad.nombre,
                descripcion = enfermedad.descripcion,
                condicion = enfermedad.condicion
            });
        }

        // PUT: api/Enfermedades/Actualizar
       
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(model.idenfermedad <=0)
            {
                return BadRequest();
            }

            var enfermedad = await _context.Enfermedades.FirstOrDefaultAsync(e => e.idenfermedad == model.idenfermedad);
            
            if (enfermedad == null)
            {
                return NotFound();
            }

            enfermedad.nombre = model.nombre;
            enfermedad.descripcion = model.descripcion;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Enfermedades/Crear

        [HttpPost("[action]")]
        public async Task<ActionResult<Enfermedad>> Crear([FromBody] CrearViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enfermedad enfermedad = new Enfermedad
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            } ;
            _context.Enfermedades.Add(enfermedad);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception )
            {

                return BadRequest();
            }
            return Ok();

        }

        // DELETE: api/Enfermedades/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Eliminar ([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enfermedad = await _context.Enfermedades.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            _context.Enfermedades.Remove(enfermedad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception )
            {
                return BadRequest();
            }
            return Ok(enfermedad);
        }


        // PUT: api/Enfermedades/Desactivar/1

        [HttpPut("[action]/ { id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {
    
            if (id <= 0)
            {
                return BadRequest();
            }

            var enfermedad = await _context.Enfermedades.FirstOrDefaultAsync(e => e.idenfermedad == id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            enfermedad.condicion = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Enfermedades/Activar/2

        [HttpPut("[action]/ { id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var enfermedad = await _context.Enfermedades.FirstOrDefaultAsync(e => e.idenfermedad == id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            enfermedad.condicion = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        private bool EnfermedadExists(int id)
        {
            return _context.Enfermedades.Any(e => e.idenfermedad == id);
        }
    }
}
