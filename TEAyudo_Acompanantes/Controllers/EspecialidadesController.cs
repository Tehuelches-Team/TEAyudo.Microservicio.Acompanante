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
        public async Task<ActionResult<IEnumerable<EspecialidadResponse>>> GetEspecialidades() //Busco y entrego todas las especialidades
        {
            List<EspecialidadResponse> Especialidades = await _Service.GetEspecialidades();

            if (Especialidades.Count() == 0)
            {
                var Respuesta = new { Motivo = "No se encontraron especialidades en la base de datos." };
                return NotFound(Respuesta);
            }

            return Especialidades; //Controlar http code
        }

        // GET: api/Especialidades/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<EspecialidadResponse>> GetEspecialidad(int Id) //Busco y devuelvo una especialidad en concreto
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
        public async Task<IActionResult> PutEspecialidad(int Id, EspecialidadDTO EspecialidadDTO) //Actualizo la informacion de una especialidad acorde el id ingresado
        {//Comprobar que exista el id, y después ir y eliminarlo. 

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

            // catch (DbUpdateConcurrencyException)
        }


        [HttpPost]
        public async Task<ActionResult> PostEspecialidad(EspecialidadDTO EspecialidadDTO) //Se crea una nueva especialidad
        {
            EspecialidadResponse? Especialidad = await _Service.CreateEspecialidad(EspecialidadDTO);

            if (Especialidad==null)
            {
                var Respuesta = new { Motivo = "No es posible crear la especialidad ingresada, dado que ya existe una especialidad con ese nombre en la base de datos" };
                return NotFound(Respuesta);
            }

            return Ok(Especialidad);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEspecialidad(int Id) //Busco y elimino una especialidad acorde el id
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

