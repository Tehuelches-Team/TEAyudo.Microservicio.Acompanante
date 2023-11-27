using Application.Exceptions;
using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.Model.Response;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Application.UseCase.Mapping;
using Application.UseCase.Responses;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace Application.UseCase.Services
{
    public class AcompananteService : IAcompanteService
    {
        private readonly IAcompananteCommand _AcompananteCommand;
        private readonly IAcompananteQuery _AcompananteQuery;
        private readonly ICreateAcompananteResponse _CreateResponse;
        private readonly IUsuarioCommand _UsuarioCommand;
        private readonly IUsuarioQuery _UsuarioQuery;
        private readonly IPropuestaCommand _PropuestaCommand;
        public AcompananteService(IAcompananteCommand Command, IAcompananteQuery Query, ICreateAcompananteResponse CreateResponse, IUsuarioCommand UsuarioCommand, IUsuarioQuery UsuarioQuery, IPropuestaCommand PropuestaCommand)
        {
            _AcompananteCommand = Command;
            _AcompananteQuery = Query;
            _CreateResponse = CreateResponse;
            _UsuarioCommand = UsuarioCommand;
            _UsuarioQuery = UsuarioQuery;
            _PropuestaCommand = PropuestaCommand;
        }

        async Task<List<AcompananteResponse>> IAcompanteService.Filtrar(int? Id = null, int? Especialidad = null, Int16? Disponibilidad = null, int? ObraSocial = null, string? ZonaLaboral = null)
        {
            List<Acompanante> ListaAcompanantes = await _AcompananteQuery.GetAcompananteFiltros(Id, Especialidad, Disponibilidad, ObraSocial, ZonaLaboral);
            List<UsuarioResponse> ListaUsuarioResponse = await _UsuarioQuery.GetAllUsuarios();
            return await _CreateResponse.CreateAcompanantesResponse(ListaAcompanantes, ListaUsuarioResponse); //Falta la lista de usuarios 
        }

        async Task<List<AcompananteResponse?>> IAcompanteService.GetAcompantes()
        {
            List<Acompanante>? ListaAcompanantes = await _AcompananteQuery.GetAcompanantes();
            if (ListaAcompanantes == null) // Debería comparar con null o con count ¿?                               
            {
                return null;
            }

            List<UsuarioResponse> ListaUsuarioResponse = await _UsuarioQuery.GetAllUsuarios();
            return await _CreateResponse.CreateAcompanantesResponse(ListaAcompanantes, ListaUsuarioResponse); //Falta la lista de usuarios 
        }

        async Task<AcompananteResponse?> IAcompanteService.GetAcompanteById(int Id)
        {
            Acompanante Acompanante = await _AcompananteQuery.GetAcompananteById(Id);
            if (Acompanante == null)
            {
                return null;
            }
            UsuarioResponse Usuario = await _UsuarioQuery.GetUsuarioById(Acompanante.UsuarioId);
            return await _CreateResponse.CreateAcompananteResponse(Acompanante, Usuario); //Falta el usuarios 
        }

        async Task<bool> IAcompanteService.IfExist(int Id)
        {
            Acompanante Acompanante = await _AcompananteQuery.GetAcompananteById(Id);
            if (Acompanante == null) return false;
            return true;
        }

        async Task<AcompananteResponse> IAcompanteService.UpdateAcompante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO)
        {
            await _AcompananteCommand.UpdateAcompanante(Id, UsuarioAcompananteDTO);
            Acompanante Acompanante = await _AcompananteQuery.GetAcompananteById(Id);
            MapUsuarioDTO Mapping = new MapUsuarioDTO();
            UsuarioResponse UsuarioResponse = await _UsuarioCommand.PutUsuario(Acompanante.UsuarioId, Mapping.Map(UsuarioAcompananteDTO)); //Ver bien como enviarle el DTO
            return await _CreateResponse.CreateAcompananteResponse(Acompanante, UsuarioResponse); //Falta el usuarios
        }

        async Task<int> IAcompanteService.CreateAcompante(AcompananteDTO AcompananteRecibido)
        {
            int id = await _AcompananteCommand.CreateAcompanante(new Acompanante
            {
                UsuarioId = AcompananteRecibido.UsuarioId,
                ZonaLaboral = AcompananteRecibido.ZonaLaboral,
                Contacto = AcompananteRecibido.Contacto,
                Documentacion = AcompananteRecibido.Documentacion,
                Experiencia = AcompananteRecibido.Experiencia,
                Disponibilidad = Convert.ToInt16(("000" + AcompananteRecibido.Disponibilidad), 2),
            });
            return id;
        }

        async Task<AcompananteResponse> IAcompanteService.DeleteAcompante(int Id)
        {
            Acompanante Acompanante = await _AcompananteQuery.GetAcompananteById(Id);
            await _AcompananteCommand.DeleteAcompanante(Acompanante);
            UsuarioResponse Usuario = await _UsuarioCommand.DeleteUsuario(Acompanante.UsuarioId);
            return await _CreateResponse.CreateAcompananteResponse(Acompanante, Usuario); //Falta el usuario            
        }

        async Task<AcompananteObraSocialResponse?> IAcompanteService.CreateAcompanteObraSocial(AcompananteObraSocialDTO Relacion)
        {
            Acompanante? Acompanante = await _AcompananteQuery.GetAcompananteById(Relacion.AcompananteId);

            foreach (var item in Acompanante.ObrasSociales)
            {
                if (item.ObrasocialId == Relacion.ObraSocialId)
                {
                    throw new RelacionExistenteException("");
                }
            }

            AcompananteObraSocial? AcompananteObraSocial = await _AcompananteCommand.CreateAcompanteObraSocial(new AcompananteObraSocial
            {
                AcompananteId = Relacion.AcompananteId,
                ObrasocialId = Relacion.ObraSocialId,
            });

            if (AcompananteObraSocial == null) return null;

            List<ObraSocialResponse> ObraSociales = new List<ObraSocialResponse>();
            foreach (var item in AcompananteObraSocial.Acompanante.ObrasSociales)
            {
                ObraSociales.Add(new ObraSocialResponse
                {
                    ObraSocialId = item.ObrasocialId,
                    Nombre = item.ObraSocial.Nombre,
                    Descripcion = item.ObraSocial.Descripcion,
                });
            }
            return new AcompananteObraSocialResponse
            {
                AcompananteId = AcompananteObraSocial.AcompananteId,
                ZonaLaboral = AcompananteObraSocial.Acompanante.ZonaLaboral,
                Contacto = AcompananteObraSocial.Acompanante.Contacto,
                Documentacion = AcompananteObraSocial.Acompanante.Documentacion,
                Experiencia = AcompananteObraSocial.Acompanante.Experiencia,
                ObraSociales = ObraSociales,
            };
        }




        async Task<AcompananteEspecialidadResponse?> IAcompanteService.CreateAcompanteEspecialidad(AcompananteEspecialidadDTO Relacion)
        {
            Acompanante? Acompanante = await _AcompananteQuery.GetAcompananteById(Relacion.AcompananteId);

            foreach (var item in Acompanante.Especialidades)
            {
                if (item.EspecialidadId == Relacion.EspecialidadId)
                {
                    throw new RelacionExistenteException("");
                }
            }
            AcompananteEspecialidad? AcompananteEspecialidad = await _AcompananteCommand.CreateAcompanteEspecialidad(new AcompananteEspecialidad
            {
                AcompananteId = Relacion.AcompananteId,
                EspecialidadId = Relacion.EspecialidadId,
            });
            if (AcompananteEspecialidad == null) return null;
            List<EspecialidadResponse> Especialidades = new List<EspecialidadResponse>();
            foreach (var item in AcompananteEspecialidad.Acompanante.Especialidades)
            {
                Especialidades.Add(new EspecialidadResponse
                {
                    EspecialidadId = item.EspecialidadId,
                    Descripcion = item.Especialidad.Descripcion,
                });
            }

            return new AcompananteEspecialidadResponse
            {
                AcompananteId = AcompananteEspecialidad.Acompanante.AcompananteId,
                Contacto = AcompananteEspecialidad.Acompanante.Contacto,
                ZonaLaboral = AcompananteEspecialidad.Acompanante.ZonaLaboral,
                Documentacion = AcompananteEspecialidad.Acompanante.Documentacion,
                Experiencia = AcompananteEspecialidad.Acompanante.Experiencia,
                Especialidades = Especialidades,
            };
        }

        public async Task<PropuestaResponse> PutPropuesta(int Id, int Estado)
        {
            PropuestaResponse PropuestaResponse = await _PropuestaCommand.PutPropuesta(Id, Estado);
            return PropuestaResponse;
        }

        public Task<int> GetATIdbyUsuarioId(int UsuarioId)
        {
            return _AcompananteQuery.GetAcompananteIdByUsuarioId(UsuarioId);
        }
    }
}
