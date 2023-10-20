using Application.UseCase.DTOS;
using Application.UseCase.Responses;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IUsuarioCommand
    {
        Task<UsuarioResponse?> PutUsuario(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO);
        Task<UsuarioResponse?> DeleteUsuario(int Id);
    }
}
