using IES9012.Core.Enumeraciones;
using System.ComponentModel.DataAnnotations;
namespace IES9012.Core.Modelos
{
    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        //La propiedad MateriaID es una clave externa, la propiedad de navegación correspondiente 
        //es Materia. Una entidad inscripción esta asociada con una entidad Materia.
        public int MateriaId { get; set; }
        //La propiedad EstudianteId es otra clave externa, la propiedad de navegación correspondiente
        //es Estudiante. Una entidad inscripción está asociada con una entidad estdiante.
        public int EstudianteId { get; set; }
        //A continuación el valor por defecto en caso de que la siguiente propiedad llegara vacía.
        //Por defecto no tiene nota.
        [DisplayFormat(NullDisplayText ="Sin Calificación")]
        public Calificacion? Calificacion{ get; set; }
        public Materia? Materia { get; set; }
        public Estudiante? Estudiante { get; set; }
        //Es una tabla puente
    }
}