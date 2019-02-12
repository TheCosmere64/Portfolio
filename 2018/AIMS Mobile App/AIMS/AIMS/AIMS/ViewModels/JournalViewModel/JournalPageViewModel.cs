#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.JournalViewModel
{
    public class JournalPageViewModel : BaseViewModel
    {
        private static int Key;
        private readonly Database db;
        private static JournalModel Journal;

        public JournalPageViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            db = new Database();
            Key = key;
            Journal = db.GetJournal(key);
            Title = Journal.Title;
            Description = Journal.Description;
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

        private string datePublished;

        public string DatePublished {
            get { return datePublished; }
            set {
                datePublished = value;
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
            Journal = db.GetJournal(Key);
            Title = Journal.Title;
            DatePublished = Journal.DatePublished;
            string ParsedDescription = Journal.Description.Replace("src=\"/", "src=\"https://www.aims.org.au/");
            Description = ParsedDescription;
            Link = Journal.Link;
            IsBusy = false;
        }
    }
}