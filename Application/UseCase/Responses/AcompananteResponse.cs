using Application.UseCase.DTO;

namespace TEAyudo.DTO
{
    public class AcompananteResponse
    { //Se utiliza en los getters de acompanante para lograr mostrar los datos más relevantes
        public int AcompananteId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
        public List<ObraSocialResponse> ObrasSociales { get; set; }
        public List<DisponibilidadResponse> Disponibilidad { get; set; }
        public List<EspecialidadResponse> Especialidad { get; set; }
    }
}
