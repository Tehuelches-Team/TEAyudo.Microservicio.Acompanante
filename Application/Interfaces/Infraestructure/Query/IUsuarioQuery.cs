using Application.UseCase.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IUsuarioQuery
    {
        Task<List<UsuarioResponse>>? GetAllUsuarios();
        Task<UsuarioResponse?> GetUsuarioById(int Id);
    }
}
