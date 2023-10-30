using Application.UseCase.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Mapping
{
    public class MapUsuarioDTO
    {
        public UsuarioDTO Map(UsuarioAcompananteDTO UsuarioAcompananteDTO)
        {
            return new UsuarioDTO
            {
                Nombre = UsuarioAcompananteDTO.Nombre,
                Apellido = UsuarioAcompananteDTO.Apellido,
                CorreoElectronico = UsuarioAcompananteDTO.CorreoElectronico,
                Contrasena = UsuarioAcompananteDTO.Contrasena,
                FotoPerfil = UsuarioAcompananteDTO.FotoPerfil,
                Domicilio = UsuarioAcompananteDTO.Domicilio,
                FechaNacimiento = UsuarioAcompananteDTO.FechaNacimiento,
            };
        }
    }
}
