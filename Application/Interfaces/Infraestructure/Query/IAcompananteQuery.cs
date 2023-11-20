using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IAcompananteQuery
    {
        Task<List<Acompanante>> GetAcompananteFiltros(int? Id, int? Especialidad, Int16? Disponibilidad, int? ObraSocial, string? ZonaLaboral);
        Task<List<Acompanante>> GetAcompanantes();
        Task<Acompanante?> GetAcompananteById(int Id);
    }
}
