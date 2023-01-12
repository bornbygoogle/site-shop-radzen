using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System;

namespace BlazorApp.Client.Pages
{
    public partial class Index
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

        private Random _randNum;
        private List<string> _banners;
        private List<string> products;


        private System.Threading.Timer _timerBanner;

        private string _currentImageBanner = @"https://res.cloudinary.com/dob8evuxv/image/upload/v1673197774/banner_1_ntcsoq.png";

        protected override async Task OnInitializedAsync()
        {
            if (_randNum == null)
                _randNum = new Random();

            if (_banners == null)
                _banners = new List<string>();               

            _banners.Add("https://res.cloudinary.com/dob8evuxv/image/upload/v1673197774/banner_1_ntcsoq.png");
            _banners.Add("https://res.cloudinary.com/dob8evuxv/image/upload/v1673197768/banner_2_gi4ram.png");
            _banners.Add("https://res.cloudinary.com/dob8evuxv/image/upload/v1673197775/banner_3_mansxe.png");
            _banners.Add("https://res.cloudinary.com/dob8evuxv/image/upload/v1673197778/banner_4_bppf1p.png");

            if (products == null)
                products = new List<string>();

            products.Add("test");
            products.Add("test0");
            products.Add("test1");

            if (_timerBanner == null)
                _timerBanner = new System.Threading.Timer(async _ =>  // async void
                {
                    _currentImageBanner = await GetImageBanner();
                    // we need StateHasChanged() because this is an async void handler
                    // we need to Invoke it because we could be on the wrong Thread          
                    await InvokeAsync(StateHasChanged);
                }, null, 0, 3000);
        }

        public void Dispose()
        {
            _timerBanner?.Dispose();
        }

        private async Task<string> GetImageBanner()
        {
            if (_randNum != null && _banners != null && _banners.Count > 0)
            {
                int aRandomPos = _randNum.Next(_banners.Count);//Returns a nonnegative random number less than the specified maximum

                return _banners[aRandomPos];
            }
            else
                return string.Empty;
        }
    }
}
