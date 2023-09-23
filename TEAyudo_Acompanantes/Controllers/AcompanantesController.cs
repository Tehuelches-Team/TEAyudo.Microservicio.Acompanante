using Application.Interfaces.Aplication;
using Microsoft.AspNetCore.Mvc;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace TEAyudo_Acompanantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanantesController : Controller
    {
        private readonly IFiltroAcompanante _filtro;
        public AcompanantesController(IFiltroAcompanante filtro)
        {
            _filtro = filtro;
        }

        [HttpGet("ObraSocial")]
        public async Task<ActionResult<IEnumerable<Acompanante>>> GetAcompanante(string ObraSocial)
        {
            List<AcompananteDTO> result = await _filtro.FiltarObraSocial(ObraSocial);

            if(result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("ZonaLaboral")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteZonaLaboral(string zonalaboral)
        {
            List<AcompananteDTO> result = await _filtro.FiltarZonaLaboral(zonalaboral);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Especialidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteEspecialidad(string Especialidad)
        {
            List<AcompananteDTO> result = await _filtro.FiltarEspecialidad(Especialidad);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Disponibilidad")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteDisponibilidad(int Disponibilidad)
        {
            List<AcompananteDTO> result = await _filtro.FiltrarDisponibilidadSemanal(Disponibilidad);

            if (result == null)
            {
                return BadRequest();
            } else if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<IEnumerable<AcompananteDTO>>> GetAcompananteId(int Id)
        {
            AcompananteDTO result = await _filtro.FiltrarId(Id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
