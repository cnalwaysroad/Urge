namespace Urge.Core
{
    using Urge.Job.JobConfig;

    /// <summary>
    /// 调度器
    /// </summary>
    public class Scheduler
    {
        #region 调度器实例

        private static Quartz.IScheduler _scheduler = null;

        private static readonly object syncRoot = new object();

        /// <summary>
        /// 任务调度器
        /// </summary>
        private static Quartz.IScheduler SchedulerBuilder
        {
            get
            {
                if (_scheduler == null)
                {
                    lock (syncRoot)
                    {
                        if (_scheduler == null)
                        {
                            _scheduler = new Quartz.Impl.StdSchedulerFactory().GetScheduler();
                        }
                    }
                }
                return _scheduler;
            }
        }

        #endregion

        #region 任务调度管理

        /// <summary>
        /// 启动调度器
        /// </summary>
        static void Start()
        {
            if (!SchedulerBuilder.IsStarted || SchedulerBuilder.IsShutdown) SchedulerBuilder.Start();
        }

        /// <summary>
        /// 关闭调度器
        /// (暂不提供)
        /// </summary>
        //public static void Shutdown()
        //{
        //    //if (!SchedulerBuilder.IsShutdown)SchedulerBuilder.Shutdown();
        //}

        /// <summary>
        /// 删除工作
        /// </summary>
        /// <param name="jobName">工作名称</param>
        public static void DeleteJob(string jobName)
        {
            var jobKey = JobKeyBuilder(jobName);
            if (SchedulerBuilder.CheckExists(jobKey)) SchedulerBuilder.DeleteJob(jobKey);
        }

        /// <summary>
        /// 暂停工作
        /// </summary>
        /// <param name="jobName">工作名称</param>
        public static void PauseJob(string jobName)
        {
            var jobKey = JobKeyBuilder(jobName);
            if (SchedulerBuilder.CheckExists(jobKey)) SchedulerBuilder.PauseJob(jobKey);
        }

        /// <summary>
        /// 重启工作
        /// </summary>
        /// <param name="jobName">工作名称</param>
        public static void ResumeJob(string jobName)
        {
            var jobKey = JobKeyBuilder(jobName);
             if (SchedulerBuilder.CheckExists(jobKey)) SchedulerBuilder.ResumeJob(jobKey);
        }

        /// <summary>
        /// 调度任务
        /// </summary>
        /// <param name="jobDetail">工作内容</param>
        /// <param name="trigger">触发器</param>
        static Urge.Job.JobResult Begin(Quartz.JobBuilder jobBuilder, IJobConfig jobConfig)
        {
            var result = new Urge.Job.JobResult() { Status = false };

            if(string.IsNullOrWhiteSpace(jobConfig.Name))
            {
                result.Message = "任务名称不能为空!";
                return result;
            }

            if (jobConfig.StartTime > jobConfig.EndTime)
            {
                result.Message = "任务开始时间不能大于结束时间!";
                return result;
            }

            var job = jobBuilder.WithIdentity(JobKeyBuilder(jobConfig)).Build();
            if (jobConfig.JobData != null)
            {
                foreach (var data in jobConfig.JobData)
                {
                    job.JobDataMap[data.Key] = data.Value;
                }
            }

            if (!SchedulerBuilder.CheckExists(JobKeyBuilder(jobConfig)))
            {
                SchedulerBuilder.ScheduleJob(job, TriggerBuilder(jobConfig));
                Start();

                result.Status = true;
                result.Message = "任务调度成功!";
            }
            else
            {
                result.Message = "任务调度失败,请确保任务名称唯一!";
            }

            return result;
        }

        #endregion

        #region 创建相关
        /// <summary>
        /// 创建触发器
        /// </summary>
        /// <param name="config">工作配置</param>
        /// <returns></returns>
        static Quartz.ITrigger TriggerBuilder(IJobConfig config)
        {
            return new Quartz.Impl.Triggers.CronTriggerImpl(config.Name, null, config.Name, null, config.StartTime, config.EndTime, config.CronExpression);
        }

        /// <summary>
        /// 创建JobKey
        /// </summary>
        /// <param name="config">工作配置</param>
        /// <returns></returns>
        static Quartz.JobKey JobKeyBuilder(IJobConfig config)
        {
            return JobKeyBuilder(config.Name);
        }

        /// <summary>
        /// 创建JobKey
        /// </summary>
        /// <param name="jobName">工作名称</param>
        /// <returns></returns>
        static Quartz.JobKey JobKeyBuilder(string jobName)
        {
            return new Quartz.JobKey(jobName);
        }
        #endregion

        #region 本地任务
        /// <summary>
        /// 开始调度任务
        /// </summary>
        /// <param name="config">本地任务配置</param>
        public static Urge.Job.JobResult Begin(DtsJobConfig config)
        {
            Quartz.JobBuilder jobBuilder;

            if (config.ConcurrentExecution)
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.DtsJobAllowConcurrent>();
            }
            else
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.DtsJobDisallowConcurrent>();
            }

            //指定任务程序集信息
            config.JobData.Add("_Assembly_Path_", config.AssemblyInfo.LocalAbsolutePath);
            config.JobData.Add("_Assembly_NameSpace_", config.AssemblyInfo.NameSpace);
            config.JobData.Add("_Assembly_ClassName_", config.AssemblyInfo.ClassName);

            return Begin(jobBuilder, config);
        }
        #endregion

        #region HTTP任务

        /// <summary>
        /// 开始调度任务
        /// </summary>
        /// <param name="config">本地任务配置</param>
        public static Urge.Job.JobResult Begin(HtsJobConfig config)
        {
            Quartz.JobBuilder jobBuilder;

            if (config.ConcurrentExecution)
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.HtsJobAllowConcurrent>();
            }
            else
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.HtsJobDisallowConcurrent>();
            }

            config.JobData.Add("_Http_Uri_", config.HttpUri.AbsolutePath);
            config.JobData.Add("_Http_RequestMethod_", config.RequestMethod);


            return Begin(jobBuilder, config);
        }

        #endregion

        #region WCF任务

        /// <summary>
        /// 开始调度任务
        /// </summary>
        /// <param name="config">本地任务配置</param>
        public static Urge.Job.JobResult Begin(WtsJobConfig config)
        {
            Quartz.JobBuilder jobBuilder;

            if (config.ConcurrentExecution)
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.WtsJobAllowConcurrent>();
            }
            else
            {
                jobBuilder = Quartz.JobBuilder.Create<Urge.Core.Job.WtsJobDisallowConcurrent>();
            }

            return Begin(jobBuilder, config);
        }

        #endregion
    }
}
