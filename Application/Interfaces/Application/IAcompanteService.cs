using Application.Model.Response;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using TEAyudo.DTO;

namespace Application.Interfaces.Application
{
    public interface IAcompanteService
    {
        Task<List<AcompananteResponse>> Filtrar(int? Id, int? Especialidad, Int16? Disponibilidad, int? ObraSocial, string? ZonaLaboral);
        Task<List<AcompananteResponse?>> GetAcompantes();
        Task<AcompananteResponse?> GetAcompanteById(int Id);
        Task<bool> IfExist(int Id);
        Task<AcompananteResponse> UpdateAcompante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO);
        Task<int> CreateAcompante(AcompananteDTO Acompante);
        Task<AcompananteResponse> DeleteAcompante(int Id);
        Task<AcompananteObraSocialResponse?> CreateAcompanteObraSocial(AcompananteObraSocialDTO Relacion);
        Task<AcompananteEspecialidadResponse?> CreateAcompanteEspecialidad(AcompananteEspecialidadDTO Relacion);
        Task<PropuestaResponse> PutPropuesta(int id, int Estado);
        Task<int> GetATIdbyUsuarioId(int UsuarioId);
    }
}
