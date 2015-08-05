namespace Urge.Service
{
    using System;
    using System.Net;
    using System.ServiceProcess;
    using Urge.Service.Http;

    /// <summary>
    /// Urge服务
    /// </summary>
    partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 程序运行目录
        /// </summary>
        public static string UrgeHome = @"D:\UrgeTest\";

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="args">端口</param>
        protected override void OnStart(string[] args)
        {
            CommandListener.Start(Convert.ToInt32(args[0]));      
        }

        protected override void OnStop()
        {
            CommandListener.Stop();
        }
    }
}
