using System;
using System.IO;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using log4net.Config;

namespace Sedion.SimpleTask.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            //IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            
            /* log4Net日志记录 */
            XmlConfigurator.Configure(
                new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Log4Net\\log4net.config")
                );

            base.Application_Start(sender, e);
        }
    }
}
