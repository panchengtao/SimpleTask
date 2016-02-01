using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Auditing;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Threading;
using Sedion.SimpleTask.Sessions;
using Sedion.SimpleTask.Web.Models.Layout;
using Sedion.SimpleTask.Web.Navigation;

namespace Sedion.SimpleTask.Web.Controllers
{
    public class LayoutController : SimpleTaskControllerBase
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ISessionAppService _sessionAppService;
        private readonly IUserNavigationManager _userNavigationManager;

        public LayoutController(
            IUserNavigationManager userNavigationManager,
            ILocalizationManager localizationManager,
            ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }


        [HttpGet]
        [ChildActionOnly]
        [DisableAuditing]
        public async Task<ActionResult> Header(string currentPageName = "")
        {
            var headerModel = new HeaderViewModel();

            if (AbpSession.UserId.HasValue)
            {
                headerModel.LoginInformations = await _sessionAppService.GetCurrentLoginInformations();
            }

            headerModel.CurrentPageName = currentPageName;

            headerModel.Languages = LocalizationManager.GetAllLanguages();
            headerModel.CurrentLanguage = LocalizationManager.CurrentLanguage;
            headerModel.Menu =
                await _userNavigationManager.GetMenuAsync(FrontEndNavigationProvider.MenuName, AbpSession.UserId);

            headerModel.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return PartialView("~/Views/Layout/_Header.cshtml", headerModel);
        }

        [ChildActionOnly]
        public async Task<PartialViewResult> TopMenu(string activeMenu = "")
        {
            var model = new TopMenuViewModel
            {
                MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId),
                ActiveMenuItemName = activeMenu
            };

            return PartialView("_TopMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _localizationManager.CurrentLanguage,
                Languages = _localizationManager.GetAllLanguages()
            };

            return PartialView("_LanguageSelection", model);
        }


        [ChildActionOnly]
        public PartialViewResult UserMenuOrLoginLink()
        {
            UserMenuOrLoginLinkViewModel model;

            if (AbpSession.UserId.HasValue)
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations()),
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                };
            }
            else
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                };
            }

            return PartialView("_UserMenuOrLoginLink", model);
        }
    }
}