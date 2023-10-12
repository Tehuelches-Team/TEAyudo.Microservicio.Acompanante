using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IDisponibilidadCommand
    {
        Task UpdateDisponibilidad(DisponibilidadSemanal Disponibilidad);
        Task<DisponibilidadSemanal> CreateDisponibilidad(DisponibilidadSemanal Disponibilidad);
        Task DeleteDisponibilidad(DisponibilidadSemanal Disponibilidad);
    }
}
