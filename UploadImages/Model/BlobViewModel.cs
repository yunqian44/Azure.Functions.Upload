using System;
using System.Collections.Generic;
using System.Text;

namespace UploadImages.Model
{
    public class BlobViewModel
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
    }
}
