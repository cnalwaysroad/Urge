using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urge.Service.Http.Command
{
    /// <summary>
    /// 运行工作命令
    /// </summary>
    public class RunJob : ICommand
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="requestContext">参数</param>
        public override Result Excute(System.Net.HttpListenerRequest requestContext)
        {
            return new Result() { Status = true };
        }
    }
}
