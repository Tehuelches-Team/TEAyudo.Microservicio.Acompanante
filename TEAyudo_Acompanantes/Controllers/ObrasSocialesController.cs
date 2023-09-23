using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace TEAyudo_Acompanantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly TEAyudoContext _context;

        public ObrasSocialesController(TEAyudoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraSocial>>> GetObrasSociales()
        {
            return await _context.ObrasSociales.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ObraSocial>> GetObraSocial(int id)
        {
            var obraSocial = await _context.ObrasSociales.FindAsync(id);

            if (obraSocial == null)
            {
                return NotFound();
            }

            return obraSocial;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutObraSocial(int id, ObraSocialDTO obraSocialDTO)
        {
            if (id != obraSocialDTO.ObraSocialId)
            {
                return BadRequest();
            }

            var obraSocial = new ObraSocial
            {
                ObraSocialId = obraSocialDTO.ObraSocialId,
                Nombre = obraSocialDTO.Nombre,
                Descripcion = obraSocialDTO.Descripcion
            };

            _context.Entry(obraSocial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraSocialExists(id))
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


        [HttpPost]
        public async Task<ActionResult<ObraSocial>> PostObraSocial(ObraSocialDTO obraSocialDTO)
        {
            var obraSocial = new ObraSocial
            {
                Nombre = obraSocialDTO.Nombre,
                Descripcion = obraSocialDTO.Descripcion
            };

            _context.ObrasSociales.Add(obraSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObraSocial", new { id = obraSocial.ObraSocialId }, obraSocial);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObraSocial(int id)
        {
            var obraSocial = await _context.ObrasSociales.FindAsync(id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            _context.ObrasSociales.Remove(obraSocial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObraSocialExists(int id)
        {
            return _context.ObrasSociales.Any(e => e.ObraSocialId == id);
        }
    }
}
