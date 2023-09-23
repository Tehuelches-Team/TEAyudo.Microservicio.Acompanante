namespace TEAyudo.DTO
{
    public class AcompananteDTO 
    { //Se utiliza en los geters de acompanante para lograr mostrar los datos más relevantes
        public int AcompananteId { get; set; }
        public string ZonaLaboral { get; set; }
        public string Contacto { get; set; }
        public string Documentacion { get; set; }
        public string Experiencia { get; set; }
        public string NombreObraSocial { get; set; }
        public string ObraSocial_Descripcion { get; set; }
        public string Especialidad_Descripcion { get; set; }
        public int DiaSemana { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
    }
}
