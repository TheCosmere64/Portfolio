#region

using AIMS.Helpers;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.SettingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPopup : PopupPage
    {
        public SettingsPopup()
        {
            InitializeComponent();
        }

        private async void CloseAllPopup()
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private void Loggout()
        {
            LoggedIn.loggedIn = false;
            Application.Current.MainPage = new LoginPage();
            CloseAllPopup();
        }
    }
}