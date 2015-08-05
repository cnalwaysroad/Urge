namespace Urge.Job
{
    #region 基础结果返回

    /// <summary>
    /// 基础结果返回
    /// </summary>
    /// <remarks>2014-07-21 黄波 创建</remarks>
    public class JobResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 状态代码
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 状态消息
        /// </summary>
        public string Message { get; set; }
    }

    #endregion
}
