using System.ComponentModel.DataAnnotations;
using TestingRelestionship.Data.Enums;

namespace TestingRelestionship.Models
{
    public class Techer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Teacher Name:")]
        [Required(ErrorMessage = "Teacher Name is required!")]
        public string TchName { get; set; }

        [Display(Name = "Sex:")]
        [Required(ErrorMessage = "Sex is required!")]
        public SexCategory SexCategory { get; set; }

        //reletionship

        public List<Student>? Students { get; set; }
    }
}
