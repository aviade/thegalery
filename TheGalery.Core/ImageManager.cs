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

        public async Task<ImageLibrary> GetAllImages()
        {
            IFileShareReader reader = ReaderFactory.GetReader(credentials);
            return await reader.GetAllImages();
        }

        public async Task<ImageGroup> GetImages(string name)
        {
            IFileShareReader reader = ReaderFactory.GetReader(credentials);
            return await reader.GetImages(name);
        }
    }

    public class ImageLibrary : List<ImageGroup>
    {
        public ImageGroup Root = new ImageGroup("Default");
    }
}
