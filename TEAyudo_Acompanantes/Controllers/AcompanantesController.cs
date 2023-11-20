using Application.Exceptions;
using Application.Interfaces.Application;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using Microsoft.AspNetCore.Mvc;
using TEAyudo.DTO;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanantesController : Controller
    {
        private readonly IAcompanteService _ServiceAcompanante;
        public AcompanantesController(IAcompanteService ServiceAcompanante)
        {
            _ServiceAcompanante = ServiceAcompanante;
        }

        [HttpGet("Filtros")]
        public async Task<ActionResult<IEnumerable<AcompananteResponse>>> GetAcompananteByFiltros(int? Id = null, int? Especialidad = null, string? Disponibilidad = null, int? ObraSocial = null, string? ZonaLaboral = null)
        {
            Int16 dispo = Convert.ToInt16(("000" + Disponibilidad), 2);
            List<AcompananteResponse> ListaAcompanantes = await _ServiceAcompanante.Filtrar(Id, Especialidad, dispo, ObraSocial, ZonaLaboral);
            if (!ListaAcompanantes.Any())
            {
                var respuesta = new { Motivo = "No se encuentran acompañantes con los requisitos buscados." };
                return NotFound(respuesta);
            }
            return Ok(ListaAcompanantes);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcompananteResponse>>> GetAcompanantes()
        {
            List<AcompananteResponse?> Disponibilidad = await _ServiceAcompanante.GetAcompantes();
            if (Disponibilidad.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes registrados." };
                return NotFound(Respuesta);
            }
            return Disponibilidad; 
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AcompananteResponse>> GetAcompanantesById(int Id)
        {
            AcompananteResponse? Disponibilidad = await _ServiceAcompanante.GetAcompanteById(Id);
            if (Disponibilidad == null)
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + Id };
                return NotFound(Respuesta);
            }

            return Ok(Disponibilidad);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAcompanante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO) 
        {
            if (!await _ServiceAcompanante.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + Id };
                return NotFound(Respuesta);
            }
            try
            {
                AcompananteResponse AcompananteResponse = await _ServiceAcompanante.UpdateAcompante(Id, UsuarioAcompananteDTO);
                return Ok(AcompananteResponse);
            }
            catch (ConflictoException ex)
            {
                var Respuesta = new { Motivo = ex.Message };
                return Conflict(Respuesta);
            }
            catch (FormatException)
            {
                var Respuesta = new { Motivo = "Se ha ingresado un formato de fecha no valida" };
                return BadRequest(Respuesta);
            }
        }

        [HttpPut("{Id}/Propuesta")]
        public async Task<IActionResult> PutPropuesta(int Id, int Estado) 
        {
            return Ok(await _ServiceAcompanante.PutPropuesta(Id, Estado));
        }


        [HttpPost("Acompanante")]
        public async Task<ActionResult<AcompananteResponse>> PostAcompanante(AcompananteDTO AcompananteDTO) 
        {
            bool Resultado = await _ServiceAcompanante.CreateAcompante(AcompananteDTO); 
            if (Resultado)
            {
                return new JsonResult("Acompanante registrado con exito") { StatusCode = 201 };
            }
            var Respuesta = new { Motivo = "No se ha podido crear el tutor debido a que ya existe una cuenta asociada al correo electronico ingresado." };
            return Conflict(Respuesta);
        }

        [HttpPost("Relacion/Acompanante/ObraSocial")]
        public async Task<ActionResult<AcompananteResponse>> PostAcompananteObraSocial(AcompananteObraSocialDTO AcompananteObraSocialDTO) 
        {
            if (!await _ServiceAcompanante.IfExist(AcompananteObraSocialDTO.AcompananteId))
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + AcompananteObraSocialDTO.AcompananteId };
                return NotFound(Respuesta);
            }
            try
            {
                AcompananteObraSocialResponse? Relacion = await _ServiceAcompanante.CreateAcompanteObraSocial(AcompananteObraSocialDTO);
                if (Relacion != null)
                {
                    return Ok(Relacion);
                }
                var Respuesta = new { Motivo = "Se ha ingresado un id no asociado a una obra social en la base de datos" };
                return NotFound(Respuesta);
            }
            catch (RelacionExistenteException)
            {
                var Respuesta = new { Motivo = "La relacion que desea realizar ya existe" };
                return Conflict(Respuesta);
            }
        }

        [HttpPost("Relacion/Acompanante/Especialidad")]
        public async Task<ActionResult<AcompananteResponse>> PostAcompananteEspecialidad(AcompananteEspecialidadDTO AcompananteEspecialidadDTO) 
        {
            if (!await _ServiceAcompanante.IfExist(AcompananteEspecialidadDTO.AcompananteId))
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + AcompananteEspecialidadDTO.AcompananteId };
                return NotFound(Respuesta);
            }
            try
            {
                AcompananteEspecialidadResponse? Relacion = await _ServiceAcompanante.CreateAcompanteEspecialidad(AcompananteEspecialidadDTO);
                if (Relacion != null)
                {
                    return Ok(Relacion);
                }
                var Respuesta = new { Motivo = "Se ha ingresado un id no asociado a una especialidad en la base de datos" };
                return NotFound(Respuesta);
            }
            catch (RelacionExistenteException)
            {
                var Respuesta = new { Motivo = "La relacion que desea realizar ya existe" };
                return Conflict(Respuesta);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAcompanante(int Id)
        {
            if (!await _ServiceAcompanante.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + Id }; 
                return NotFound(Respuesta);
            }
            AcompananteResponse AcompananteResponse = await _ServiceAcompanante.DeleteAcompante(Id);
            return Ok(AcompananteResponse);
        }
    }
}
