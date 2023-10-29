using Application.Model.Response;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace Application.Interfaces.Application
{
    public interface IAcompanteService
    {
        Task<List<AcompananteResponse>> Filtrar(int? Id, int? Especialidad, int? Disponibilidad, int? ObraSocial, string? ZonaLaboral);
        Task<List<AcompananteResponse?>> GetAcompantes();
        Task<AcompananteResponse?> GetAcompanteById(int Id);
        Task<bool> IfExist(int Id);
        Task<AcompananteResponse> UpdateAcompante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO);
        Task<bool> CreateAcompante(AcompananteDTO Acompante);
        Task<AcompananteResponse> DeleteAcompante(int Id);
        Task<AcompananteObraSocialResponse?> CreateAcompanteObraSocial(AcompananteObraSocialDTO Relacion);
        Task<AcompananteDisponibilidadSemanalResponse?> CreateAcompanteDisponibilidad(AcompananteDisponibilidadDTO Relacion);
        Task<AcompananteEspecialidadResponse?> CreateAcompanteEspecialidad(AcompananteEspecialidadDTO Relacion);
        Task<PropuestaResponse> PutPropuesta(int id, int Estado);
    }
}
