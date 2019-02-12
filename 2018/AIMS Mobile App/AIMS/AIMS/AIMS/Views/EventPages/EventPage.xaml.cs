#region

using System;
using System.Text.RegularExpressions;
using AIMS.ViewModels.EventViewModel;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.EventPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        EventPageViewModel vm;

        public EventPage(int id)
        {
            vm = new EventPageViewModel(id);
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
    }
}