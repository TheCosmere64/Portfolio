#region

using AIMS.ViewModels.ProfileViewModel;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Plugin.FilePicker;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEditPage : ContentPage
    {
        ProfileEditPageViewModel vm;

        public ProfileEditPage(int key)
        {
            vm = new ProfileEditPageViewModel(key);
            BindingContext = vm;
            vm.DisplayEmptyFieldPrompt += () =>
                DisplayAlert("Error", "Not all fields are filled in.\n* Are required fields.", "OK");
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ImagePlaceholder.Source = ImageSource.FromStream(() => new MemoryStream(vm.ProfileImage));
        }

        private void UploadFileButton_Clicked(object sender, EventArgs e)
        {
            var thisActivity = Forms.Context as Activity;
            if (ContextCompat.CheckSelfPermission(thisActivity, Manifest.Permission.ReadExternalStorage) !=
                Permission.Granted)
            {
                //permission denied
                ActivityCompat.RequestPermissions(thisActivity, new String[] { Manifest.Permission.ReadExternalStorage },
                    1);
            }
            else
            {
                FilePickerWindow();
            }
        }

        public void OnRequestPermissionsResult(int requestCode, string[] permissions,
    [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == 1)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    //permission has been granted by the user
                    FilePickerWindow();
                }
                else
                {
                    //permission denied
                }
            }
        }

        private async void FilePickerWindow()
        {
            try
            {
                string[] supportedFiles = new string[] { ".png", ".jpg" };
                var file = await CrossFilePicker.Current.PickFile(supportedFiles);
                if (file != null)
                {
                    if(file.FileName.EndsWith("jpg", StringComparison.Ordinal) || file.FileName.EndsWith("png", StringComparison.Ordinal))
                    {
                        vm.ProfileImageText = file.FileName;
                        vm.ProfileImage = file.DataArray;
                        ImagePlaceholder.Source = ImageSource.FromStream(() => new MemoryStream(vm.ProfileImage));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Incorrect Image Format, .png or .jpg only.", "OK");
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}