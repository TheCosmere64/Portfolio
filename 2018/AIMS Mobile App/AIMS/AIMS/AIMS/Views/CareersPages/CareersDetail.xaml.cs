#region

using System;
using System.Text.RegularExpressions;
using AIMS.Interfaces;
using AIMS.ViewModels.CareerViewModel;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.CareersPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CareersDetail : ContentPage
    {
        CareerDetailViewModel vm;

        public CareersDetail()
        {
            vm = new CareerDetailViewModel();
            BindingContext = vm;
            InitializeComponent();

            webView.Navigating += (s, e) =>
            {
                if (e.Url.StartsWith("file:"))
                {
                    try
                    {
                        Regex ex = new Regex(@"\/[a-z0-9]+");
                        var result = Regex.Matches(e.Url, @"(\/[a-z0-9]+)");
                        string extractedText = "";
                        foreach (var item in result)
                        {
                            extractedText += item.ToString();
                        }


                        var uri = new Uri("https://www.aims.org.au" + extractedText);

                        Device.OpenUri(uri);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("myapp", ex.ToString());
                    }
                }
                else if (e.Url.StartsWith("mailto:"))
                {
                    try
                    {
                        var uri = new Uri(e.Url);
                        Device.OpenUri(uri);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("myapp", ex.ToString());
                    }
                }
                else if (e.Url.StartsWith("http"))
                {
                    try
                    {
                        var uri = new Uri(e.Url);
                        Device.OpenUri(uri);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("myapp", ex.ToString());
                    }
                }

                e.Cancel = true;
            };
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadItemsCommand.Execute(null);
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

        public void openBrowserPage()
        {
            Uri uri = new Uri(vm.Link);
            Device.OpenUri(uri);
        }
    }
}