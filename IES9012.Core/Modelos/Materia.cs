using System.ComponentModel.DataAnnotations;
namespace IES9012.Core.Modelos
{
    public class Materia
    {
        public int MateriaId { get; set; }
        [Required]
        [StringLength(30)]
        public string? Nombre { get; set; }

        public int Creditos { get; set; }
        public ICollection<Inscripcion>? Inscripciones{ get; set; }

    }
}