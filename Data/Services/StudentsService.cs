using Microsoft.EntityFrameworkCore;
using TestingRelestionship.Data.Base;
using TestingRelestionship.Data.ViewModel;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public class StudentsService:EntityBaseRepository<Student>, IStudentsService
    {
        private readonly AppDbContext _context;
        public StudentsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewStudentAsync(NewStudentVM data)
        {
            var newStudent = new Student()
            {
                StName = data.StName,
                SexCategory = data.SexCategory,
                YearDOB = data.YearDOB,
                TecherId = data.TecherId,
                ClassroomId = data.ClassroomId
            };
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            //Add FileStore
                var newFileStore = new FileStore()
                {
                    StudentId = newStudent.Id,
                };
                await _context.FileStores.AddAsync(newFileStore);
                await _context.SaveChangesAsync();
            
        }

        public async Task<NewStudentDropdownVM> GetNewStudentDropdownVM()
        {
            var response = new NewStudentDropdownVM()
            {
                Techers = await _context.Techers.OrderBy(n => n.TchName).ToListAsync(),
                Classrooms = await _context.Classrooms.OrderBy(n => n.RoomNumber).ToListAsync()
            };
  
            return response;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var studentDetails = _context.Students
                .Include(t => t.Techers)
                .Include(c => c.Classroom)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await studentDetails;
        }
    }
}
