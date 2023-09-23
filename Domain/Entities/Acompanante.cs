using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEAyudo_Acompanantes;
public class Acompanante
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AcompananteId { get; set; }
    public int UsuarioId { get; set; }
    public string ZonaLaboral { get; set; }
    public int ObraSocialId { get; set; }
    public string Contacto { get; set; }
    public string Documentacion { get; set; }
    public int EspecialidadId { get; set; }
    public string Experiencia { get; set; }
    public int DisponibilidadSemanalId { get; set; }
    public ICollection<ObraSocial> ObrasSociales { get; set; }
    public ICollection<Especialidad> Especialidades { get; set; }
    public ICollection<DisponibilidadSemanal> DisponibilidadesSemanales { get; set; }


}
