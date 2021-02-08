using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UploadImages.Service
{
    public interface IBlobSergvice
    {
        Task UploadFileBlobAsync(string filePath, string filename);
    }
}
