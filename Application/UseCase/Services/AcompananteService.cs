using Application.Exceptions;
using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using System.Diagnostics.Contracts;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace Application.UseCase.Services
{
    public class AcompananteService : IAcompanteService
    {
        private readonly IAcompananteCommand _Command;
        private readonly IAcompananteQuery _Query;

        public AcompananteService(IAcompananteCommand Command, IAcompananteQuery Query)
        {
            _Command = Command;
            _Query = Query;
        }

        async Task<List<AcompananteResponse>> IAcompanteService.Filtrar(int? Id = null, int? Especialidad = null, int? Disponibilidad = null, int? ObraSocial = null, string? ZonaLaboral = null)
        {
            List<Acompanante> Acompanante = await _Query.GetAcompananteFiltros(Id, Especialidad, Disponibilidad, ObraSocial, ZonaLaboral);
            return await CreateAcompanantesResponse(Acompanante);
        }

        async Task<List<AcompananteResponse?>> IAcompanteService.GetAcompantes()
        {
            List<Acompanante> Acompanante = await _Query.GetAcompanantes(); 
            if (Acompanante.Count() == 0)                                   
            {
                return null;
            }
            return await CreateAcompanantesResponse(Acompanante);
        }

        async Task<AcompananteResponse?> IAcompanteService.GetAcompanteById(int Id)
        {
            List<Acompanante> Acompanante = new List<Acompanante>();
            Acompanante.Add(await _Query.GetAcompananteById(Id));
            if (Acompanante.First()==null)
            {
                return null;
            }
            List<AcompananteResponse> Response = await CreateAcompanantesResponse(Acompanante);
            return Response.First();
        }

        async Task<bool> IAcompanteService.IfExist(int Id)
        {
            Acompanante Acompanante = await _Query.GetAcompananteById(Id);
            if (Acompanante == null) return false;
            return true;
        }

        async Task<AcompananteResponse> IAcompanteService.UpdateAcompante(int Id, AcompananteDTO AcompananteRecibido)
        {
            List<Acompanante> Acompanante = new List<Acompanante>();
            await _Command.UpdateAcompanante(new Acompanante
            {
                AcompananteId = Id,
                ZonaLaboral = AcompananteRecibido.ZonaLaboral,
                Contacto = AcompananteRecibido.Contacto,
                Documentacion = AcompananteRecibido.Documentacion,
                Experiencia = AcompananteRecibido.Experiencia,
            });

            Acompanante.Add(await _Query.GetAcompananteById(Id));

            List<AcompananteResponse> Response = await CreateAcompanantesResponse(Acompanante);
            return Response.First();
        }

        async Task<AcompananteResponse> IAcompanteService.CreateAcompante(AcompananteDTO AcompananteRecibido)
        {
            List<Acompanante> Acompanante = new List<Acompanante>();
            int Id=await _Command.CreateAcompanante(new Acompanante
            {
                ZonaLaboral = AcompananteRecibido.ZonaLaboral,
                Contacto = AcompananteRecibido.Contacto,
                Documentacion = AcompananteRecibido.Documentacion,
                Experiencia = AcompananteRecibido.Experiencia,
            });
            Acompanante.Add(await _Query.GetAcompananteById(Id));
            List<AcompananteResponse> Response = await CreateAcompanantesResponse(Acompanante);
            return Response.First();
        }

        async Task<AcompananteResponse> IAcompanteService.DeleteAcompante(int Id)
        {
            List<Acompanante> Acompanante = new List<Acompanante>();
            Acompanante.Add(await _Query.GetAcompananteById(Id));
            await _Command.DeleteAcompanante(Acompanante.First());
            List<AcompananteResponse> Response = await CreateAcompanantesResponse(Acompanante);
            return Response.First();
        }

        async Task<AcompananteObraSocialResponse?> IAcompanteService.CreateAcompanteObraSocial(AcompananteObraSocialDTO Relacion)
        {
            Acompanante? Acompanante  = await _Query.GetAcompananteById(Relacion.AcompananteId);

            foreach (var item in Acompanante.ObrasSociales)
            {
                if (item.ObrasocialId == Relacion.ObraSocialId)
                {
                    throw new RelacionExistenteException("");
                }
            }

            AcompananteObraSocial? AcompananteObraSocial = await _Command.CreateAcompanteObraSocial(new AcompananteObraSocial
            {
                AcompananteId = Relacion.AcompananteId,
                ObrasocialId = Relacion.ObraSocialId,
            });

            if (AcompananteObraSocial == null) return null;
            List<ObraSocialResponse> ObraSociales = new List<ObraSocialResponse>();
            foreach (var item in AcompananteObraSocial.Acompanante.ObrasSociales)
            {
                ObraSociales.Add( new ObraSocialResponse{
                    ObraSocialId=item.ObrasocialId,
                    Nombre=item.ObraSocial.Nombre,
                    Descripcion=item.ObraSocial.Descripcion,
                });
            }
            return new AcompananteObraSocialResponse
            {
                AcompananteId=AcompananteObraSocial.AcompananteId,
                ZonaLaboral=AcompananteObraSocial.Acompanante.ZonaLaboral,
                Contacto = AcompananteObraSocial.Acompanante.Contacto,
                Documentacion = AcompananteObraSocial.Acompanante.Documentacion,
                Experiencia= AcompananteObraSocial.Acompanante.Experiencia,
                ObraSociales= ObraSociales,
            };
        }

        async Task<AcompananteDisponibilidadSemanalResponse?> IAcompanteService.CreateAcompanteDisponibilidad(AcompananteDisponibilidadDTO Relacion)
        {
            Acompanante? Acompanante = await _Command.CreateAcompanteDisponibilidad(Relacion);
            
            if (Acompanante == null) return null;
            List<DisponibilidadResponse> Disponbilidades = new List<DisponibilidadResponse>();
            foreach (var item in Acompanante.DisponibilidadesSemanales)
            {
                Disponbilidades.Add(new DisponibilidadResponse
                {
                    DisponibilidadSemanalId = item.DisponibilidadSemanalId,
                    DiaSemana=item.DiaSemana,
                    HorarioInicio=item.HorarioInicio.ToString(@"hh\:mm"),
                    HorarioFin=item.HorarioFin.ToString(@"hh\:mm"),
                });
            }
            return new AcompananteDisponibilidadSemanalResponse
            {
                AcompananteId = Acompanante.AcompananteId,
                Contacto = Acompanante.Contacto,
                ZonaLaboral =Acompanante.ZonaLaboral,
                Documentacion=Acompanante.Documentacion,
                Experiencia=Acompanante.Experiencia,
                Disponibilidades = Disponbilidades,
            };
        }

        async Task<AcompananteEspecialidadResponse?> IAcompanteService.CreateAcompanteEspecialidad(AcompananteEspecialidadDTO Relacion)
        {
            Acompanante? Acompanante = await _Query.GetAcompananteById(Relacion.AcompananteId);

            foreach (var item in Acompanante.Especialidades)
            {
                if (item.EspecialidadId == Relacion.EspecialidadId)
                {
                    throw new RelacionExistenteException("");
                }
            }
            AcompananteEspecialidad? AcompananteEspecialidad =  await _Command.CreateAcompanteEspecialidad(new AcompananteEspecialidad
            {
                AcompananteId = Relacion.AcompananteId,
                EspecialidadId = Relacion.EspecialidadId,
            });
            if (AcompananteEspecialidad == null) return null;
            List<EspecialidadResponse> Especialidades = new List<EspecialidadResponse>();
            foreach (var item in AcompananteEspecialidad.Acompanante.Especialidades)
            {
                Especialidades.Add(new EspecialidadResponse
                {
                    EspecialidadId=item.EspecialidadId,
                    Descripcion=item.Especialidad.Descripcion,
                });
            }

            return new AcompananteEspecialidadResponse
            {
                AcompananteId = AcompananteEspecialidad.Acompanante.AcompananteId,
                Contacto = AcompananteEspecialidad.Acompanante.Contacto,
                ZonaLaboral = AcompananteEspecialidad.Acompanante.ZonaLaboral,
                Documentacion = AcompananteEspecialidad.Acompanante.Documentacion,
                Experiencia = AcompananteEspecialidad.Acompanante.Experiencia,
                Especialidades = Especialidades,
            };
        }

        private async Task<List<AcompananteResponse>> CreateAcompanantesResponse(List<Acompanante> Acompanantes)
        {
            List<AcompananteResponse> ResultadosAcompanantes = new List<AcompananteResponse>();
            foreach (var item in Acompanantes) 
            {
                List<ObraSocialResponse> ListaObrasSociales = new List<ObraSocialResponse>();
                List<DisponibilidadResponse> ListaDisponibilidades = new List<DisponibilidadResponse>();
                List<EspecialidadResponse> ListaEspecialidades = new List<EspecialidadResponse>();
                foreach (var Single in item.Especialidades)
                {
                    ListaEspecialidades.Add(new EspecialidadResponse
                    {
                        EspecialidadId = Single.EspecialidadId,
                        Descripcion = Single.Especialidad.Descripcion,
                    });
                }

                foreach (var Single in item.ObrasSociales)
                {
                    ListaObrasSociales.Add(new ObraSocialResponse
                    {
                        ObraSocialId = Single.ObraSocial.ObraSocialId,
                        Nombre = Single.ObraSocial.Nombre,
                        Descripcion = Single.ObraSocial.Descripcion,
                    });
                }

                foreach (var Single in item.DisponibilidadesSemanales)
                {
                    ListaDisponibilidades.Add(new DisponibilidadResponse
                    {
                        DisponibilidadSemanalId = Single.DisponibilidadSemanalId,
                        DiaSemana = Single.DiaSemana,
                        HorarioInicio = Single.HorarioInicio.ToString(@"hh\:mm"),
                        HorarioFin = Single.HorarioFin.ToString(@"hh\:mm"),
                    });
                }

                ResultadosAcompanantes.Add(new AcompananteResponse
                {
                    AcompananteId = item.AcompananteId,
                    ZonaLaboral = item.ZonaLaboral,
                    Contacto = item.Contacto,
                    Documentacion = item.Documentacion,
                    Experiencia = item.Experiencia,
                    ObrasSociales = ListaObrasSociales,
                    Disponibilidad = ListaDisponibilidades,
                    Especialidad = ListaEspecialidades,
                });
            }
            return ResultadosAcompanantes;
        }
    }
}
