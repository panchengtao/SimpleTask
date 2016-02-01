using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Sedion.SimpleTask.EntityFramework;

namespace Sedion.SimpleTask
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SimpleTaskCoreModule))]
    public class SimpleTaskDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
