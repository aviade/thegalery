﻿using System.Collections.Generic;
using System.IO;
using TheGalery.Core;

namespace TheGalery.Web.Models
{
    public class HomeViewModel
    {
        public ImageGroupViewModel RootImageGroup { get; private set; }
        public IEnumerable<ImageGroupViewModel> ImageGroups { get; private set; }

        public HomeViewModel(ImageGroupViewModel rootImageGroup, IEnumerable<ImageGroupViewModel> imageGroups)
        {
            RootImageGroup = rootImageGroup;
            ImageGroups = imageGroups;
        }
    }

    public class ImageGroupViewModel : List<ImageViewRow>
    {
        public string GroupName { get; private set; }

        public ImageGroupViewModel(string groupName)
        {
            GroupName = groupName;
        }

        private string GetRelativePath(string folder, string fileName)
        {
            string relativePath = string.Format("~/{0}/{1}", folder.Replace(@"\", "/"), fileName);
            return relativePath;
        }
    }

    public class ImageViewRow
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public ImageSize ImageSize { get; private set; }
        public string RelativePath { get; private set; }

        public ImageViewRow(string name, string path, ImageSize imageSize, string relativePath)
        {
            Name = name;
            Path = path;
            ImageSize = imageSize;
            RelativePath = relativePath;
        }
    }

    public class PhotoViewRow: ImageViewRow
    {
        public string GroupName { get; private set; }

        public PhotoViewRow(string name, string path, ImageSize imageSize, string groupName, string relativePath) : base(name, path, imageSize, relativePath)
        {
            GroupName = groupName;
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