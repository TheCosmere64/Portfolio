#region

using System;
using System.IO;
using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using AIMS.Helpers;
using AIMS.Views;
using AIMS.Views.MasterDetailPages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

#endregion

namespace AIMS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly Database db;
        public Action DisplayInvalidLoginPrompt;

        public LoginViewModel()
        {
            LoginCommand = new Command(CheckLogin);
            NewUserCommand = new Command(NewUser);
            DeleteAllUsersCommand = new Command(DeleteUser);
            GuestLoginCommand = new Command(GuestLogin);
            LoggingIn = false;
            NotLoggingIn = true;
            db = new Database();
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private bool loggingIn;

        public bool LoggingIn {
            get { return loggingIn; }
            set {
                loggingIn = value;
                OnPropertyChanged();
            }
        }

        private bool notLoggingIn;

        public bool NotLoggingIn {
            get { return notLoggingIn; }
            set {
                notLoggingIn = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { protected set; get; }

        public async void CheckLogin()
        {
            IsBusy = true;

            if (db.CheckUserExists(email, password))
            {

                LoggedIn.loggedIn = true;
                PopulateApp populate = new PopulateApp();
                NotLoggingIn = false;
                LoggingIn = true;
                await Task.WhenAll(populate.Execute());
                LoggingIn = false;
                NotLoggingIn = true;
                Application.Current.MainPage = new HomePage(); 
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }

            IsBusy = false;
        }

        public ICommand GuestLoginCommand { protected set; get; }
        private async void GuestLogin()
        {
            PopulateApp populate = new PopulateApp();
            LoggingIn = true;
            NotLoggingIn = false;
            await Task.WhenAll(populate.Execute());
            LoggingIn = false;
            NotLoggingIn = true;
            Application.Current.MainPage = new HomePage();
        }

        public ICommand NewUserCommand { protected set; get; }
        public void NewUser()
        {
            //Byte array for the image
            db.InsertUser(new UserModel()
            {
                Email = email,
                Password = password,
                ProfileImage = ProfileImageByteArray.imgdata
            });
            Email = string.Empty;
            Password = string.Empty;
        }


        public ICommand DeleteAllUsersCommand { protected set; get; }
        public void DeleteUser()
        {
            db.DeleteAllUsers();
        }
    }
}