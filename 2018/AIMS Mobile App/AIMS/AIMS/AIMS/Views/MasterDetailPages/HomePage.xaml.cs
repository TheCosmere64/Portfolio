#region

using System;
using AIMS.Core.Models;
using AIMS.Views.SettingPages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HomePageMenuItem item = (HomePageMenuItem) e.SelectedItem;
            if (item == null)
                return;

            var page = (Page) Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private void OpenSettingsPopup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new SettingsPopup());
        }
    }
}