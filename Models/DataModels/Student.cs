using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required] 
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; }


        // aqui decimos que un Student puede estar en varios Courses, pero un Course puede tener
        // varios alumnos

        public ICollection<Course> Courses { get; set; }=new List<Course>();

    }
}
