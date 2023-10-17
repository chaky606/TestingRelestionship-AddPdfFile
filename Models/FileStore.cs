using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingRelestionship.Models
{
    public class FileStore
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContenType { get; set; }
        public byte[]? Data { get; set; }

        //reletionship
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
