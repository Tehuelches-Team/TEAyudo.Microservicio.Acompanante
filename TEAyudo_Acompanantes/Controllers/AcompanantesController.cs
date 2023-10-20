using Application.Exceptions;
using Application.Interfaces.Application;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using Application.Validation;
using Microsoft.AspNetCore.Mvc;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanantesController : Controller
    {
        private readonly IAcompanteService _ServiceAcompanante;
        private readonly IDisponibilidadService _ServiceDisponibilidad;
        public AcompanantesController(IAcompanteService ServiceAcompanante, IDisponibilidadService ServiceDisponibilidad)
        {
            _ServiceAcompanante = ServiceAcompanante; //Lo dejo así para que lo use Ariel
            _ServiceDisponibilidad = ServiceDisponibilidad;
        }

        [HttpGet("Filtros")] 
        public async Task<ActionResult<IEnumerable<AcompananteResponse>>> GetAcompananteByFiltros(int? Id = null, int? Especialidad = null, int? Disponibilidad = null, int? ObraSocial = null, string? ZonaLaboral = null)
        {
            if (Disponibilidad != null && (Disponibilidad < 1 || Disponibilidad > 6) ) //No debe de ir ya que en el front end se controlará.
            {
                var Respuesta = new { Motivo = "El dia de la semana debe de obedecer el rango el rango numerico [1,7]" };
                return BadRequest(Respuesta);
            }

            List<AcompananteResponse> ListaAcompanantes = await _ServiceAcompanante.Filtrar(Id, Especialidad, Disponibilidad, ObraSocial, ZonaLaboral);

            if (!ListaAcompanantes.Any())
            {
                var respuesta = new { Motivo = "No se encuentran acompañantes con los requisitos buscados." };
                return NotFound(respuesta);
            }
            return Ok(ListaAcompanantes);
        }

        [HttpGet("Acompanantes")]
        public async Task<ActionResult<IEnumerable<AcompananteResponse>>> GetAcompanantes()
        {
            List<AcompananteResponse?> Disponibilidad = await _ServiceAcompanante.GetAcompantes();
            if (Disponibilidad.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes registrados." };
                return NotFound(Respuesta);
                //Error no hay especialidades registradas aunque se supone que si o si debe de existir ya que no hay filtros.
            }
            return Disponibilidad; //Controlar http code
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AcompananteResponse>> GetAcompanantesById(int Id)
        {
                AcompananteResponse? Disponibilidad = await _ServiceAcompanante.GetAcompanteById(Id);
                if (Disponibilidad == null)
                {
                    var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + Id }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                    return NotFound(Respuesta);
                }

                return Ok(Disponibilidad);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAcompanante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO) //Controlar los errores de la hora
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
            }catch (ConflictoException ex)
            {
                var Respuesta = new { Motivo = ex.Message};
                return Conflict(Respuesta);
            }catch (FormatException)
            {
                var Respuesta = new { Motivo = "Se ha ingresado un formato de hora no valido" };
                return BadRequest(Respuesta);
            }
        }


        [HttpPost("Acompanante")]
        public async Task<ActionResult<AcompananteResponse>> PostAcompanante(AcompananteDTO AcompananteDTO) //Controlar los errores de la hora
        {
            bool Resultado = await _ServiceAcompanante.CreateAcompante(AcompananteDTO); //Comprobar que el medio de comunicación no se encuentre registrado
            if (Resultado)
            {
                return new JsonResult("Acompanante registrado con exito") { StatusCode = 201 };
            } //El error de abajo seguramente se pueda quietar
            var Respuesta = new { Motivo = "No se ha podido crear el tutor debido a que ya existe una cuenta asociada al correo electronico ingresado." };
            return Conflict(Respuesta);
        }

        [HttpPost("Relacion/Acompanante/ObraSocial")]
        public async Task<ActionResult<AcompananteResponse>> PostAcompananteObraSocial(AcompananteObraSocialDTO AcompananteObraSocialDTO) //Controlar los errores de la hora
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
        public async Task<ActionResult<AcompananteResponse>> PostAcompananteEspecialidad(AcompananteEspecialidadDTO AcompananteEspecialidadDTO) //Controlar los errores de la hora
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
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + Id }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }
            AcompananteResponse AcompananteResponse = await _ServiceAcompanante.DeleteAcompante(Id);
            return Ok(AcompananteResponse);
        }

        //Disponibilidad

        [HttpGet("Disponibilidades")]
        public async Task<ActionResult<IEnumerable<DisponibilidadResponse>>> GetDisponibilidadesSemanales()
        {
            List<DisponibilidadResponse> Disponibilidad = await _ServiceDisponibilidad.GetDisponibilidades();
            if (Disponibilidad.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron disponibilidades semanales." };
                return NotFound(Respuesta);
                //Error no hay especialidades registradas aunque se supone que si o si debe de existir ya que no hay filtros.
            }
            return Disponibilidad; //Controlar http code
        }

        [HttpGet("Disponibilidad/{Id}")]
        public async Task<ActionResult<DisponibilidadResponse>> GetDisponibilidadSemanal(int Id)
        {
            DisponibilidadResponse? Disponibilidad = await _ServiceDisponibilidad.GetDisponibilidadById(Id);

            if (Disponibilidad == null)
            {
                var Respuesta = new { Motivo = "No se encontraron disponibilidades semanales asociadas al id: " + Id }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }

            return Ok(Disponibilidad);
        }

        [HttpPut("Disponibilidad/{IdAcompanante}/{IdDisponibilidad}")]
        public async Task<IActionResult> PutDisponibilidadSemanal(int IdAcompanante,int IdDisponibilidad, DisponibilidadSemanalDTO DisponibilidadDTO) //Controlar los errores de la hora
        {
            try
            {
                ValidarHora.VerificacionHoraria(DisponibilidadDTO.HorarioInicio);
                ValidarHora.VerificacionHoraria(DisponibilidadDTO.HorarioFin);
            }
            catch (FormatException)
            {
                var Respuesta = new { Motivo = "Se ha ingresado un formato de hora no valido" };
                return BadRequest(Respuesta);
            }
            catch (HorarioException)
            {
                var Respuesta = new { Motivo = "Se ha ingresado un formato de hora no valido" };
                return BadRequest(Respuesta);
            }

            if (!await _ServiceAcompanante.IfExist(IdAcompanante))
            {
                var Respuesta = new { Motivo = "No se encontro ningun acompanante asociado al id: " + IdAcompanante };
                return NotFound(Respuesta);
            }

            if (!await _ServiceDisponibilidad.IfExist(IdDisponibilidad))
            {
                var Respuesta = new { Motivo = "No se encontraron disponibilidades semanales asociadas al id: " + IdDisponibilidad }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }

            if (DisponibilidadDTO.DiaSemana<1 || DisponibilidadDTO.DiaSemana>7)
            {
                var Respuesta = new { Motivo = "El dia de la semana debe de obedecer el rango el rango numerico [1,7]" }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }
            DisponibilidadResponse? Disponibilidad = await _ServiceDisponibilidad.UpdateDisponibilidad(IdAcompanante, IdDisponibilidad, DisponibilidadDTO);

            if (Disponibilidad == null)
            {
                var Respuesta = new { Motivo = "La disponibilidad con id '" + IdDisponibilidad + "' no pertenece al acompanante con id '" + IdAcompanante + "'" }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }    
            return Ok(Disponibilidad);
            
        }


        [HttpPost("Disponibilidad/{IdAcompanante}")] //Controlar que el horario bajo el cual se ingresan los valores no se superponga con otro ya existente
        public async Task<ActionResult<DisponibilidadResponse>> PostDisponibilidadSemanal(int IdAcompanante, DisponibilidadSemanalDTO DisponibilidadDTO) //Controlar los errores de la hora
        {
            try
            {
                ValidarHora.VerificacionHoraria(DisponibilidadDTO.HorarioInicio);
                ValidarHora.VerificacionHoraria(DisponibilidadDTO.HorarioFin);
                if (DisponibilidadDTO.DiaSemana > 6 || DisponibilidadDTO.DiaSemana < 1) //¿Debería de comprobar si existe en la base de datos, no condicionarlo así?
                {
                    var Respuesta = new { Motivo = "El dia de la semana debe de obedecer el rango el rango numerico [1,7]" };
                    return BadRequest(Respuesta);
                }
                if (!await _ServiceAcompanante.IfExist(IdAcompanante))
                {
                    var Respuesta = new { Motivo = "No se encontraron acompanantes asociados al id: " + IdAcompanante };
                    return NotFound(Respuesta);
                }

                AcompananteResponse? Acompanante = await _ServiceAcompanante.GetAcompanteById(IdAcompanante);
                DisponibilidadResponse? Response = await _ServiceDisponibilidad.CreateDisponibilidad(IdAcompanante, DisponibilidadDTO, Acompanante);

                if (Response == null)
                {
                    var Respuesta = new { Motivo = "El acomanante con id: " + IdAcompanante + " ya posee un horario para los dias " + DisponibilidadDTO.DiaSemana};
                    return NotFound(Respuesta);
                }
                return Ok(Response);
            }
            catch (FormatException)
            {
                var Respuesta = new { Motivo = "Se ha ingresado un formato de hora no valido" };
                return BadRequest(Respuesta);
            }
            catch (HorarioException ex)
            {
                var Respuesta = new { Motivo = ex };
                return BadRequest(Respuesta);
            }
        }


        [HttpDelete("Disponibilidad/{IdAcompanante}/{IdDisponibilidad}")]
        public async Task<IActionResult> DeleteDisponibilidadSemanal(int IdAcompanante, int IdDisponibilidad)
        {
            if (!await _ServiceAcompanante.IfExist(IdAcompanante))
            {
                var Respuesta = new { Motivo = "No se encontraron acompanantes asociadas al id: " + IdAcompanante }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }

            if (!await _ServiceDisponibilidad.IfExist(IdDisponibilidad))
            {
                var Respuesta = new { Motivo = "No se encontraron disponibilidades semales asociadas al id: " + IdDisponibilidad }; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }

            DisponibilidadResponse? Disponibilidad = await _ServiceDisponibilidad.DeleteDisponibilidad(IdAcompanante, IdDisponibilidad);

            if (Disponibilidad==null)
            {
                var Respuesta = new { Motivo = "La disponibilidad con id '" + IdDisponibilidad + "' no pertenece al acompanante con id '" + IdAcompanante + "'"}; //Único caso permitido por swagger, ingresar una fecha con formato que luego no se pueda convertir en Datetime
                return NotFound(Respuesta);
            }
            return Ok(Disponibilidad);
        }
    }
}
