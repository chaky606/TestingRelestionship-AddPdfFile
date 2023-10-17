using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingRelestionship.Models
{
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        [Display(Name ="Class Number")]
        [Required(ErrorMessage ="Room number is required!")]
        public string RoomNumber { get; set; }

        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }

        //reletionship
        public List<Student>? Students { get; set; }
    }
}
