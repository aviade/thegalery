using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGalery.Core.Readers
{
    internal class DefaultReader : IFileShareReader
    {
        private readonly List<ImageGroup> result;

        public DefaultReader()
        {
            result = new List<ImageGroup>();
            result.Add(new ImageGroup("Passport"));
            result.Add(new ImageGroup("InteriorDesign"));
            result.Add(new ImageGroup("Familiy"));
        }

        public Task<List<ImageGroup>> GetAllImages()
        {
            return Task.FromResult(result);
        }

        public Task<ImageGroup> GetImages(string name)
        {
            return Task.FromResult(result.Single(@group => @group.Name == name));
        }
    }
}