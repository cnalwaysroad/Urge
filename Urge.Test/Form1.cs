using System;
using System.Windows.Forms;

namespace Urge.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var config = new Urge.Job.JobConfig.DtsJobConfig()
            {
                Name = "2",
                CronExpression = "0/2 * * * * ?",
                EndTime = DateTime.Now.AddDays(1),
                StartTime = DateTime.Now,
                ConcurrentExecution = true,
                JobData = new Job.JobData()
                { 
                    {"context","11111225478"}
                },
                AssemblyInfo = new Urge.Job.JobConfig.AssemblyInfo()
                {
                    ClassName = "WriteFile",
                    LocalAbsolutePath = @"D:\Urge\Urge.JobTest\bin\Debug\Urge.JobTest.dll",
                    NameSpace = "Urge.JobTest"
                }
            };
            Urge.Core.Scheduler.Begin(config);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var config = new Urge.Job.JobConfig.DtsJobConfig()
            {
                Name = "21",
                CronExpression = "0/2 * * * * ?",
                EndTime = DateTime.Now.AddDays(1),
                StartTime = DateTime.Now,
                ConcurrentExecution = true,
                JobData = new Job.JobData()
                { 
                    {"context","11111225478"}
                },
                AssemblyInfo = new Urge.Job.JobConfig.AssemblyInfo()
                {
                    ClassName = "Job_Print",
                    LocalAbsolutePath = @"D:\Urge\Urge.Test\bin\Debug\Urge.Test.exe",
                    NameSpace = "Urge.Test"
                }
            };
            Urge.Core.Scheduler.Begin(config);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Urge.Core.Scheduler.DeleteJob("21");
        }
    }
}
