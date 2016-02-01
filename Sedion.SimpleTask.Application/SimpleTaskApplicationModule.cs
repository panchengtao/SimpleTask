using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Sedion.SimpleTask
{
    [DependsOn(typeof(SimpleTaskCoreModule), typeof(AbpAutoMapperModule))]
    public class SimpleTaskApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
