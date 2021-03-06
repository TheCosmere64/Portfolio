﻿#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.ProfileViewModel
{
    public class ProfileDetailViewModel : BaseViewModel
    {
        private readonly Database db;
        private UserModel userModel;

        public ProfileDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadUsersCommand);
        }

        public ICommand LoadItemsCommand { get; set; }

        private void ExecuteLoadUsersCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            userModel = db.GetUserByKey((int) db.GetCurrentUserId());
            Id = userModel.Id;
            Email = userModel.Email;
            FirstName = userModel.FirstName;
            ProfileImage = userModel.ProfileImage;
            LastName = userModel.LastName;
            PostalAddress1 = userModel.PostalAddress1;
            PostalAddress2 = userModel.PostalAddress2;
            PostalAddress3 = userModel.PostalAddress3;
            PostalCity = userModel.PostalCity;
            PostalState = userModel.PostalState;
            PostalPostcode = userModel.PostalPostcode;
            PostalCountry = userModel.PostalCountry;
            CompanyName = userModel.CompanyName;
            PositionTitle = userModel.PositionTitle;
            WorkAddress1 = userModel.WorkAddress1;
            WorkAddress2 = userModel.WorkAddress2;
            WorkAddress3 = userModel.WorkAddress3;
            WorkCity = userModel.WorkCity;
            WorkState = userModel.WorkState;
            WorkPostcode = userModel.WorkPostcode;
            WorkCountry = userModel.WorkCountry;
            HomePhone = userModel.HomePhone;
            WorkPhone = userModel.WorkPhone;
            Mobile = userModel.Mobile;
            IsBusy = false;
        }

        #region variable definitions

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private byte[] profileImage;

        public byte[] ProfileImage {
            get { return profileImage; }
            set 
            {
                profileImage = value;
                OnPropertyChanged();
            }
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

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        private string postalAddress1;

        public string PostalAddress1
        {
            get { return postalAddress1; }
            set
            {
                postalAddress1 = value;
                OnPropertyChanged();
            }
        }

        private string postalAddress2;

        public string PostalAddress2
        {
            get { return postalAddress2; }
            set
            {
                postalAddress2 = value;
                OnPropertyChanged();
            }
        }

        private string postalAddress3;

        public string PostalAddress3
        {
            get { return postalAddress3; }
            set
            {
                postalAddress3 = value;
                OnPropertyChanged();
            }
        }

        private string postalCity;

        public string PostalCity
        {
            get { return postalCity; }
            set
            {
                postalCity = value;
                OnPropertyChanged();
            }
        }

        private string postalState;

        public string PostalState
        {
            get { return postalState; }
            set
            {
                postalState = value;
                OnPropertyChanged();
            }
        }

        private string postalPostcode;

        public string PostalPostcode
        {
            get { return postalPostcode; }
            set
            {
                postalPostcode = value;
                OnPropertyChanged();
            }
        }

        private string postalCountry;

        public string PostalCountry
        {
            get { return postalCountry; }
            set
            {
                postalCountry = value;
                OnPropertyChanged();
            }
        }

        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged();
            }
        }

        private string positionTitle;

        public string PositionTitle
        {
            get { return positionTitle; }
            set
            {
                positionTitle = value;
                OnPropertyChanged();
            }
        }

        private string workAddress1;

        public string WorkAddress1
        {
            get { return workAddress1; }
            set
            {
                workAddress1 = value;
                OnPropertyChanged();
            }
        }

        private string workAddress2;

        public string WorkAddress2
        {
            get { return workAddress2; }
            set
            {
                workAddress2 = value;
                OnPropertyChanged();
            }
        }

        private string workAddress3;

        public string WorkAddress3
        {
            get { return workAddress3; }
            set
            {
                workAddress3 = value;
                OnPropertyChanged();
            }
        }

        private string workCity;

        public string WorkCity
        {
            get { return workCity; }
            set
            {
                workCity = value;
                OnPropertyChanged();
            }
        }

        private string workState;

        public string WorkState
        {
            get { return workState; }
            set
            {
                workState = value;
                OnPropertyChanged();
            }
        }

        private string workPostcode;

        public string WorkPostcode
        {
            get { return workPostcode; }
            set
            {
                workPostcode = value;
                OnPropertyChanged();
            }
        }

        private string workCountry;

        public string WorkCountry
        {
            get { return workCountry; }
            set
            {
                workCountry = value;
                OnPropertyChanged();
            }
        }

        private string homePhone;

        public string HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                OnPropertyChanged();
            }
        }

        private string workPhone;

        public string WorkPhone
        {
            get { return workPhone; }
            set
            {
                workPhone = value;
                OnPropertyChanged();
            }
        }

        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}