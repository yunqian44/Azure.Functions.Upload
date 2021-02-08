using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UploadImages.Extension;

namespace UploadImages.Service
{
    class BlobService : IBlobSergvice
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
    }
}
