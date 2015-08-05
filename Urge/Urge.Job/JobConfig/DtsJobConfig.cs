namespace Urge.Job.JobConfig
{
    /// <summary>
    /// 本地任务配置
    /// (DLL实现)
    /// </summary>
    public class DtsJobConfig : IJobConfig
    {
        /// <summary>
        /// 程序集信息
        /// </summary>
        public AssemblyInfo AssemblyInfo { get; set; }
    }

    /// <summary>
    /// 工作程序集信息
    /// </summary>
    public class AssemblyInfo
    {
        /// <summary>
        /// DLL文件本地路径
        /// </summary>
        public string LocalAbsolutePath { get; set; }

        /// <summary>
        /// 程序集命名控件
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
