#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.AboutUsViewModel
{
    public class AboutUsPageViewModel : BaseViewModel
    {
        private static int Key;
        private readonly Database db;
        private static AboutUsModel AboutUs;

        public AboutUsPageViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            db = new Database();
            Key = key;
            ExecuteLoadNewsCommand();
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set
            {
                link = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadItemsCommand { get; set; }

        public void ExecuteLoadNewsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            AboutUs = db.GetAboutUs(Key);
            Title = AboutUs.Title;
            string ParsedDescription = AboutUs.Description.Replace("src=\"/", "src=\"https://www.aims.org.au/");
            Description = ParsedDescription;
            Link = AboutUs.Link;
            IsBusy = false;
        }
    }
}