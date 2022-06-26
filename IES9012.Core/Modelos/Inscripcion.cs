using IES9012.Core.Enumeraciones;
using System.ComponentModel.DataAnnotations;
namespace IES9012.Core.Modelos
{
    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        //La propiedad MateriaId es una clave externa y la propiedad de navegacion correspondiente es Materia.
        //Una entidad inscriocion esta asociadad con una entidad Materia.
        public int MateriaId { get; set; }
        //La propiedad EstudianteId es una clave externa y la propiedad de navegacion correspondiente es Estudiante.
        //Una entidad Inscripcion esta asociada con una entidad Estudiante.
        public int EstudianteId { get; set; }
        //El siguiente es el valor por defecto. Si el alumno no tiene nota, le pone valor por defecto.
        [DisplayFormat(NullDisplayText ="Sin Calificación")]
        //Es una tabla puente.
        public Calificacion? Calificacion{ get; set; }
        public Materia? Materia { get; set; }
        public Estudiante? Estudiante { get; set; }
    }
}