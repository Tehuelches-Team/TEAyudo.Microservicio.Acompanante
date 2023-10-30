namespace Application.UseCase.DTO
{
    public class DisponibilidadResponse
    {
        public int DisponibilidadSemanalId { get; set; }
        public int DiaSemana { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFin { get; set; }
    }
}
