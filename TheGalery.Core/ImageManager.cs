using System.Collections.Generic;
using System.Threading.Tasks;
using TheGalery.Core.Readers;

namespace TheGalery.Core
{
    public class ImageManager
    {
        private readonly UserCredentials credentials;

        public ImageManager(UserCredentials credentials)
        {
            this.credentials = credentials;
        }

        public async Task<ImageLibrary> GetFolders()
        {
            IFileShareReader reader = ReaderFactory.GetReader(credentials);
            return await reader.GetFolders();
        }

        public async Task<ImageFolder> GetImages(string name)
        {
            IFileShareReader reader = ReaderFactory.GetReader(credentials);
            return await reader.GetImages(name);
        }
    }

    public class ImageLibrary : List<ImageFolder>
    {
        public ImageFolder Root = new ImageFolder("Default");
    }
}
