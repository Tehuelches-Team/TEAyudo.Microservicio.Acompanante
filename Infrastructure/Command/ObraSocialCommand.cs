using Application.Interfaces.Infraestructure.Command;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;

namespace Infraestructure.Command
{
    public class ObraSocialCommand : IObraSocialCommand
    {
        private readonly TEAyudoContext _Context;
        public ObraSocialCommand(TEAyudoContext Context)
        {
            _Context = Context;
        }

        async Task IObraSocialCommand.UpdateObraSocial(ObraSocial ObraSocialRecibida)
        {
            ObraSocial UniqueObraSocial = await _Context.ObrasSociales.FirstOrDefaultAsync(s => s.ObraSocialId == ObraSocialRecibida.ObraSocialId);
            UniqueObraSocial.Nombre = ObraSocialRecibida.Nombre;
            UniqueObraSocial.Descripcion = ObraSocialRecibida.Descripcion;
            _Context.SaveChanges();
        }

        async Task<ObraSocial> IObraSocialCommand.CreateObraSocial(ObraSocial ObraSocialRecibida)
        {
            _Context.Add(ObraSocialRecibida);
            await _Context.SaveChangesAsync();
            return ObraSocialRecibida;
        }

        async Task IObraSocialCommand.DeleteObraSocial(ObraSocial ObraSocialRecibida)
        {
            _Context.Remove(ObraSocialRecibida);
            await _Context.SaveChangesAsync();
        }

    }
}
