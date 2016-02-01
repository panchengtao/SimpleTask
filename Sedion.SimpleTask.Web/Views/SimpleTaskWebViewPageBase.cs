using Abp.Web.Mvc.Views;

namespace Sedion.SimpleTask.Web.Views
{
    public abstract class SimpleTaskWebViewPageBase : SimpleTaskWebViewPageBase<dynamic>
    {

    }

    public abstract class SimpleTaskWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SimpleTaskWebViewPageBase()
        {
            LocalizationSourceName = SimpleTaskConsts.LocalizationSourceName;
        }
    }
}