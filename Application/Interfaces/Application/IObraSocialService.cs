using Application.UseCase.DTO;
using Application.UseCase.DTOS;

namespace Application.Interfaces.Application
{
    public interface IObraSocialService
    {
        Task<List<ObraSocialResponse>> GetObraSociales();
        Task<ObraSocialResponse?> GetObraSocialById(int Id);
        Task<bool> IfExist(int Id);
        Task<ObraSocialResponse?> UpdateObraSocial(int Id, ObraSocialDTO Descripcion);
        Task<ObraSocialResponse?> CreateObraSocial(ObraSocialDTO Descripcion);
        Task<ObraSocialResponse> DeleteObraSocial(int Id);
    }
}
