using Application.Interfaces.Infraestructure.Query;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructure.Querys
{
    public class EspecialidadQuery : IEspecialidadQuery
    {
        private readonly TEAyudoContext _Context;

        public EspecialidadQuery(TEAyudoContext Context)
        {
            _Context = Context;
        }

        async Task<List<Especialidad>> IEspecialidadQuery.GetEspecialidades()
        {
            return await _Context.Especialidades.ToListAsync();
        }

        async Task<Especialidad> IEspecialidadQuery.GetEspecialidadById(int Id)
        {
            return await _Context.Especialidades.FirstOrDefaultAsync(s => s.EspecialidadId == Id);
        }

        async Task<Especialidad?> IEspecialidadQuery.ComprobarExistencia(string Descripcion)
        {
            return await _Context.Especialidades.FirstOrDefaultAsync(s => s.Descripcion == Descripcion);
        }
    }
}
