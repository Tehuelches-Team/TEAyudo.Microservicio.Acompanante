using Application.UseCase.DTOS;
using TEAyudo_Acompanantes;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IAcompananteCommand
    {
        Task UpdateAcompanante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO);
        Task<int> CreateAcompanante(Acompanante Acompanante);
        Task DeleteAcompanante(Acompanante Acompanante);
        Task<AcompananteObraSocial?> CreateAcompanteObraSocial(AcompananteObraSocial Relacion);
        Task<Acompanante?> CreateAcompanteDisponibilidad(AcompananteDisponibilidadDTO Relacion);
        Task<AcompananteEspecialidad?> CreateAcompanteEspecialidad(AcompananteEspecialidad Relacion);
    }
}
