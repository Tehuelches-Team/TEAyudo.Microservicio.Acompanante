using Application.UseCase.DTO;

namespace Application.UseCase.Responses
{
    public class AcompananteEspecialidadResponse
    {
        public int AcompananteId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
        public List<EspecialidadResponse> Especialidades { get; set; }
    }
}
