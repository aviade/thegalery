﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGalery.Core.Readers
{
    public class GoogleDriveReader: IFileShareReader
    {
        public Task<ImageLibrary> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public Task<ImageGroup> GetImages(string name)
        {
            throw new NotImplementedException();
        }
    }
}
