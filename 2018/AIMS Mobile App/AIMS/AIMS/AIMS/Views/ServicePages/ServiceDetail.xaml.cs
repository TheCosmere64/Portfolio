#region

using System;
using AIMS.Core.Models;
using AIMS.Interfaces;
using AIMS.ViewModels.ServiceViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.ServicePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceDetail : ContentPage
    {
        public ServiceDetail()
        {
            var vm = new ServiceDetailViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceModel item = (ServiceModel) e.SelectedItem;

            if (item == null)
            {
                return;
            }

            Navigation.PushAsync(new ServicePage(item.Id));
            ((ListView) sender).SelectedItem = null;
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
    }
}