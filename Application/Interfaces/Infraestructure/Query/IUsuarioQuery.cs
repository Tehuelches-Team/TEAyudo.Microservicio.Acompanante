using Application.UseCase.Responses;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IUsuarioQuery
    {
        Task<List<UsuarioResponse>>? GetAllUsuarios();
        Task<UsuarioResponse?> GetUsuarioById(int Id);
    }
}
