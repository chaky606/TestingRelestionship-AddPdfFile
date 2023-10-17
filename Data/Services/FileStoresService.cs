using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingRelestionship.Data.ViewModel;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public class FileStoreService : IFileStoresService
    {
        private readonly AppDbContext _context;
        public FileStoreService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(FileStore fileStore)
        {
            _context.FileStores.Add(fileStore);
            _context.SaveChanges();
        }

        public async Task AddNewFileAsync(IFormFile Files, FileStore data)
        {
            using (var ms = new MemoryStream())
            {
                var fileBytes = ms.ToArray();
                byte[] Data = fileBytes.ToArray();
                var pdfFile = new FileStore
                {
                    Name = Files.FileName,
                    ContenType = "PDF file description", // Provide a description if needed
                    Data = Data,
                    
                };
            }
            var newFileStore = new FileStore()
            {
                StudentId = data.StudentId
            };
            await _context.FileStores.AddAsync(newFileStore);
            await _context.SaveChangesAsync();
        }

        public Task AddNewFileAsync(NewFileStoreVM data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public FileStore GetSaveFileStore()
        {
            return _context.FileStores.SingleOrDefault();
        }

        public FileStore Save(FileStore oFileStore)
        {
            _context.FileStores.Add(oFileStore);
            _context.SaveChanges();
            return oFileStore;
        }


    }
}
