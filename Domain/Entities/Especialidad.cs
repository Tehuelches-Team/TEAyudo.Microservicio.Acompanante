using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEAyudo_Acompanantes;

    public class Especialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialidadId { get; set; }

        public string Descripcion { get; set; }
        public ICollection<Acompanante> Acompanantes { get; set; }
    }
