using System.IO;
using System.Threading.Tasks;

namespace Tamagotchi.Business.Services
{
    public interface IFileService
    {
        Task SaveFile(string fileName, string content);
        Task GetFile(string fileName);
    }
}