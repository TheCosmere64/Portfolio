#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.HomeViewModel
{
    public class NewsPageViewModel : BaseViewModel
    {
        private static int Key;
        private readonly Database db;
        private static NewsModel News;

        public NewsPageViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            db = new Database();
            Key = key;
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

        private string datePublished;

        public string DatePublished
        {
            get { return datePublished; }
            set
            {
                datePublished = value;
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

        public ICommand LoadItemsCommand { get; set; }

        public void ExecuteLoadNewsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            News = db.GetNews(Key);
            Title = News.Title;
            DatePublished = News.DatePublished;
            string ParsedDescription = News.Description.Replace("src=\"/", "src=\"https://www.aims.org.au/");
            Description = ParsedDescription;
            IsBusy = false;
        }
    }
}