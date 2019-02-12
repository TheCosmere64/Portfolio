#region

using System;
using AIMS.ViewModels.CpdViewModels;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Plugin.FilePicker;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.CpdPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CpdAddEventPage : ContentPage
    {
        CpdAddEventViewModel vm;

        public CpdAddEventPage()
        {
            vm = new CpdAddEventViewModel();
            BindingContext = vm;
            vm.DisplayEmptyFieldPrompt += () =>
                DisplayAlert("Error", "Not all fields are filled in.\n* Are required fields.", "OK");
            InitializeComponent();
        }

        public CpdAddEventPage(int key)
        {
            vm = new CpdAddEventViewModel(key);
            BindingContext = vm;
            vm.DisplayEmptyFieldPrompt += () =>
                DisplayAlert("Error", "Not all fields are filled in.\n* Are required fields.", "OK");

            InitializeComponent();
            SubCatagory.IsEnabled = true;
            SubCatagory.SelectedIndex = vm.SubCatagorySelectedIndex;
        }

        void CatagoryChanged(object sender, EventArgs e)
        {
            var catagoryPicker = (Picker) sender;
            int selectedIndex = catagoryPicker.SelectedIndex;

            //If Changed/selected
            if (selectedIndex != -1)
            {
                SubCatagory.IsEnabled = true;
                SubCatagory.ItemsSource = vm.SubCatagories;
                CatagoryDescription.Text = "-";
                EvidenceLable.IsVisible = true;
                DocumentTitleLable.IsVisible = true;
                UploadFileButton.IsVisible = true;
                SuportedLabel.IsVisible = true;

                //Post grad stuidies require proof to be uploaded
                if ((string) catagoryPicker.SelectedItem == "Post Graduate Studies")
                {
                    EvidenceLable.Text = "*Evidence Form";
                }

                //Else allows for later uploading
                else
                {
                    EvidenceLable.Text = "Evidence Form - Can Be Added Later";
                }
            }
        }

        void SubCatagoryChanged(object sender, EventArgs e)
        {
            var subCatagoryPicker = (Picker) sender;
            int selectedIndex = subCatagoryPicker.SelectedIndex;
            if (selectedIndex != -1)
            {
                vm.SubCatagorySelectedIndex = SubCatagory.SelectedIndex;
                CatagoryDescription.Text = vm.SubCatagoryDetails;

                //Can't upload evidence of AIMS video recording so it removes it
                if ((string) subCatagoryPicker.SelectedItem == "AIMS Video Recordings")
                {
                    EvidenceLable.IsVisible = false;
                    DocumentTitleLable.IsVisible = false;
                    UploadFileButton.IsVisible = false;
                    SuportedLabel.IsVisible = false;
                    vm.DocumentUploadText = "No document selected.";
                }
                else
                {
                    EvidenceLable.IsVisible = true;
                    DocumentTitleLable.IsVisible = true;
                    UploadFileButton.IsVisible = true;
                    SuportedLabel.IsVisible = true;
                }
            }
        }

        private void UploadFileButton_Clicked(object sender, EventArgs e)
        {
            var thisActivity = Forms.Context as Activity;
            if (ContextCompat.CheckSelfPermission(thisActivity, Manifest.Permission.ReadExternalStorage) !=
                Permission.Granted)
            {
                //permission denied
                ActivityCompat.RequestPermissions(thisActivity, new String[] {Manifest.Permission.ReadExternalStorage},
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
                //Use data when we have a storage location
                //byte[] data;
                var file = await CrossFilePicker.Current.PickFile();

                if (file == null)
                {
                    return;
                }
                else
                {
                    vm.DocumentUploadText = file.FileName;
                    //data = file.DataArray; //Used when we have a use for it
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}