using System.Collections.Generic;
using System.Threading.Tasks;
using TheGalery.Core.Readers;

namespace TheGalery.Core
{
    public class ImageManager
    {
        private UserCredentials credentials;

        public ImageManager(UserCredentials credentials)
        {
            this.credentials = credentials;
        }

        public async Task<List<ImageGroup>> GetAllImages()
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
}
