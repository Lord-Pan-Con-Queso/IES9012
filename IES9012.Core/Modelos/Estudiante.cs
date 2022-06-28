using System.ComponentModel.DataAnnotations;

namespace IES9012.Core.Modelos
{
    public class Estudiante
    {
        //la propiedad ID se conveirte en la columna de clave principal en la base de datos.
        //Para que el campo sea identificado como tal, tiene que tener el nombre seguido de 'id'
        //para que el campo sea identificado, tiene que tener el nombre de la identidad "estudiantes"y  luego el id
        [Key]
        public int EstudianteId { get; set; }
        //hace que el campo no acepte valores nulos.
        [Required]
        [StringLength(50)]
        //El signo de interrogación indica que la propiedad puede ser del tipo NULL. Puede representarse tambien:
        //Public string Nombre{get;set;} =null!;
        public string? Nombre{ get; set; }
        [Required]
        [StringLength(35)]
        public string? Apellido { get; set; }
        //En el navegador ademas de mostrar el fecha, mostrará el calendario.
        [DataType(DataType.Date)]
        //M mayúscula para Mes y m minúscula para minuto. Tener en cuenta para evitar errores.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        //Decorador: cambia la propiedad con la que el usuario visualizará el campo.
        [Display(Name ="Fecha de Inscripción")]
        //La siguiente propiedad mostrará la fecha actual, tomará la fecha del sistema.
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        //La propiedad inscripciones se relacionará con la tabla inscripciones. Será una tabla puente entre materia y alumno.
        //Es una clave foránea.
        //La propiedad inscripcion es una propiedad de navegación, contiene otras entidades relacionadas con ella.
        //la propiedad inscipciones se define con ICollection<Inscripcion>
        //Porque puede haber varias entidades Inscripcion relacionadas con Estudiante.
        //I significa que es una interfaz
        //una conexion es tu tipo de dato que va a tener en su interrior otro tipo de dato.
        //ICollection es un tipo de dato que me arma una coleccion de objetos.
        //Voy a tener una lista de un par de datos alumnosId e materiaId.
        //La propiedad es null por las dudas que hay un alumno que no este cursando ninguna materia.
        public ICollection<Inscripcion>? Inscripciones { get; set; }
        
      
        

    }
}
