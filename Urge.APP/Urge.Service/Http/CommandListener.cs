namespace Urge.Service.Http
{
    using System;
    using System.Net;

    /// <summary>
    /// Urge状态监听
    /// </summary>
    public static class CommandListener
    {
        static HttpListener listener;

        /// <summary>
        /// 启动监听
        /// </summary>
        public static void Start(int port)
        {
            listener = new HttpListener();
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            listener.Prefixes.Add(string.Format("http://*:{0}/", port));
            listener.Start();
            listener.BeginGetContext(new System.AsyncCallback(GetContextCallBack), listener);
        }

        static void GetContextCallBack(IAsyncResult ar)
        {
            var listenerContext = ar.AsyncState as HttpListener;
            var context = listenerContext.EndGetContext(ar);
            listener.BeginGetContext(new AsyncCallback(GetContextCallBack), listener);
            var response = context.Response;

            string outputContext = "";

            try
            {
                outputContext = new WithCommand().Handle(context.Request);

            }
            catch (Exception ex)
            {
                outputContext = ex.Message;
            }

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(outputContext);
            response.StatusCode = 200;
            response.AddHeader("Content-type", "text/html; charset=utf-8");
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            response.Close();
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        public static void Stop()
        {
            listener.Stop();
        }
    }
}
