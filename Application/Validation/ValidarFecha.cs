using Application.Exceptions;

namespace Application.Validation
{
    public static class ValidarFecha
    {
        public static void VerificacionFecha(string Fecha)
        {
            DateTime Tiempo = DateTime.Parse(Fecha);
            if (Tiempo.TimeOfDay != DateTime.Parse("00:00:00").TimeOfDay)
            {
                throw new FechaException("La fecha ingresada no se encuentra en el formato correcto. Por favor ingrese una fecha en el formato (dd/mm)");
            }
        }
    }
}
