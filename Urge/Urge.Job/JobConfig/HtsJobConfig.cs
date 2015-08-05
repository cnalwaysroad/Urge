using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urge.Job.JobConfig
{
    /// <summary>
    /// HTTP任务配置
    /// </summary>
    public class HtsJobConfig : IJobConfig
    {
        /// <summary>
        /// Http地址
        /// </summary>
        public Uri HttpUri { get; set; }

        /// <summary>
        /// 请求方式
        /// (GET OR POST)
        /// </summary>
        public string RequestMethod { get; set; }
    }
}
