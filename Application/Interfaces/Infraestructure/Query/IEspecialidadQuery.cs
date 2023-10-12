using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IEspecialidadQuery
    {
        Task<List<Especialidad>> GetEspecialidades();
        Task<Especialidad> GetEspecialidadById(int Id);
        Task<Especialidad> ComprobarExistencia(string Descripcion);
    }
}
