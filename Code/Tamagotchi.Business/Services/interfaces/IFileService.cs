using System.Threading.Tasks;

namespace Tamagotchi.Business.Services.interfaces
{
    public interface IFileService
    {
        Task SaveFile(string fileName, string content);
    }
}