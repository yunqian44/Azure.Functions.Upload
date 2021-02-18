using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UploadImages.Extension;

namespace UploadImages.Service
{
    class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        
        public BlobService(BlobServiceClient blobServiceClient)
        {
            this._blobServiceClient = blobServiceClient;
        }

        #region 03，上传图片，根据文件路径和文件名称+async Task UploadFileBlobAsync(string filePath, string filename)
        /// <summary>
        /// 上传图片流，根据文件路径和文件名称
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public async Task UploadFileBlobAsync(string filePath, string filename)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("picturecontainer");
            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });
        }
        #endregion

        #region 04，上传文件内容，根据文件内容和文件名称+async Task UploadContentBlobAsync(string content, string filename)
        /// <summary>
        /// 上传文件流，根据文件内容和文件名称
        /// </summary>
        /// <param name="content">文件内容</param>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public async Task UploadContentBlobAsync(string content, string filename)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("picturecontainer");
            var blobClient = containerClient.GetBlobClient(filename);
            var bytes = Encoding.UTF8.GetBytes(content);
            await using var memoryStream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders() { ContentType = filename.GetContentType() });
        }
        #endregion

    }
}
