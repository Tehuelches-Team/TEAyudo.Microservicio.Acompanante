namespace TEAyudo_Acompanantes;
public class Acompanante
{
    public int AcompananteId { get; set; }
    public int UsuarioId { get; set; }
    public string ZonaLaboral { get; set; }
    public int ObraSocialId { get; set; }
    public string Contacto { get; set; }
    public string Documentacion { get; set; }
    public int EspecialidadId { get; set; }
    public string Experiencia { get; set; }
    public Int16 Disponibilidad { get; set; }
    public ICollection<AcompananteObraSocial> ObrasSociales { get; set; }
    public ICollection<AcompananteEspecialidad> Especialidades { get; set; }
}
