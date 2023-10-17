using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using TestingRelestionship.Data.Services;
using TestingRelestionship.Models;

namespace TestingRelestionship.Controllers
{
    public class FileStoresController : Controller
    {
        private readonly IFileStoresService _service;
        public FileStoresController(IFileStoresService service)
        {
            _service = service;
        }


        //Get: FileStore/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public string SaveFile(FileUpload fileObj)
        {
            FileStore oFileStore = JsonConvert.DeserializeObject<FileStore>(fileObj.FileStore12);

            if (fileObj.Pdffile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.Pdffile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oFileStore.Data = fileBytes;

                    oFileStore = _service.Save(oFileStore);
                    if (oFileStore.Id > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public JsonResult GetSaveFileStore()
        {
            var fileStore = _service.GetSaveFileStore();
            fileStore.Data = this.GetImage(Convert.ToBase64String(fileStore.Data));
            return Json(fileStore);
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> Files, int StudentId)
        {
            foreach (var formFile in Files)
            {
                if (formFile.Length > 0)
                {
                    var extension = Path.GetExtension(formFile.FileName).ToLower();
                    if (extension == ".pdf")
                    {
                        using var memoryStream = new MemoryStream();
                        await formFile.CopyToAsync(memoryStream);
                       // byte[] fileData = memoryStream.ToArray();

                            var pdfFile = new FileStore
                            {
                                Name = formFile.FileName,
                                ContenType = "PDF file description", // Provide a description if needed
                                Data = memoryStream.ToArray(),
                                StudentId = StudentId
                            };
                            _service.Add(pdfFile);
                            //return RedirectToAction("Index");
                        
                    }
                    else
                    {
                        return BadRequest("Only PDF files are allowed.");
                    }
                }
            }


            // Redirect to another action or return a view
            return RedirectToAction("Index");
        }
    }
}
