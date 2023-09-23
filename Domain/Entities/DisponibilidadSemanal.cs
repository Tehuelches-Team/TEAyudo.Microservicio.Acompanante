using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEAyudo_Acompanantes;

    public class DisponibilidadSemanal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DisponibilidadSemanalId { get; set; }
        public int AcompananteId { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFin { get; set; }
        public Acompanante Acompanante { get; set; }
    }


