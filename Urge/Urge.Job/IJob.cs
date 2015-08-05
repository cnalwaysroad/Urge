using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urge.Job
{
    /// <summary>
    /// Urge对外的工作接口
    /// 所有自定义工作须实现该接口
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// 实现该方法以便完成你的工作
        /// </summary>
        /// <param name="context">工作上下文</param>
        /// <anthor>黄波</anthor>
        JobResult Excute(JobContext context);
    }
}
