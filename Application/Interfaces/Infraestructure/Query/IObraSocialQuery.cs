using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Query
{
    public interface IObraSocialQuery
    {
        Task<List<ObraSocial>> GetObraSociales();
        Task<ObraSocial> GetObraSocialById(int Id);
        Task<ObraSocial?> ComprobarExistencia(string Nombre);
    }
}
