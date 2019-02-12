#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.EventViewModel
{
    public class EventPageViewModel : BaseViewModel
    {
        private static int Key;
        private readonly Database db;
        private static EventModel Event;

        public EventPageViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            db = new Database();
            Key = key;
            Event = db.GetEvent(Key);
            Title = Event.Title;
            DatePublished = Event.DatePublished;
            Description = Event.Description;
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
            Event = db.GetEvent(Key);
            Title = Event.Title;
            DatePublished = Event.DatePublished;
            string ParsedDescription = Event.Description.Replace("src=\"/", "src=\"https://www.aims.org.au/");
            Description = ParsedDescription;
            IsBusy = false;
        }
    }
}