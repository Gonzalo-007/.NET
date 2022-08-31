using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { set; get; } = string.Empty;




        // aqui decimos que una Category puede tener varios Courses, pero un Course puede
        // estar en varias Categories
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
