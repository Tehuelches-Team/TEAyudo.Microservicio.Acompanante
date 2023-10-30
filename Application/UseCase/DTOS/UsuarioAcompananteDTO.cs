using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.DTOS
{
    public class UsuarioAcompananteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string FotoPerfil { get; set; }
        public string Domicilio { get; set; }
        public string FechaNacimiento { get; set; }
        public int? EstadoUsuarioId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
    }
}
