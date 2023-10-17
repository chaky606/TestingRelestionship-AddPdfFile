using TestingRelestionship.Data.ViewModel;
using TestingRelestionship.Models;

namespace TestingRelestionship.Data.Services
{
    public interface IFileStoresService
    {
        void Add(FileStore fileStore);
        void Delete(int id);
        Task AddNewFileAsync(NewFileStoreVM data);
        FileStore Save(FileStore oFileStore);
        FileStore GetSaveFileStore();
    }
}
