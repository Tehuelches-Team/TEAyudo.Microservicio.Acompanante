using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Infraestructure.Command
{
    public interface IPropuestaCommand
    {
        Task<PropuestaResponse> PutPropuesta(int Id, int Estado);
    }
}
