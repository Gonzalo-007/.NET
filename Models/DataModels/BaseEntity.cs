using System.ComponentModel.DataAnnotations;
namespace UniversityApiBackend.Models.DataModels
{


    /* Esta clase nos va a permitir establecer aqullos requisitos o campos que queremos
     que todas nuestras tablas queremos que tengan*/
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }

        public string DeletedBy { get; set; } = string.Empty;

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
