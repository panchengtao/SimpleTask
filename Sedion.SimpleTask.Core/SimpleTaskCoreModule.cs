using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using Sedion.SimpleTask.Authorization;
using Sedion.SimpleTask.Authorization.Roles;

namespace Sedion.SimpleTask
{
    [DependsOn(typeof (AbpZeroCoreModule))]
    public class SimpleTaskCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SimpleTaskConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Sedion.SimpleTask.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
            Configuration.Auditing.IsEnabled = false;
            Configuration.MultiTenancy.IsEnabled = false;

            Configuration.Authorization.Providers.Add<SimpleTaskAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}