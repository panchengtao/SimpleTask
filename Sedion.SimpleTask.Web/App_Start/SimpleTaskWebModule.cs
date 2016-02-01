using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Sedion.SimpleTask.Api;
using Sedion.SimpleTask.Web.Navigation;

namespace Sedion.SimpleTask.Web
{
    [DependsOn(
        typeof(SimpleTaskDataModule), 
        typeof(SimpleTaskApplicationModule), 
        typeof(SimpleTaskWebApiModule),
        typeof(AbpWebMvcModule))]
    public class SimpleTaskWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<SimpleTaskNavigationProvider>();
            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
