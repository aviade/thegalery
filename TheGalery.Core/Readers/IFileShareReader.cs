using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheGalery.Core.Readers
{
    public interface IFileShareReader
    {
        Task<ImageLibrary> GetAllImages();
        Task<ImageGroup> GetImages(string name);
    }
}