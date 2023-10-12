using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IEspecialidadCommand
    {
        Task UpdateEspecialidad(Especialidad Especialidad);
        Task<Especialidad> CreateEspecialidad(Especialidad Descripcion);
        Task DeleteEspecialidad(Especialidad Especialidad);
    }
}
