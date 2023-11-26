using Application.UseCase.DTOS;

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
