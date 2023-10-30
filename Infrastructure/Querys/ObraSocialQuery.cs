using Application.Interfaces.Infraestructure.Query;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;

namespace Infraestructure.Querys
{
    public class ObraSocialQuery : IObraSocialQuery
    {
        private readonly TEAyudoContext _Context;

        public ObraSocialQuery(TEAyudoContext context)
        {
            _Context = context;
        }

        async Task<List<ObraSocial>> IObraSocialQuery.GetObraSociales()
        {
            return await _Context.ObrasSociales.ToListAsync();
        }

        async Task<ObraSocial> IObraSocialQuery.GetObraSocialById(int Id)
        {
            return await _Context.ObrasSociales.FirstOrDefaultAsync(s => s.ObraSocialId == Id);
        }

        async Task<ObraSocial?> IObraSocialQuery.ComprobarExistencia(string Nombre)
        {
            ObraSocial? ObraSocial = await _Context.ObrasSociales.FirstOrDefaultAsync(s => s.Nombre == Nombre);
            if (ObraSocial != null) return ObraSocial;
            return null;
        }
    }
}
