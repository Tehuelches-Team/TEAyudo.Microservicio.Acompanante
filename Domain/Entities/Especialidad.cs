namespace TEAyudo_Acompanantes;

public class Especialidad
{
    public int EspecialidadId { get; set; }
    public string Descripcion { get; set; }
    public ICollection<AcompananteEspecialidad> Acompanantes { get; set; }
}
