using Application.Exceptions;

namespace Application.Validation
{
    public static class ValidarHora
    {
        public static void VerificacionHoraria(string Horario)
        {
            TimeSpan Hora = TimeSpan.Parse(Horario);
            TimeOnly HorarioAExaminar = TimeOnly.FromTimeSpan(Hora);
            if (HorarioAExaminar == TimeOnly.FromTimeSpan(TimeSpan.Parse("00:00:00")))
            {
                throw new HorarioException("La hora ingresada no se encuentra en el formato correcto. Por favor ingrese un horario en el formato (hh:mm)");
            }
        }
    }
}
