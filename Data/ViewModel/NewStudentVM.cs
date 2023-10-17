using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestingRelestionship.Data.Base;
using TestingRelestionship.Data.Enums;

namespace TestingRelestionship.Models
{
    public class NewStudentVM
    {
        [Display(Name ="Student Name")]
        [Required(ErrorMessage ="Name is required")]
        public string StName { get; set; }


        [Display(Name = "Year of birth")]
        [Required(ErrorMessage = "Year of birth is required")]
        public string YearDOB { get; set; }

        [Display(Name = "Stundet sex")]
        [Required(ErrorMessage = "Sex is required")]
        public SexCategory SexCategory { get; set; }

        //reletionship

        [Display(Name = "Techer Name Name")]
        [Required(ErrorMessage = "Teacher name required")]
        public int TecherId { get; set; }

        [Display(Name = "Classroom number")]
        [Required(ErrorMessage = "Classroom number required")]
        public int ClassroomId { get; set; }



    }
}
