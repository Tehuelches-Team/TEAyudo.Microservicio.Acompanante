//using Application.Interfaces.Infraestructure.Query;
//using Microsoft.EntityFrameworkCore;
//using TEAyudo_Acompanantes;

//namespace Infraestructure.Querys
//{
//    public class DisponibilidadQuery : IDisponibilidadQuery
//    {
//        private readonly TEAyudoContext _Context;

//        public DisponibilidadQuery(TEAyudoContext Context)
//        {
//            _Context = Context;
//        }

//        async Task<List<DisponibilidadSemanal>> IDisponibilidadQuery.GetDisponibilidades()
//        {
//            return await _Context.DisponibilidadesSemanales.ToListAsync();
//        }

//        async Task<DisponibilidadSemanal?> IDisponibilidadQuery.GetDisponibilidadById(int Id)
//        {
//            return await _Context.DisponibilidadesSemanales.FirstOrDefaultAsync(s => s.DisponibilidadSemanalId == Id);
//        }
//    }
//}
