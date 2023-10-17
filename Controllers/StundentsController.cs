using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingRelestionship.Data.Services;
using TestingRelestionship.Models;

namespace TestingRelestionship.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;
        public StudentsController(IStudentsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allStundets = await _service.GetAllAsync();
            return View(allStundets);
        }

        //Get: Student/Details
        public async Task<IActionResult> Detail(int id)
        {
            var studentDetail = await _service.GetStudentByIdAsync(id);
            return View(studentDetail);
        }

        //Get: Student/Create
        public async Task<IActionResult> Create()
        {
            var studentDropdownData = await _service.GetNewStudentDropdownVM();
            ViewBag.Techer = new SelectList(studentDropdownData.Techers, "Id", "TchName");
            ViewBag.Classroom = new SelectList(studentDropdownData.Classrooms, "Id", "RoomNumber");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewStudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _service.AddNewStudentAsync(student);
            return RedirectToAction(nameof(Index));

        }
    }
}
