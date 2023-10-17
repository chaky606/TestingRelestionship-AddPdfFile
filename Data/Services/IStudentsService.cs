using TestingRelestionship.Data.Base;
using TestingRelestionship.Data.ViewModel;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public interface IStudentsService:IEntityBaseRepository<Student>
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<NewStudentDropdownVM> GetNewStudentDropdownVM();
        Task AddNewStudentAsync(NewStudentVM data);
    }
}
