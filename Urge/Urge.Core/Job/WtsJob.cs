namespace Urge.Core.Job
{
    /// <summary>
    /// WCF任务
    /// (不允许并发执行)
    /// </summary>
    public class WtsJobDisallowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// WCF任务
    /// (允许并发执行)
    /// </summary>
    public class WtsJobAllowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// WCF任务
    /// </summary>
    internal class WtsJob
    {
        public static void Execute(Quartz.IJobExecutionContext context)
        {
           
        }
    }
}
