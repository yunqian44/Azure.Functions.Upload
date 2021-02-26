using System;
using System.Collections.Generic;
using System.Text;

namespace UploadImages.Extension
{
    public static class StringExtensions
    {
        public static string EncryptBase64(this string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(b);
        }

        public static string DecodeBase64(this string s)
        {
            byte[] b = Convert.FromBase64String(s);
            return Encoding.UTF8.GetString(b);
        }
    }
}
