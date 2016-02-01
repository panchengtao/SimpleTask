using System;
using log4net;

namespace Sedion.SimpleTask.Web.Log4Net
{
    /// <summary>
    ///     日志记录类
    ///     注册方法如下代码
    ///     XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Log4Net\\log4net.config"));
    /// </summary>
    public class LoggerHelper
    {
        #region 初始化属性

        private static readonly ILog Loginfo = LogManager.GetLogger("loginfo");
        private static readonly ILog Logerror = LogManager.GetLogger("logerror");
        private static readonly ILog Logmonitor = LogManager.GetLogger("logmonitor");
        private static readonly ILog Logdebug = LogManager.GetLogger("logdebug");

        #endregion

        #region 日志方法

        /// <summary>
        ///     Error记录
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        /// <param name="ex">可选的异常</param>
        public static void Error(string errorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                Logerror.Error(errorMsg, ex);
            }
            else
            {
                Logerror.Error(errorMsg);
            }
        }

        /// <summary>
        ///     Info记录
        /// </summary>
        /// <param name="msg">记录信息</param>
        public static void Info(string msg)
        {
            Loginfo.Info(msg);
        }

        /// <summary>
        ///     Monitor记录
        /// </summary>
        /// <param name="msg">记录信息</param>
        public static void Monitor(string msg)
        {
            Logmonitor.Info(msg);
        }

        /// <summary>
        ///     Debug记录
        /// </summary>
        /// <param name="msg">记录信息</param>
        public static void Debug(string msg)
        {
            Logdebug.Debug(msg);
        }

        #endregion
    }
}