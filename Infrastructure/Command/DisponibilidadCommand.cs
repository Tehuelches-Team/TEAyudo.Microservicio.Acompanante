//using Application.Interfaces.Infraestructure.Command;
//using Microsoft.EntityFrameworkCore;
//using TEAyudo_Acompanantes;

//namespace Infraestructure.Command
//{
//    public class DisponibilidadCommand : IDisponibilidadCommand
//    {
//        private readonly TEAyudoContext _Context;
//        public DisponibilidadCommand(TEAyudoContext Context)
//        {
//            _Context = Context;
//        }

//        async Task IDisponibilidadCommand.UpdateDisponibilidad(DisponibilidadSemanal DisponibilidadRecibida)
//        {
//            DisponibilidadSemanal Disponibilidades = await _Context.DisponibilidadesSemanales.Include(s => s.Acompanante)
//                .FirstOrDefaultAsync(s => s.DisponibilidadSemanalId == DisponibilidadRecibida.DisponibilidadSemanalId);

//            Disponibilidades.DiaSemana = DisponibilidadRecibida.DiaSemana;
//            Disponibilidades.HorarioInicio = DisponibilidadRecibida.HorarioInicio;
//            Disponibilidades.HorarioFin = DisponibilidadRecibida.HorarioFin;
//            _Context.SaveChanges();
//        }

//        async Task<DisponibilidadSemanal> IDisponibilidadCommand.CreateDisponibilidad(DisponibilidadSemanal DisponibilidadRecibida)
//        {
//            _Context.Add(DisponibilidadRecibida);
//            await _Context.SaveChangesAsync();
//            return DisponibilidadRecibida;
//        }

//        async Task IDisponibilidadCommand.DeleteDisponibilidad(DisponibilidadSemanal DisponibilidadRecibida)
//        {
//            _Context.Remove(DisponibilidadRecibida);
//            await _Context.SaveChangesAsync();
//        }
//    }
//}
