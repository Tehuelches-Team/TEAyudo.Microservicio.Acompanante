using Application.Model.Response;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IPropuestaCommand
    {
        Task<PropuestaResponse> PutPropuesta(int Id, int Estado);
    }
}
