using System;
using Abp.Application.Navigation;
using Abp.Localization;

namespace Sedion.SimpleTask.Web.Navigation
{
    public class FrontEndNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Frontend";

        public override void SetNavigation(INavigationProviderContext context)
        {
            /* 设置菜单 */
            var frontEndMenu = new MenuDefinition(MenuName, new FixedLocalizableString("Frontend menu"));
            context.Manager.Menus[MenuName] = frontEndMenu;

            frontEndMenu
                .AddItem(new MenuItemDefinition(
                    PageNames.Frontend.Home, //首页
                    L("HomePages"),
                    url: ""
                    ))
                .AddItem(new MenuItemDefinition(
                    PageNames.Frontend.About, //关于我们
                    L("AboutUs"),
                    url: "About"
                    ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SimpleTaskConsts.LocalizationSourceName);
        }
    }
}