using Application.Interfaces.Infraestructure.Query;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;

namespace Infraestructure.Querys
{
    public class AcompananteQuery : IAcompananteQuery
    {
        private readonly TEAyudoContext _Context;

        public AcompananteQuery(TEAyudoContext Context)
        {
            _Context = Context;
        }

        async Task<List<Acompanante>> IAcompananteQuery.GetAcompanantes()
        {
            return await _Context.Acompanantes.Include(s => s.ObrasSociales)
                .ThenInclude(s => s.ObraSocial)
                .Include(s => s.DisponibilidadesSemanales)
                .Include(s => s.Especialidades)
                .ThenInclude(s => s.Especialidad).ToListAsync();
        }

        async Task<Acompanante?> IAcompananteQuery.GetAcompananteById(int Id)
        {
            return await _Context.Acompanantes.Include(s => s.ObrasSociales)
                .ThenInclude(s => s.ObraSocial)
                .Include(s => s.DisponibilidadesSemanales)
                .Include(s => s.Especialidades)
                .ThenInclude(s => s.Especialidad).FirstOrDefaultAsync(s => s.AcompananteId == Id);
        }

        async Task<List<Acompanante>> IAcompananteQuery.GetAcompananteFiltros(int? Id, int? Especialidad, int? Disponibilidad, int? ObraSocial, string? ZonaLaboral)
        {
            var query = _Context.Acompanantes.AsQueryable();

            if (Id != null)
            {
                query = query.Where(s => s.AcompananteId == Id);
            }

            if (ZonaLaboral != null)
            {
                query = query.Where(s => s.ZonaLaboral.Contains(ZonaLaboral));
            }

            if (ObraSocial != null)
            {
                query = query.Where(s => s.ObrasSociales.Any(os => os.ObrasocialId == ObraSocial));
            }

            if (Especialidad != null)
            {
                query = query.Where(s => s.Especialidades.Any(es => es.EspecialidadId == Especialidad));
            }

            if (Disponibilidad != null)
            {
                query = query.Where(s => s.DisponibilidadesSemanales.Any(ds => ds.DiaSemana == Disponibilidad));
            }

            return await query
                .Include(s => s.DisponibilidadesSemanales)
                .Include(s => s.ObrasSociales)
                    .ThenInclude(os => os.ObraSocial)
                    .ThenInclude(acom => acom.Acompanantes)
                    .ThenInclude(dis => dis.Acompanante)
                .Include(s => s.Especialidades)
                    .ThenInclude(es => es.Especialidad)
                .ToListAsync();
        }
    }
}
