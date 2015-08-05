namespace Urge.Core.Job
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Urge.Core.Basic;

    /// <summary>
    /// 本地任务
    /// (不允许并发执行)
    /// </summary>
    [Quartz.DisallowConcurrentExecution]
    public class DtsJobDisallowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// 本地任务
    /// (允许并发执行)
    /// </summary>
    public class DtsJobAllowConcurrent : Quartz.IJob
    {
        public void Execute(Quartz.IJobExecutionContext context)
        {
            DtsJob.Execute(context);
        }
    }

    /// <summary>
    /// 本地任务
    /// </summary>
    internal class DtsJob
    {
        public static void Execute(Quartz.IJobExecutionContext context)
        {
            try
            {
                var job = DllUtils.Load<Urge.Job.IJob>(context.MergedJobDataMap["_Assembly_Path_"].ToString(), context.MergedJobDataMap["_Assembly_NameSpace_"].ToString(), context.MergedJobDataMap["_Assembly_ClassName_"].ToString());

                var jobContext = new Urge.Job.JobContext();

                foreach (var item in context.MergedJobDataMap)
                {
                    jobContext.JobData[item.Key] = item.Value.ToString();
                }

                job.Excute(jobContext);
            }
            catch (Exception ex)
            {
                File.AppendAllText(@"D:\QuartzTest\111.txt", ex.StackTrace, Encoding.Default);
            }
        }
    }
}
