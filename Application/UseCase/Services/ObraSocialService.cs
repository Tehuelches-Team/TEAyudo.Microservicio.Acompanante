using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using TEAyudo_Acompanantes;

namespace Application.UseCase.Services
{
    public class ObraSocialService : IObraSocialService
    {
        private readonly IObraSocialCommand _Command;
        private readonly IObraSocialQuery _Query;

        public ObraSocialService(IObraSocialCommand Command, IObraSocialQuery Query)
        {
            _Command = Command;
            _Query = Query;
        }

        async Task<List<ObraSocialResponse>> IObraSocialService.GetObraSociales()
        {
            List<ObraSocialResponse> ObraSociales = new List<ObraSocialResponse>();
            foreach (var item in await _Query.GetObraSociales())
            {
                ObraSociales.Add(new ObraSocialResponse
                {
                    ObraSocialId = item.ObraSocialId,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                });
            }

            return ObraSociales;
        }

        async Task<ObraSocialResponse?> IObraSocialService.GetObraSocialById(int Id)
        {
            ObraSocial ObraSocial = await _Query.GetObraSocialById(Id);
            if (ObraSocial == null)
            {
                return null;
            }
            return (new ObraSocialResponse
            {
                ObraSocialId = ObraSocial.ObraSocialId,
                Nombre = ObraSocial.Nombre,
                Descripcion = ObraSocial.Descripcion,
            });
        }

        async Task<bool> IObraSocialService.IfExist(int Id)
        {
            ObraSocial ObraSocial = await _Query.GetObraSocialById(Id);
            if (ObraSocial == null) return false;
            return true;
        }

        async Task<ObraSocialResponse?> IObraSocialService.UpdateObraSocial(int Id, ObraSocialDTO ObraSocialDTO)
        {
            ObraSocial? ObraSocial = await _Query.ComprobarExistencia(ObraSocialDTO.Nombre);
            if (ObraSocial == null || ObraSocial.ObraSocialId != Id)
            {
                return null;
            }

            await _Command.UpdateObraSocial(new ObraSocial
            {
                ObraSocialId = Id,
                Nombre = ObraSocialDTO.Nombre,
                Descripcion = ObraSocialDTO.Descripcion,
            });

            return new ObraSocialResponse
            {
                ObraSocialId = Id,
                Nombre = ObraSocialDTO.Nombre,
                Descripcion = ObraSocialDTO.Descripcion,
            };
        }

        async Task<ObraSocialResponse?> IObraSocialService.CreateObraSocial(ObraSocialDTO ObraSocialDTO)
        {
            if (await _Query.ComprobarExistencia(ObraSocialDTO.Nombre) != null)
            {
                return null;
            }

            ObraSocial obraSocial = await _Command.CreateObraSocial(new ObraSocial
            {
                Nombre = ObraSocialDTO.Nombre,
                Descripcion = ObraSocialDTO.Descripcion,
            });

            return new ObraSocialResponse
            {
                ObraSocialId = obraSocial.ObraSocialId,
                Nombre = obraSocial.Nombre,
                Descripcion = obraSocial.Descripcion,
            };
        }

        async Task<ObraSocialResponse> IObraSocialService.DeleteObraSocial(int Id)
        {
            ObraSocial ObraSocial = await _Query.GetObraSocialById(Id);
            await _Command.DeleteObraSocial(ObraSocial);
            return new ObraSocialResponse
            {
                ObraSocialId = ObraSocial.ObraSocialId,
                Nombre = ObraSocial.Nombre,
                Descripcion = ObraSocial.Descripcion,
            };
        }
    }
}
