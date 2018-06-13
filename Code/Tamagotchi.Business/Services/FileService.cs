using System;
using System.IO;
using System.Threading.Tasks;
using Tamagotchi.Business.Services.interfaces;

namespace Tamagotchi.Business.Services
{
    public class FileService : IFileService
    {
        public Task SaveFile(string fileName, string content)
        {
            using (var writeStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var bytes = Convert.FromBase64String(content);

                return writeStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}