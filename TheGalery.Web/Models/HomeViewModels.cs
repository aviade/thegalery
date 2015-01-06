using System.Collections.Generic;
using System.IO;
using TheGalery.Core;

namespace TheGalery.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ImageGroupViewModel> Images { get; private set; }

        public HomeViewModel(IEnumerable<ImageGroupViewModel> images)
        {
            Images = images;
        }
    }

    public class ImageGroupViewModel : List<ImageViewRow>
    {
        public string Name { get; private set; }

        public ImageGroupViewModel(string name, string path)
        {
            Name = name;
            var directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                Add(new ImageViewRow(file.Name, file.FullName, 
                    ImageSize.Small));
            }
        }
    }

    public class ImageViewRow
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public ImageSize ImageSize { get; private set; }

        public ImageViewRow(string name, string path, ImageSize imageSize)
        {
            Name = name;
            Path = path;
            ImageSize = imageSize;
        }
    }

    public enum ImageSize
    {
        Small,
        Medium,
        Large,
        AsIs
    }
}