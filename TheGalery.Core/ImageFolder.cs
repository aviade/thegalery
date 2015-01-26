using System.Collections.Generic;

namespace TheGalery.Core
{
    public class ImageFolder: List<ImageInfo>
    {
        public string Name { get; private set; }
        public string Location { get; set; }
        public ImageFolder(string name)
        {
            Name = name;
        }
    }
}