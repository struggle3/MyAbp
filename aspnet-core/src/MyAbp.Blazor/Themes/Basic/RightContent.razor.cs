using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Volo.Abp.Users;
using Volo.Abp.MultiTenancy;
using AntDesign;
using System;
using Volo.Abp.UI.Navigation;
using Microsoft.Extensions.Options;
using Volo.Abp.Http.Client;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Volo.Abp.Localization;
using System.Globalization;
using System.Collections.Immutable;

namespace MyAbp.Blazor.Themes.Basic
{
    public partial class RightContent
    {
        [Inject] protected ICurrentUser CurrentUser { get; set; }
        [Inject] protected ICurrentTenant CurrentTenant { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected SignOutSessionStateManager SignOutManager { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject]protected IMenuManager MenuManager { get; set; }
        [Inject]protected IOptions<AbpRemoteServiceOptions> RemoteServiceOptions { get; set; }
        [Inject] protected ILanguageProvider LanguageProvider { get; set; }
        [Inject] protected IJSRuntime JsRuntime { get; set; }
        protected ApplicationMenu Menu { get; set; }
        protected string ServerUrl { get; set; }
        protected string ServerAccountUrl { get; set; }
        private IReadOnlyList<LanguageInfo> _otherLanguages;
        private LanguageInfo _currentLanguage;

        protected override async Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);

            ServerUrl = RemoteServiceOptions.Value.RemoteServices.Default?.BaseUrl?.TrimEnd('/');
            ServerAccountUrl = ServerUrl + "/Account/Manage?returnUrl=" + Navigation.Uri;

            Navigation.LocationChanged += OnLocationChanged;

            var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
            "localStorage.getItem",
            "Abp.SelectedLanguage"
            );

            _otherLanguages = await LanguageProvider.GetLanguagesAsync();

            if (!_otherLanguages.Any())
            {
                return;
            }

            if (!selectedLanguageName.IsNullOrWhiteSpace())
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == selectedLanguageName);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == CultureInfo.CurrentUICulture.Name);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault();
            }

            _otherLanguages = _otherLanguages.Where(l => l != _currentLanguage).ToImmutableList();
        }

        protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            ServerAccountUrl = ServerUrl + "/Account/Manage?returnUrl=" + Navigation.Uri;
            StateHasChanged();
        }

        private async Task ChangeLanguageAsync(LanguageInfo language)
        {
            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage", language.UiCultureName
                );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        public void Dispose()
        {
            Navigation.LocationChanged -= OnLocationChanged;
        }

        private void NavigateTo(string uri)
        {
            Navigation.NavigateTo(uri);
        }

        private async Task BeginSignOut()
        {
            await SignOutManager.SetSignOutState();
            NavigateTo("authentication/logout");
        }

        private void Login()
        {
            NavigateTo("authentication/login");
        }
    }
}
