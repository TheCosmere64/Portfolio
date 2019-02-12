#region

using System;
using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.CpdViewModels
{
    public class CpdViewEventViewModel : BaseViewModel, IViewModel
    {
        private readonly Database db;
        private static int Key;
        private static ActivityModel Activity;

        public CpdViewEventViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadActivityCommand);

            Key = key;
            DeleteActivityCommand = new Command(DeleteActivity);
            db = new Database();
            Activity = db.GetActivity(Key);
            Catagory = Activity.Catagory;
            SubCatagory = Activity.SubCatagory;
            ShortDescription = Activity.ShortDescription;
            DateCompleted = Activity.DateCompleted;
            FurtherDetails = Activity.FurtherDetails;
            Quantity = Activity.Quantity;
            LongDescription = Activity.LongDescription;
            NumPoints = Activity.NumPoints;
            if (Activity.SupportingDocument == null)
            {
                DocumentUploadText = "No document selected.";
            }
            else
            {
                DocumentUploadText = Activity.SupportingDocument;
            }
        }

        private string catagory;

        public string Catagory
        {
            get { return catagory; }
            set
            {
                catagory = value;
                OnPropertyChanged();
            }
        }

        private string subCatagory;

        public string SubCatagory
        {
            get { return subCatagory; }
            set
            {
                subCatagory = value;
                OnPropertyChanged();
            }
        }

        private string shortDescription;

        public string ShortDescription
        {
            get { return shortDescription; }
            set
            {
                shortDescription = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateCompleted;

        public DateTime DateCompleted
        {
            get { return dateCompleted; }
            set
            {
                dateCompleted = value;
                OnPropertyChanged();
            }
        }

        private string furtherDetails;

        public string FurtherDetails
        {
            get { return furtherDetails; }
            set
            {
                furtherDetails = value;
                OnPropertyChanged();
            }
        }

        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        private string longDescription;

        public string LongDescription
        {
            get { return longDescription; }
            set
            {
                longDescription = value;
                OnPropertyChanged();
            }
        }

        private string documentUploadText;

        public string DocumentUploadText
        {
            get { return documentUploadText; }
            set
            {
                documentUploadText = value;
                OnPropertyChanged();
            }
        }

        private double numPoints;

        public double NumPoints
        {
            get { return numPoints; }
            set
            {
                numPoints = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteActivityCommand { protected set; get; }

        private void DeleteActivity()
        {
            db.DeleteActivity(Key);
            NavigationService.Instance.PopAsync();
        }


        public ICommand LoadItemsCommand { get; set; }

        public void ExecuteLoadActivityCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            Activity = db.GetActivity(Key);
            Catagory = Activity.Catagory;
            SubCatagory = Activity.SubCatagory;
            ShortDescription = Activity.ShortDescription;
            DateCompleted = Activity.DateCompleted;
            FurtherDetails = Activity.FurtherDetails;
            Quantity = Activity.Quantity;
            LongDescription = Activity.LongDescription;
            DocumentUploadText = Activity.SupportingDocument;
            NumPoints = Activity.NumPoints;
            IsBusy = false;
        }
    }
}