using System;
namespace Urge.Core.Basic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 程序集工具类
    /// </summary>
    public static class DllUtils
    {
        /// <summary>
        /// 加载程序集中某个类
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="path">程序集路径</param>
        /// <param name="nameSpace">命名控件</param>
        /// <param name="className">类名</param>
        /// <returns></returns>
        public static T Load<T>(string path,string nameSpace,string className)
        {
            var assembly = Assembly.LoadFrom(path);
            return (T)assembly.CreateInstance(nameSpace + "." + className, true);
        }
    }
}
