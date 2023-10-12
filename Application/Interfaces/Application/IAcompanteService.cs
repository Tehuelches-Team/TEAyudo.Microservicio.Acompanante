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
        Task<AcompananteResponse> UpdateAcompante(int Id, AcompananteDTO Acompanante);
        Task<AcompananteResponse> CreateAcompante(AcompananteDTO Acompante);
        Task<AcompananteResponse> DeleteAcompante(int Id);
        Task<AcompananteObraSocialResponse?> CreateAcompanteObraSocial(AcompananteObraSocialDTO Relacion);
        Task<AcompananteDisponibilidadSemanalResponse?> CreateAcompanteDisponibilidad(AcompananteDisponibilidadDTO Relacion);
        Task<AcompananteEspecialidadResponse?> CreateAcompanteEspecialidad(AcompananteEspecialidadDTO Relacion);
    }
}
