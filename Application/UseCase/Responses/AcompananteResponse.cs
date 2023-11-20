using Application.UseCase.DTO;

namespace TEAyudo.DTO
{
    public class AcompananteResponse
    { //Se utiliza en los getters de acompanante para lograr mostrar los datos más relevantes
        public int AcompananteId { get; set; }
        public int UsuarioId { get; set; }
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
        public string Disponibilidad { get; set; }
        public List<ObraSocialResponse> ObrasSociales { get; set; }
        public List<EspecialidadResponse> Especialidad { get; set; }
    }
}
