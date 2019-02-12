#region

using System;
using AIMS.ViewModels.CpdViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.CpdPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CpdViewEventPage : ContentPage
    {
        CpdViewEventViewModel vm;
        static int Key;

        public CpdViewEventPage(int key)
        {
            Key = key;
            vm = new CpdViewEventViewModel(Key);
            BindingContext = vm;
            InitializeComponent();
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CpdAddEventPage(Key)
            {
                Title = "Edit Event"
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadItemsCommand.Execute(null);
        }

        async private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete Activity?", "Would you like to delete this CPD activity?", "Yes",
                "No");
            if (answer)
            {
                vm.DeleteActivityCommand.Execute(null);
            }
        }
    }
}