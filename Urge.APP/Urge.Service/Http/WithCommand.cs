namespace Urge.Service.Http
{
    using System;
    using System.Net;

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
            var result = new Result() { Status = false };

            if (!AuthCodeValidate(requestContext.QueryString["authcode"]))
            {
                result.Message = "AuthCode is invalid or has expired!";
                return result.ToJson();
            }

            try
            {
                var commandString = requestContext.QueryString["command"];

                var command = (ICommand)this.GetType().Assembly.CreateInstance("Urge.Service.Http.Command." + commandString);

                result = command.Excute(requestContext);
            }
            catch(Exception ex)
            {
                //result.Message = "Command is invalid, the attention is case sensitive!";
                result.Message = ex.Message;
            }

            return result.ToJson();
        }

        /// <summary>
        /// 授权码验证
        /// </summary>
        /// <param name="authCode">授权码</param>
        /// <returns></returns>
        private bool AuthCodeValidate(string authCode)
        {
            if (string.IsNullOrWhiteSpace(authCode)) return false;
            if (authCode != "123456") return false;

            return true;
        }
    }
}