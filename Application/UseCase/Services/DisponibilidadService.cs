//using Application.Interfaces.Application;
//using Application.Interfaces.Infraestructure.Command;
//using Application.Interfaces.Infraestructure.Query;
//using Application.UseCase.DTO;
//using Application.UseCase.DTOS;
//using System.Runtime.CompilerServices;
//using TEAyudo.DTO;
//using TEAyudo_Acompanantes;

//namespace Application.UseCase.Services
//{
//    public class DisponibilidadService : IDisponibilidadService
//    {
//        private readonly IDisponibilidadCommand _Command;
//        private readonly IDisponibilidadQuery _Query;

//        public DisponibilidadService(IDisponibilidadCommand Command, IDisponibilidadQuery Query)
//        {
//            _Command = Command;
//            _Query = Query;
//        }

//        async Task<List<DisponibilidadResponse>> IDisponibilidadService.GetDisponibilidades()
//        {
//            List<DisponibilidadResponse> Disponibilidad = new List<DisponibilidadResponse>();
//            foreach (var item in await _Query.GetDisponibilidades())
//            {
//                Disponibilidad.Add(new DisponibilidadResponse
//                {
//                    DisponibilidadSemanalId = item.DisponibilidadSemanalId,
//                    DiaSemana = item.DiaSemana,
//                    HorarioInicio = item.HorarioInicio.ToString(@"hh\:mm"),
//                    HorarioFin = item.HorarioFin.ToString(@"hh\:mm"),
//                });
//            }
//            return Disponibilidad;
//        }

//        async Task<DisponibilidadResponse?> IDisponibilidadService.GetDisponibilidadById(int Id)
//        {
//            DisponibilidadSemanal Disponibilidad = await _Query.GetDisponibilidadById(Id);
//            if (Disponibilidad== null)
//            {
//                return null;
//            }
//            return (new DisponibilidadResponse
//            {
//                DisponibilidadSemanalId = Disponibilidad.DisponibilidadSemanalId,
//                DiaSemana = Disponibilidad.DiaSemana,
//                HorarioInicio = Disponibilidad.HorarioInicio.ToString(@"hh\:mm"),
//                HorarioFin = Disponibilidad.HorarioFin.ToString(@"hh\:mm"),
//            });
//        }

//        async Task<bool> IDisponibilidadService.IfExist(int Id)
//        {
//            DisponibilidadSemanal? Disponibilidad = await _Query.GetDisponibilidadById(Id);
//            if (Disponibilidad == null) return false;
//            return true;
//        }

//        async Task<DisponibilidadResponse?> IDisponibilidadService.UpdateDisponibilidad(int IdAcompanante, int IdDisponibilidad, DisponibilidadSemanalDTO DisponibilidadDTO)
//        {
//            DisponibilidadSemanal Disponibilidad = await _Query.GetDisponibilidadById(IdDisponibilidad);

//            if (Disponibilidad.AcompananteId != IdAcompanante)
//            {
//                return null;
//            }
//            await _Command.UpdateDisponibilidad(new DisponibilidadSemanal
//            {
//                DisponibilidadSemanalId= IdDisponibilidad,
//                DiaSemana = DisponibilidadDTO.DiaSemana,
//                HorarioInicio = DateTime.Parse(DisponibilidadDTO.HorarioInicio).TimeOfDay,
//                HorarioFin = DateTime.Parse(DisponibilidadDTO.HorarioFin).TimeOfDay,
//            });

//            return new DisponibilidadResponse
//            {
//                DisponibilidadSemanalId = IdDisponibilidad,
//                DiaSemana = DisponibilidadDTO.DiaSemana,
//                HorarioInicio = DateTime.Parse(DisponibilidadDTO.HorarioInicio).TimeOfDay.ToString(@"hh\:mm"),
//                HorarioFin = DateTime.Parse(DisponibilidadDTO.HorarioFin).TimeOfDay.ToString(@"hh\:mm"),
//            };
//        }

//        async Task<DisponibilidadResponse?> IDisponibilidadService.CreateDisponibilidad(int Id, DisponibilidadSemanalDTO DisponibilidadDTO,AcompananteResponse Acompanante)
//        {
//            foreach (var Item in Acompanante.Disponibilidad)
//            {
//                if (Item.DiaSemana == DisponibilidadDTO.DiaSemana)
//                {
//                    return null;
//                }
//            }

//            DisponibilidadSemanal DisponibilidadRetornada = await _Command.CreateDisponibilidad(new DisponibilidadSemanal
//            {
//                AcompananteId = Id,
//                DiaSemana = DisponibilidadDTO.DiaSemana,
//                HorarioInicio = DateTime.Parse(DisponibilidadDTO.HorarioInicio).TimeOfDay,
//                HorarioFin = DateTime.Parse(DisponibilidadDTO.HorarioFin).TimeOfDay,
//            });

//            return new DisponibilidadResponse
//            {
//                DisponibilidadSemanalId = DisponibilidadRetornada.DisponibilidadSemanalId,
//                DiaSemana = DisponibilidadRetornada.DiaSemana,
//                HorarioInicio = DisponibilidadRetornada.HorarioInicio.ToString(@"hh\:mm"),
//                HorarioFin = DisponibilidadRetornada.HorarioFin.ToString(@"hh\:mm"),
//            };
//        }

//        async Task<DisponibilidadResponse?> IDisponibilidadService.DeleteDisponibilidad(int IdAcompanante, int IdDisponibilidad)
//        {
//            DisponibilidadSemanal Disponibilidad = await _Query.GetDisponibilidadById(IdDisponibilidad);
//            if (Disponibilidad == null || Disponibilidad.AcompananteId != IdAcompanante)
//            {
//                return null;
//            }
//            await _Command.DeleteDisponibilidad(Disponibilidad);
//            return new DisponibilidadResponse
//            {
//                DisponibilidadSemanalId = IdDisponibilidad,
//                DiaSemana = Disponibilidad.DiaSemana,
//                HorarioInicio = Disponibilidad.HorarioInicio.ToString(@"hh\:mm"),
//                HorarioFin = Disponibilidad.HorarioFin.ToString(@"hh\:mm"),
//            };
//        }
//    }
//}
