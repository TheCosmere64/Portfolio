#region

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using System.Xml.Linq;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;
//using HtmlAgilityPack;

#endregion

namespace AIMS.ViewModels.EventViewModel
{
    public class EventDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public EventDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            Events = new ObservableCollection<EventModel>(db.GetAllEvents());
        }

        private ObservableCollection<EventModel> events;

        public ObservableCollection<EventModel> Events
        {
            get { return events; }
            set
            {
                events = value;
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
            if (Events != null)
            {
                Events.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/events/rss");
            db.DeleteAllEvents();
            foreach (var item in xDoc.Descendants("item"))
            {
                var date = DateTime.ParseExact((string) item.Element("pubDate"),
                    "ddd',' dd MMM yyyy HH:mm:ss K",
                    CultureInfo.InvariantCulture);
                db.InsertEvent(new EventModel()
                {
                    Title = (string) item.Element("title"),
                    Link = (string) item.Element("link"),
                    Description = (string) item.Element("description"),
                    DatePublished = date.ToString("ddd dd MMM yyyy")
                });
            }

            Events = new ObservableCollection<EventModel>(db.GetAllEvents());
            IsBusy = false;
        }
    }
}