﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UploadImages.Service
{
    public interface IBlobService
    {
        Task UploadImagesBlobAsync(string filePath, string filename);

        Task UploadFileBlobAsync(string filePath, string filename);

        Task UploadContentBlobAsync(string content, string filename);
    }
}
