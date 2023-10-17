using Microsoft.AspNetCore.Mvc;
using TestingRelestionship.Data.Services;
using TestingRelestionship.Models;

namespace TestingRelestionship.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly IClassRoomsService _service;

        public ClassroomsController(IClassRoomsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Classrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RoomNumber,Bio")] Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return View(classroom);
            }
            _service.Add(classroom);
            return RedirectToAction(nameof(Index));
        }
    }
}
