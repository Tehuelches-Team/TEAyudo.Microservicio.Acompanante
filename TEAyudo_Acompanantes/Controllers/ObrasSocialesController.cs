using Application.Interfaces.Application;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace TEAyudo_Acompanantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly IObraSocialService _Service;

        public ObrasSocialesController(IObraSocialService Service)
        {
            _Service = Service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraSocialResponse>>> GetObrasSociales()
        {
            List<ObraSocialResponse> ObraSociales = await _Service.GetObraSociales();

            if (ObraSociales.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron obras sociales registradas en la base de datos" };
                return NotFound(Respuesta);
                //Error no hay especialidades registradas aunque se supone que si o si debe de existir ya que no hay filtros.
            }

            return ObraSociales; //Controlar http code
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<ObraSocialResponse>> GetObraSocial(int Id)
        {
            ObraSocialResponse? ObraSocial = await _Service.GetObraSocialById(Id);

            if (ObraSocial == null)
            {
                var Respuesta = new { Motivo = "No se encontraron obras sociales asociadas al id: " + Id };
                return NotFound(Respuesta);
            }

            return ObraSocial;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutObraSocial(int Id, ObraSocialDTO ObraSocialDTO)
        {

            if (!await _Service.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron obras sociales asociadas al id: " + Id };
                return NotFound(Respuesta);
            }

            ObraSocialResponse? ObraSocial = await _Service.UpdateObraSocial(Id, ObraSocialDTO);

            if (ObraSocial == null)
            {
                var Respuesta = new { Motivo = "No es posible actualizar los datos de la obra social dado que ya existe una obra social en la base de datos con ese nombre" };
                return NotFound(Respuesta);
            }

            return Ok(ObraSocial);
        }

        [HttpPost]
        public async Task<ActionResult<ObraSocialResponse>> PostObraSocial(ObraSocialDTO ObraSocialDTO)
        {
            ObraSocialResponse? ObraSocial = await _Service.CreateObraSocial(ObraSocialDTO);

            if (ObraSocial == null)
            {
                var Respuesta = new { Motivo = "No es posible registrar la obra social dado que ya existe una obra social en la base de datos con ese nombre" };
                return NotFound(Respuesta);
            }

            return Ok(ObraSocial);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteObraSocial(int Id)
        {
            if (!await _Service.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron obras sociales asociadas al id: " + Id };
                return NotFound(Respuesta);
            }

            return Ok(await _Service.DeleteObraSocial(Id));
        }
    }
}

