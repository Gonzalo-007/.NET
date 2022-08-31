using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        /* aqui decimos que un Chapter tiene un Course */
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();  



        [Required]
        public string List { get; set; }=string.Empty;  



    }
}

