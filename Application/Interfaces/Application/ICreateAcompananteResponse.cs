using Application.UseCase.Responses;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace Application.Interfaces.Application
{
    public interface ICreateAcompananteResponse
    {
        Task<List<AcompananteResponse>> CreateAcompanantesResponse(List<Acompanante> ListaAcompanantes, List<UsuarioResponse> ListaUsuarios);
        Task<AcompananteResponse> CreateAcompananteResponse(Acompanante Acompanante, UsuarioResponse Usuario);
    }
}
