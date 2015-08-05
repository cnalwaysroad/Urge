using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Urge.Job.JobConfig
{
    /// <summary>
    /// 工作配置接口
    /// </summary>
    public class IJobConfig
    {
        /// <summary>
        /// 工作名称
        /// (调度器唯一)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Cron表达式
        /// "0/2 * * * * ?"
        /// </summary>
        public string CronExpression { get; set; }

        bool _concurrentExecution = false;
        /// <summary>
        /// 是否允许并发执行
        /// </summary>
        public bool ConcurrentExecution { get { return _concurrentExecution; } set { _concurrentExecution = value; } }

        JobData _jobData = new JobData();
        /// <summary>
        /// 工作数据
        /// </summary>
        public JobData JobData { get { return _jobData; } set { _jobData = value; } }
    }
}
