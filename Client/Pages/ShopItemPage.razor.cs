using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BlazorApp.Client.Pages
{
    public partial class ShopItemPage
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

        [Parameter] public int OrderID { get; set; }

        private string _imgItemPrincipal = @"\images\item-19.png";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _imgItemPrincipal = @"\images\item-19.png";
        }

        public async void OpenPrincipalImage()
        {
            await DialogService.OpenAsync<ShopItemImageContentPage>(string.Empty,
                                                                    new Dictionary<string, object>() { { "ImageId", 1 } },
                                                                    new DialogOptions() { Resizable = true, Draggable = true });
        }

        private async void ChangeImagePrincipal(string image)
        {
            _imgItemPrincipal = image;
        }
    }
}
