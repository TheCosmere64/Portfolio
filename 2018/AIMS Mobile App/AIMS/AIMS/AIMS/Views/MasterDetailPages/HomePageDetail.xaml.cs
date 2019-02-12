#region

using System;
using AIMS.Core.Models;
using AIMS.Interfaces;
using AIMS.ViewModels.HomeViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        public HomePageDetail()
        {
            var vm = new HomePageDetailViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        long lastPress;

        //Makes sure the back button on Android cannot be accidently pressed to exit
        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

                if (currentTime - lastPress > 2000)
                {
                    DependencyService.Get<IAndroidMethods>().ShowToast("Press back again to exit");
                    lastPress = currentTime;
                    return true;
                }
            }

            return false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NewsModel item = (NewsModel) e.SelectedItem;

            if (item == null)
            {
                return;
            }

            Navigation.PushAsync(new NewsPage(item.Id));
            ((ListView) sender).SelectedItem = null;
        }
    }
}