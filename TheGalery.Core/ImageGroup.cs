using System.Collections.Generic;

namespace TheGalery.Core
{
    public class ImageGroup: List<ImageInfo>
    {
        public string Name { get; private set; }

        public ImageGroup(string name)
        {
            Name = name;
        }
    }
}