using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IDisponibilidadQuery
    {
        Task<List<DisponibilidadSemanal>> GetDisponibilidades();
        Task<DisponibilidadSemanal?> GetDisponibilidadById(int Id);
    }
}
