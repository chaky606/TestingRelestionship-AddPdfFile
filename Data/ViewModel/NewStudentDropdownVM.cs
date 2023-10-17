using TestingRelestionship.Models;

namespace TestingRelestionship.Data.ViewModel
{
    public class NewStudentDropdownVM
    {
        public NewStudentDropdownVM()
        {
            Techers = new List<Techer>();
            Classrooms = new List<Classroom>();
        }
        public List<Techer> Techers { get; set; }
        public List<Classroom> Classrooms { get; set; }
    }
}
