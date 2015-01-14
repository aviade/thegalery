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
            result.Add(new ImageGroup("Passport"));
            result.Add(new ImageGroup("Interior Design"));
            result.Add(new ImageGroup("Familiy"));
            result.Add(new ImageGroup("Art"));
            result.Add(new ImageGroup("Misc"));
        }

        public Task<ImageLibrary> GetAllImages()
        {
            return Task.FromResult(result);
        }

        public Task<ImageGroup> GetImages(string name)
        {
            return Task.FromResult(result.Single(@group => @group.Name == name));
        }
    }
}