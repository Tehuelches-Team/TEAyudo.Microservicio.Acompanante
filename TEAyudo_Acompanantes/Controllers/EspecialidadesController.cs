using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace TEAyudo_Acompanantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public EspecialidadesController(TEAyudoContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadDTO>>> GetEspecialidades()
        {
            var especialidades = await _context.Especialidades
                .Select(e => new EspecialidadDTO
                {
                    EspecialidadId = e.EspecialidadId,
                    Descripcion = e.Descripcion
                })
                .ToListAsync();

            if (especialidades == null)
            {
                return NotFound();
            }

            return especialidades;
        }

        // GET: api/Especialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadDTO>> GetEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades
            .Where(e => e.EspecialidadId == id)
                .Select(e => new EspecialidadDTO
                {
                    EspecialidadId = e.EspecialidadId,
                    Descripcion = e.Descripcion
                })
                .FirstOrDefaultAsync();

            if (especialidad == null)
            {
                return NotFound();
            }

            return especialidad;
        }

        // PUT: api/Especialidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, EspecialidadDTO especialidadDTO)
        {
            if (id != especialidadDTO.EspecialidadId)
            {
                return BadRequest();
            }

            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades de la entidad con los valores del DTO
            especialidad.Descripcion = especialidadDTO.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Especialidades
        [HttpPost]
        public async Task<ActionResult<EspecialidadDTO>> PostEspecialidad(EspecialidadDTO especialidadDTO)
        {
            var especialidad = new Especialidad
            {
                Descripcion = especialidadDTO.Descripcion
            };

            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();

            // Actualiza el objeto DTO con el ID generado
            especialidadDTO.EspecialidadId = especialidad.EspecialidadId;

            return CreatedAtAction("GetEspecialidad", new { id = especialidadDTO.EspecialidadId }, especialidadDTO);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidades.Any(e => e.EspecialidadId == id);
        }
    }
}
