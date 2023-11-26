using Application.UseCase.DTO;

namespace Application.UseCase.Responses
{
    public class AcompananteObraSocialResponse
    {
        public int AcompananteId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
        public List<ObraSocialResponse> ObraSociales { get; set; }
    }
}
