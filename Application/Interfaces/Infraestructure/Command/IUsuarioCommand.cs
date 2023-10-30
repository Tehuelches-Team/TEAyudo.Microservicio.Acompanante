using Application.UseCase.DTOS;
using Application.UseCase.Responses;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IUsuarioCommand
    {
        Task<UsuarioResponse?> PutUsuario(int Id, UsuarioDTO UsuarioDTO);
        Task<UsuarioResponse?> DeleteUsuario(int Id);
    }
}
