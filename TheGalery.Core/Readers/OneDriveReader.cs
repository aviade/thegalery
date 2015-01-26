using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Live;

namespace TheGalery.Core.Readers
{
    public class OneDriveReader: IFileShareReader
    {
        private readonly LiveConnectClient client;

        public OneDriveReader(LiveConnectClient client)
        {
            this.client = client;
        }

        public async Task<ImageLibrary> GetFolders()
        {
            var path = "me//skydrive";
            return  await GetFolders(path);
        }

        public async Task<ImageLibrary> GetFolders(string path)
        {
            var folderId = await GetFolderId(path);
            var imageLibrary = new ImageLibrary();
            if (string.IsNullOrEmpty(folderId))
            {
                return imageLibrary;
            }
            LiveOperationResult content = await client.GetAsync(folderId);
            if (!content.Result.ContainsKey("data"))
            {
                return imageLibrary;
            }
            var rootItems = (IList<object>)content.Result["data"];
            foreach (IDictionary<string, object> item in rootItems)
            {
                if (item["type"].ToString() == "folder")
                {
                    var name = item["name"].ToString();
                    var imageFolder = new ImageFolder(name)
                    {
                        Location = ParseUploadLocation(item["upload_location"].ToString())
                    };
                    imageLibrary.Add(imageFolder);
                }
            }

            return imageLibrary;
        }

        private async Task<string> GetFolderId(string folderPath)
        {
            LiveOperationResult liveOperationResult = await client.GetAsync(folderPath);
            string location = (string) liveOperationResult.Result["upload_location"];
            return ParseUploadLocation(location);
        }

        private static string ParseUploadLocation(string location)
        {
            int folderIndex = location.IndexOf("folder.", StringComparison.OrdinalIgnoreCase);
            if (folderIndex == -1)
            {
                return String.Empty;
            }
            string rootFolderId = location.Substring(folderIndex);
            return rootFolderId;
        }

        public Task<ImageFolder> GetImages(string name)
        {
            throw new NotImplementedException();
        }
    }
}
