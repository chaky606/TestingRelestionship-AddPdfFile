using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestingRelestionship.Data.Base;
using TestingRelestionship.Data.Enums;

namespace TestingRelestionship.Models
{
    public class Student:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string StName { get; set; }
        public string YearDOB { get; set; }
        public SexCategory SexCategory { get; set; }


        //reletionship

        public int TecherId { get; set; }
        [ForeignKey("TecherId")]
        public Techer Techers { get; set; }

        public int ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; }

        public List<FileStore>? FileStores { get; set; }



    }
}
