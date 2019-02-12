#region

using System;
using AIMS.Core.Models;
using AIMS.Interfaces;
using AIMS.ViewModels.MemberViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.MembershipPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembershipDetail : ContentPage
    {
        public MembershipDetail()
        {
            var vm = new MemberDetailViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MembershipModel item = (MembershipModel) e.SelectedItem;

            if (item == null)
            {
                return;
            }

            Navigation.PushAsync(new MembershipPage(item.Id));
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