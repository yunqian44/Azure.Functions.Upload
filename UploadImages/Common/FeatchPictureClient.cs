using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace UploadImages.Common
{
    public class FeatchPictureClient
    {
        /// <summary>
        /// 获取URL响应对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebResponse GetWebResponse(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.KeepAlive = true;
            WebResponse res = request.GetResponse();
            return res;
        }

        public static byte[] GetResponseStream(WebResponse response)
        {
            Stream smRes = response.GetResponseStream();
            byte[] resBuf = new byte[10240];
            int nReaded = 0;
            MemoryStream memSm = new MemoryStream();
            while ((nReaded = smRes.Read(resBuf, 0, 10240)) != 0)
            {
                memSm.Write(resBuf, 0, nReaded);
            }
            byte[] byResults = memSm.ToArray();
            memSm.Close();
            return byResults;
        }
    }
}
