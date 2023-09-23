using TEAyudo.DTO;

namespace Application.Interfaces.Aplication
{
    public interface IFiltroAcompanante
    {
        Task<List<AcompananteDTO>> FiltarObraSocial(string nombre);
        Task<List<AcompananteDTO>> FiltarEspecialidad(string Especialidad);
        Task<List<AcompananteDTO>> FiltrarDisponibilidadSemanal(int Dia);
        Task<List<AcompananteDTO>> FiltarZonaLaboral(string ZonaLaboral);
        Task<AcompananteDTO> FiltrarId(int Id);
    }
}
