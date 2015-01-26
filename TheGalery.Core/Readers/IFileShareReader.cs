using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheGalery.Core.Readers
{
    public interface IFileShareReader   
    {
        Task<ImageLibrary> GetFolders();
        Task<ImageLibrary> GetFolders(string path);
        Task<ImageFolder> GetImages(string name);
    }
}