using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IObraSocialCommand
    {
        Task UpdateObraSocial(ObraSocial Especialidad);
        Task<ObraSocial> CreateObraSocial(ObraSocial Descripcion);
        Task DeleteObraSocial(ObraSocial Especialidad);
    }
}
