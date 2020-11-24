using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.DependencyInjection;

namespace MyAbp.Blazor.Pages
{
    [Dependency(ReplaceServices = true)]
    public class AntDesignMessageService : IUiMessageService, IScopedDependency
    {
        /// <summary>
        /// An event raised after the message is received. Used to notify the message dialog.
        /// </summary>
        public event EventHandler<UiMessageEventArgs> MessageReceived;

        private readonly IStringLocalizer<AbpUiResource> localizer;

        public ILogger<AntDesignMessageService> Logger { get; set; }

        public AntDesignMessageService(
            IStringLocalizer<AbpUiResource> localizer)
        {
            this.localizer = localizer;

            Logger = NullLogger<AntDesignMessageService>.Instance;
        }

        public Task InfoAsync(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);

            MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Info, message, title, uiMessageOptions));

            return Task.CompletedTask;
        }

        public Task SuccessAsync(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);

            MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Success, message, title, uiMessageOptions));

            return Task.CompletedTask;
        }

        public Task WarnAsync(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);

            MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Warning, message, title, uiMessageOptions));

            return Task.CompletedTask;
        }

        public Task ErrorAsync(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);

            MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Error, message, title, uiMessageOptions));

            return Task.CompletedTask;
        }

        public Task<bool> ConfirmAsync(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);

            var callback = new TaskCompletionSource<bool>();

            MessageReceived?.Invoke(this, new UiMessageEventArgs(UiMessageType.Confirmation, message, title, uiMessageOptions, callback));

            return callback.Task;
        }

        protected virtual UiMessageOptions CreateDefaultOptions()
        {
            return new UiMessageOptions
            {
                CenterMessage = true,
                ShowMessageIcon = true,
                OkButtonText = localizer["Ok"],
                CancelButtonText = localizer["Cancel"],
                ConfirmButtonText = localizer["Yes"],
            };
        }
    }
}
