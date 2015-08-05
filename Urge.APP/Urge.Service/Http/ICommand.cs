namespace Urge.Service.Http
{
    using System.Net;

    /// <summary>
    /// 命令接口
    /// </summary>
    public abstract class ICommand
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="requestContext">请求上下文参数</param>
        public abstract Result Excute(HttpListenerRequest requestContext);
    }
}
