#region

using System;
using AIMS.Helpers;
using AIMS.Interfaces;
using AIMS.ViewModels;
using AIMS.Views.MasterDetailPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            {
                var vm = new LoginViewModel();
                BindingContext = vm;
                vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
                InitializeComponent();

                //AIMSLogo.Source = "AIMSLogo_NoText_HighRes.png";

                Email.Completed += (object sender, EventArgs e) => { Password.Focus(); };

                Password.Completed += (object sender, EventArgs e) => { vm.LoginCommand.Execute(null); };
            }
        }

        private long lastPress;

        //Makes sure the back button on Android cannot be accidentally pressed to exit
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

        private void OpenAccountRegister()
        {
            var uri = new Uri("https://www.aims.org.au/membershipinformation/join");

            Device.OpenUri(uri);
        }
    }
}