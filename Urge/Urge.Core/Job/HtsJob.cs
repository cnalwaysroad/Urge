namespace Urge.Core.Job
{
    /// <summary>
    /// HTTP任务
    /// (不允许并发执行)
    /// </summary>
    public class HtsJobDisallowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// HTTP任务
    /// (允许并发执行)
    /// </summary>
    public class HtsJobAllowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// HTTP任务
    /// </summary>
    internal class HtsJob
    {
        public static void Execute(Quartz.IJobExecutionContext context)
        {

        }
    }
}