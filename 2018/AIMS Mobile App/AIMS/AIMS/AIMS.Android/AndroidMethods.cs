#region

using AIMS.Droid;
using AIMS.Interfaces;
using Android.Widget;

#endregion

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]

namespace AIMS.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        public void ShowToast(string content)
        {
            Toast.MakeText(Android.App.Application.Context, "Press back again to exit", ToastLength.Short).Show();
        }
    }
}