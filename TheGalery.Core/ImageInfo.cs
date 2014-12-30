namespace TheGalery.Core
{
    public class ImageInfo
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public ImageInfo(string title, string path)
        {
            Title = title;
            Path = path;
        }
    }
}