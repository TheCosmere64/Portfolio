#region

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using System.Xml.Linq;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.HomeViewModel
{
    public class HomePageDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public HomePageDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            News = new ObservableCollection<NewsModel>(db.GetAllNews());
        }

        private ObservableCollection<NewsModel> news;

        public ObservableCollection<NewsModel> News
        {
            get { return news; }
            set
            {
                news = value;
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
            if (News != null)
            {
                News.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/news/rss");
            db.DeleteAllNews();
            foreach (var item in xDoc.Descendants("item"))
            {
                var date = DateTime.ParseExact((string) item.Element("pubDate"),
                    "ddd',' dd MMM yyyy HH:mm:ss K",
                    CultureInfo.InvariantCulture);
                db.InsertNews(new NewsModel()
                {
                    Title = (string) item.Element("title"),
                    Link = (string) item.Element("link"),
                    Description = (string) item.Element("description"),
                    DatePublished = date.ToString("ddd dd MMM yyyy")
                });
            }

            News = new ObservableCollection<NewsModel>(db.GetAllNews());
            IsBusy = false;
        }
    }
}