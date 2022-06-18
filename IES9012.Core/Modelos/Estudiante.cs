using System.ComponentModel.DataAnnotations;

namespace IES9012.Core.Modelos
{
    public class Estudiante
        //la propiedad [key], Id, se conveirte en la columna de clave principal en la base de datos.
        //El nombre del campo debe tener la palabra Id al final para ser reconocido como tal.
        //El sistema desde los modelos ejecutará una base de datos.
    {
        [Key]
        public int EstudianteId { get; set; }
        //Hace que el campo no acepte valores nulos.
        [Required]
        [StringLength(15)]
        
        //El ? indica que puede ser del tipo NULL.
        public string? Nombre{ get; set; }
        [Required]
        [StringLength(15)]
        public string? Apellido { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]

        //Decorador: cambia el cómo se visualizará el nombre de la propiedad ante el usuario.
        [Display(Name ="Fecha de Inscripción")]

        //Fecha actual, fecha del sistema.
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        //La propiedad inscripciones se relacionará con la tabla inscripciones y será una tabla puente
        //entre materia y alumno. Es una clave foranea. La propiedad de inscripción es una propiedad
        //de navegación, porque contiene otras entidades relacionadas con ella, por esto también
        //es una 'collection', porque pueden haber varias entidades inscripcion relacionadas con
        //estudiante.
        public ICollection<Inscripcion>? Inscripciones { get; set; }
        //ICollection es un tipo de dato que arma una coleccion de objetos
        //I es una interfaz
        //Una colección es tu tipo de dato que va a tener en su interrior otros tipos de datos.
        //Esta colección tendrá una lista de un par de datos de IdAlumno, IdMateria, etc.
        //La propiedad acepta valores NULL porque pueden haber alumnos no cursando materias.
    }
}
