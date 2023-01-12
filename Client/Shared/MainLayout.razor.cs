using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BlazorApp.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        private string collapsed = string.Empty;

        private string _shopName = "SwanShop";

        private string _copyRightDate = $"SwanShop ©2020";

        void SidebarToggleClick()
        {
            if (!String.IsNullOrEmpty(collapsed))
                collapsed = string.Empty;
            else
                collapsed = "collapse";
        }

        protected override async Task OnInitializedAsync()
        {
            _copyRightDate = $"©{DateTime.Now.Year.ToString()} by {_shopName}";
        }
    }
}
