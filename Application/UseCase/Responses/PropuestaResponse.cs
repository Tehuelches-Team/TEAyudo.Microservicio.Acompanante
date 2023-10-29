


namespace Application.Model.Response
{
    public class PropuestaResponse
    {
        public int PropuestaId { get; set; }
        public int TutorId { get; set; }
        public int AcompananteId { get; set; }
        public string InfoAdicional { get; set; }
        public int Monto { get; set; }
        public int EstadoPropuesta { get; set; }
        public string Descripcion { get; set; }
    }
}