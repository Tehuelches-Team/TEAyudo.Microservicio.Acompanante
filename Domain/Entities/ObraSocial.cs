namespace TEAyudo_Acompanantes;

public class ObraSocial
{
    public int ObraSocialId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<AcompananteObraSocial> Acompanantes { get; set; }
}
