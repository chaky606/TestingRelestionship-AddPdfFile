using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public class ClassRoomsService : IClassRoomsService
    {
        private readonly AppDbContext _context;
        public ClassRoomsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Classroom>> GetAll()
        {
            var result = await _context.Classrooms.ToListAsync();
            return result;
        }

        public Classroom GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Classroom Update(int id, Classroom newClassRoom)
        {
            throw new NotImplementedException();
        }
    }
}
