using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BlazorApp.Client.Pages
{
    public partial class ShopItemImageContentPage
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

        [Parameter] public int ImageId { get; set; }

        private string StringImageId;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            switch (ImageId)
            {
                case 0:
                    StringImageId = @"\images\item-2.png";
                    break;
                case 1:
                    StringImageId = @"\images\item-3.png";
                    break;
                default:
                    StringImageId = @"\images\item-19.png";
                    break;
            }


            //order = dbContext.Orders.Where(o => o.OrderID == OrderID)
            //                .Include("Customer")
            //                .Include("Employee").FirstOrDefault();

            //orderDetails = dbContext.OrderDetails.Include("Order").ToList();
        }
    }
}
