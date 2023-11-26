using Application.Interfaces.Application;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace TEAyudo_Acompanantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadService _Service;

        public EspecialidadesController(IEspecialidadService Service)
        {
            _Service = Service;
        }

        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadResponse>>> GetEspecialidades() 
        {
            List<EspecialidadResponse> Especialidades = await _Service.GetEspecialidades();

            if (Especialidades.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron especialidades en la base de datos." };
                return NotFound(Respuesta);
            }

            return Especialidades; 
        }

        // GET: api/Especialidades/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<EspecialidadResponse>> GetEspecialidad(int Id) 
        {
            EspecialidadResponse Especialidad = await _Service.GetEspecialidadById(Id);

            if (Especialidad == null)
            {
                var Respuesta = new { Motivo = "No se encontraron especialidades asociadas al id: " + Id };
                return NotFound(Respuesta);
            }

            return Especialidad;
        }

        // PUT: api/Especialidades/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutEspecialidad(int Id, EspecialidadDTO EspecialidadDTO) 
        { 

            if (!await _Service.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron especialidades asociadas al id: " + Id };
                return NotFound(Respuesta);
            }
            EspecialidadResponse? Especialidad = await _Service.UpdateEspecialidad(Id, EspecialidadDTO);

            if (Especialidad == null)
            {
                var Respuesta = new { Motivo = "No es posible actualizar los datos de la especialidad ingresada, dado que existe otra especialidad con ese nombre en la base de datos" };
                return NotFound(Respuesta);
            }

            return Ok(Especialidad);
        }


        [HttpPost]
        public async Task<ActionResult> PostEspecialidad(EspecialidadDTO EspecialidadDTO) 
        {
            EspecialidadResponse? Especialidad = await _Service.CreateEspecialidad(EspecialidadDTO);

            if (Especialidad == null)
            {
                var Respuesta = new { Motivo = "No es posible crear la especialidad ingresada, dado que ya existe una especialidad con ese nombre en la base de datos" };
                return NotFound(Respuesta);
            }

            return Ok(Especialidad);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEspecialidad(int Id) 
        {
            if (!await _Service.IfExist(Id))
            {
                var Respuesta = new { Motivo = "No se encontraron especialidades asociadas al id: " + Id };
                return NotFound(Respuesta);
            }

            return Ok(await _Service.DeleteEspecialidad(Id));
        }

    }
}

