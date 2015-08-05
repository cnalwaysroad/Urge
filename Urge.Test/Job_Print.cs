using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urge.Test
{
    public class Job_Print : Urge.Job.IJob
    {
        Job.JobResult Job.IJob.Excute(Job.JobContext context)
        {
            File.AppendAllText(string.Format(@"D:\QuartzTest\{0}.txt", Guid.NewGuid().ToString("N")), context.JobData["context"]);
            return new Job.JobResult() { Status = true };
        }
    }
}
