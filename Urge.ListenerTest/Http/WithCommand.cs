namespace Urge.Service.Http
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System;

    /// <summary>
    /// 命令处理
    /// </summary>
    public class WithCommand
    {
        /// <summary>
        /// 处理程序
        /// </summary>
        /// <param name="request">请求上下文</param>
        public string Handle(HttpListenerRequest requestContext)
        {
            var command = requestContext.QueryString["command"];

            //byte[] fileBuffer = new byte[1024 * 32];

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    while (true)
            //    {
            //        int read = requestContext.InputStream.Read(fileBuffer, 0, fileBuffer.Length);
            //        if (read <= 0)
            //        {
            //            FileStream fs = new FileStream("C:\\111.xlsx", FileMode.OpenOrCreate);
            //            byte[] buff = ms.ToArray();
            //            fs.Write(buff, 0, buff.Length);
            //            fs.Close();
            //            break;

            //        }
            //        ms.Write(fileBuffer, 0, read);
            //    }
            //}
            return "200";
        }
    }
}