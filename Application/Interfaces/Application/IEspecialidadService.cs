using Application.UseCase.DTO;
using Application.UseCase.DTOS;

namespace Application.Interfaces.Application
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadResponse>> GetEspecialidades();
        Task<EspecialidadResponse> GetEspecialidadById(int Id);
        Task<bool> IfExist(int Id);
        Task<EspecialidadResponse?> UpdateEspecialidad(int Id, EspecialidadDTO Descripcion);
        Task<EspecialidadResponse?> CreateEspecialidad(EspecialidadDTO Descripcion);
        Task<EspecialidadResponse> DeleteEspecialidad(int Id);
    }
}
