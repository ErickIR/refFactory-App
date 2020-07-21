using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CitizenApp.Services.Interfaces;

namespace CitizenApp.Services.Services
{
    public class MasterDetailPageService : IPageService
    {
        private MasterDetailPage MainPage
        {
            get
            {
                return Application.Current.MainPage as MasterDetailPage;
            }
        }
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.Detail.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.Detail.DisplayAlert(title, message, ok);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Detail.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Detail.Navigation.PushAsync(page);
        }
    }
}
