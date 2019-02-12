#region

using System;
using AIMS.Core.Models;
using AIMS.Interfaces;
using AIMS.ViewModels.EventViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.EventPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetail : ContentPage
    {
        public EventDetail()
        {
            var vm = new EventDetailViewModel();
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
            EventModel item = (EventModel) e.SelectedItem;

            if (item == null)
            {
                return;
            }

            Navigation.PushAsync(new EventPage(item.Id));
            ((ListView) sender).SelectedItem = null;
        }
    }
}