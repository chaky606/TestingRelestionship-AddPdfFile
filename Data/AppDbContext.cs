using Microsoft.EntityFrameworkCore;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Techer> Techers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FileStore> FileStores { get; set; }
        //public DbSet<PdfStore> pdfStores { get; set; }
    }
}
