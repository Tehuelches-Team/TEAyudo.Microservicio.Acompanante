using Application.UseCase.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
