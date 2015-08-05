namespace Urge.Job
{
    /// <summary>
    /// 工作上下文中各种执行信息
    /// </summary>
    public class JobContext
    {
        JobData _jobData = new JobData();
        /// <summary>
        /// 工作数据
        /// </summary>
        public JobData JobData { get { return _jobData; } set { _jobData = value; } }
    }
}
