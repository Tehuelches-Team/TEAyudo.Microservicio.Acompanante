using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using TEAyudo_Acompanantes;

namespace Application.UseCase.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IEspecialidadCommand _Command;
        private readonly IEspecialidadQuery _Query;

        public EspecialidadService(IEspecialidadCommand Command, IEspecialidadQuery Query)
        {
            _Command = Command;
            _Query = Query;
        }

        async Task<List<EspecialidadResponse>> IEspecialidadService.GetEspecialidades()
        {
            List<EspecialidadResponse> especialidades = new List<EspecialidadResponse>();
            foreach (var item in await _Query.GetEspecialidades())
            {
                especialidades.Add(new EspecialidadResponse
                {
                    EspecialidadId = item.EspecialidadId,
                    Descripcion = item.Descripcion,
                });
            }

            return especialidades;
        }

        async Task<EspecialidadResponse?> IEspecialidadService.GetEspecialidadById(int Id)
        {
            Especialidad Especialidad = await _Query.GetEspecialidadById(Id);
            if (Especialidad == null)
            {
                return null;
            }
            return (new EspecialidadResponse
            {
                EspecialidadId = Especialidad.EspecialidadId,
                Descripcion = Especialidad.Descripcion,
            });
        }

        async Task<bool> IEspecialidadService.IfExist(int Id)
        {
            Especialidad Especialidad = await _Query.GetEspecialidadById(Id);
            if (Especialidad == null) return false;
            return true;
        }

        async Task<EspecialidadResponse?> IEspecialidadService.UpdateEspecialidad(int Id, EspecialidadDTO DescripciondDTO)
        {
            Especialidad? Especialidad = await _Query.ComprobarExistencia(DescripciondDTO.Descripcion);
            if (Especialidad==null || Especialidad.EspecialidadId != Id)
            {
                return null;
            }

            await _Command.UpdateEspecialidad(new Especialidad
            {
                EspecialidadId = Id,
                Descripcion = DescripciondDTO.Descripcion,
            });

            return new EspecialidadResponse
            {
                EspecialidadId = Id,
                Descripcion = DescripciondDTO.Descripcion
            };
        }

        async Task<EspecialidadResponse?> IEspecialidadService.CreateEspecialidad(EspecialidadDTO DescripciondDTO)
        {
            if (await _Query.ComprobarExistencia(DescripciondDTO.Descripcion) != null)
            {
                return null;
            }

            Especialidad Especialidad = await _Command.CreateEspecialidad(new Especialidad
            {
                Descripcion = DescripciondDTO.Descripcion,
            });

            return new EspecialidadResponse
            {
                EspecialidadId = Especialidad.EspecialidadId,
                Descripcion = Especialidad.Descripcion,
            };
        }

        async Task<EspecialidadResponse> IEspecialidadService.DeleteEspecialidad(int Id)
        {
            Especialidad Especialidad = await _Query.GetEspecialidadById(Id);
            await _Command.DeleteEspecialidad(Especialidad);
            return new EspecialidadResponse
            {
                EspecialidadId = Especialidad.EspecialidadId,
                Descripcion = Especialidad.Descripcion,
            };
        }
    }
}
