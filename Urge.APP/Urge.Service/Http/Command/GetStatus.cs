using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urge.Service.Http.Command
{
    /// <summary>
    /// 获取服务状态命令
    /// </summary>
    public class GetStatus : ICommand
    {
        public override Result Excute(System.Net.HttpListenerRequest requestContext)
        {
            return new Result() { Status=true, Message="Runing!" };
        }
    }
}
