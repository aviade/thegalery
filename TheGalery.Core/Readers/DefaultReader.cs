using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGalery.Core.Readers
{
    internal class DefaultReader : IFileShareReader
    {
        private readonly ImageLibrary result;

        public DefaultReader()
        {
            result = new ImageLibrary();
            result.Add(new ImageFolder("Passport"));
            result.Add(new ImageFolder("Interior Design"));
            result.Add(new ImageFolder("Familiy"));
            result.Add(new ImageFolder("Art"));
            result.Add(new ImageFolder("Misc"));
        }

        public Task<ImageLibrary> GetFolders()
        {
            return Task.FromResult(result);
        }

        public Task<ImageLibrary> GetFolders(string path)
        {
            return Task.FromResult(result);
        }

        public Task<ImageFolder> GetImages(string name)
        {
            return Task.FromResult(result.Single(@group => @group.Name == name));
        }
    }
}