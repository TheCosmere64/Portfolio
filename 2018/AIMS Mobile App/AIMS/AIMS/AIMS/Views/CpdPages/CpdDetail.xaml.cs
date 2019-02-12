#region

using System;
using AIMS.Core.Models;
using AIMS.Interfaces;
using AIMS.ViewModels.CpdViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

//using HtmlAgilityPack;

namespace AIMS.Views.CpdPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CpdDetail : ContentPage
    {
        CpdDetailViewModel vm;

        public CpdDetail()
        {
            vm = new CpdDetailViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadItemsCommand.Execute(null);
        }

        void AddEventPage()
        {
            Navigation.PushAsync(new CpdAddEventPage());
        }

        /// <summary>
        /// Opens up a new page with all the details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ActivityModel item = (ActivityModel) e.SelectedItem;

            if (item == null)
            {
                return;
            }

            Navigation.PushAsync(new CpdViewEventPage(item.Id));
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