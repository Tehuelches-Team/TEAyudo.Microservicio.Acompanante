namespace TEAyudo_Acompanantes;

public class DisponibilidadSemanal
{
    public int DisponibilidadSemanalId { get; set; }
    public int AcompananteId { get; set; }
    public int DiaSemana { get; set; }
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFin { get; set; }
    public Acompanante Acompanante { get; set; }
}


