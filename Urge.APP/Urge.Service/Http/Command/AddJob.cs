namespace Urge.Service.Http.Command
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// 添加工作
    /// </summary>
    public class AddJob : ICommand
    {
        public override Result Excute(HttpListenerRequest requestContext)
        {
            var result = new Result() { Status = false };

            var jobType = requestContext.QueryString["jobtype"];
            if (string.IsNullOrWhiteSpace(jobType))
            {
                result.Message = "jobtype is empty!";
                return result;
            }

            switch (jobType.ToLower())
            {
                case "dts":
                    result = AddDtsJob(requestContext);
                    break;
                case "hts":
                    result = AddHtsJob(requestContext);
                    break;
                case "wts":
                    result = AddWtsJob(requestContext);
                    break;
                default:
                    result.Message = "jobtype is invalid,Limited to [dts,hts,wts]";
                    return result;
            }

            return result;
        }

        Result AddDtsJob(HttpListenerRequest requestContext)
        {
            var jobName = requestContext.QueryString["name"];

            var config = new Job.JobConfig.DtsJobConfig()
            {
                AssemblyInfo = new Job.JobConfig.AssemblyInfo()
                {
                    ClassName = "",
                    LocalAbsolutePath = "",
                    NameSpace = ""
                },
                ConcurrentExecution = true,
                CronExpression = "",
                EndTime = DateTime.Now,
                JobData = new Job.JobData() { },
                Name = jobName,
                StartTime = DateTime.Now
            };

            File.AppendAllText(string.Format(Service.UrgeHome + @"\Job\{0}", jobName), config.ToJson(), System.Text.Encoding.Default);

            return new Result() { Status = true };
        }

        Result AddHtsJob(HttpListenerRequest requestContext)
        {
            return new Result() { Status = true };
        }

        Result AddWtsJob(HttpListenerRequest requestContext)
        {
            return new Result() { Status = true };
        }
    }
}
