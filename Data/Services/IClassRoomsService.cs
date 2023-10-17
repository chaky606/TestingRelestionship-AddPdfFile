using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public interface IClassRoomsService
    {
        Task<IEnumerable<Classroom>> GetAll();
        Classroom GetById(int id);
        void Add(Classroom classroom);
        Classroom Update(int id, Classroom newClassroom);
        void Delete(int id);
    }
}
