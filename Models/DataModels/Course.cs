using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{

    public enum Level
    {
        Basic,
        Advanced,
        Hard,
        Expert
    }


    public class Course : BaseEntity
    {
        // aqui ponemos los campos que va a tener la tabla Course
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;


        /*aqui ponemos las relaciones que va a tener la tabla Course con las demas tablas*/


        //aqui decimos que un Course puede tener varias Categories, pero una category puede
        // estar en varios Cpurses
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();


        // aqui decimos que un Course solo va a tener un Chapters
        [Required]
        public Chapter Chapters { get; set; } = new Chapter();


        //aqui decimos que un Course tener muchos Students y que un Student pueder tener
        // estar en varios Courses
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
