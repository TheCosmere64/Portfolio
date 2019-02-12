#region

using System;
using AIMS.Interfaces;
using AIMS.ViewModels.ProfileViewModel;
using AIMS.Core.ValueConverters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

#endregion

namespace AIMS.Views.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetail : ContentPage
    {
        ProfileDetailViewModel vm;

        public ProfileDetail()
        {
            vm = new ProfileDetailViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadItemsCommand.Execute(null);
            ImagePlaceholder.Source = ImageSource.FromStream(() => new MemoryStream(vm.ProfileImage));
        }

        private void EditProfileButton(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ProfileEditPage(vm.Id));
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