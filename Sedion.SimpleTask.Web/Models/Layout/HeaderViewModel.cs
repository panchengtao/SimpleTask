using System.Collections.Generic;
using Abp.Application.Navigation;
using Abp.Localization;
using Sedion.SimpleTask.Sessions.Dto;

namespace Sedion.SimpleTask.Web.Models.Layout
{
    /// <summary>
    ///     头部展示类
    /// </summary>
    public class HeaderViewModel
    {
        /// <summary>
        ///     登录信息
        /// </summary>
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        /// <summary>
        ///     语言选项
        /// </summary>
        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        /// <summary>
        ///     当前语言
        /// </summary>
        public LanguageInfo CurrentLanguage { get; set; }

        /// <summary>
        ///     用户菜单
        /// </summary>
        public UserMenu Menu { get; set; }

        /// <summary>
        ///     当前界面名称
        /// </summary>
        public string CurrentPageName { get; set; }

        /// <summary>
        ///     是否开启多租户
        /// </summary>
        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            if (!IsMultiTenancyEnabled)
            {
                return LoginInformations.User.UserName;
            }

            return LoginInformations.Tenant == null
                ? ".\\" + (LoginInformations.User.UserName ?? "无")
                : LoginInformations.Tenant.TenancyName + "\\" + LoginInformations.User.UserName;
        }
    }
}