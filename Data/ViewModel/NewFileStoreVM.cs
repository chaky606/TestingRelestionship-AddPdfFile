using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestingRelestionship.Models;

namespace TestingRelestionship.Models
{
    public class NewFileStoreVM
    {
        public List<FileStore>? fileStores { get; set; }

        //reletionship
        [Display(Name = "Student Name")]
        //public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
