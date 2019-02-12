#region

using AIMS.Core.Database;
using AIMS.Core.Models;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;
using HtmlAgilityPack;

#endregion

namespace AIMS.ViewModels.CareerViewModel
{
    public class CareerDetailViewModel : BaseViewModel
    {
        Database db;
        public CareerDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadItems);
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

        private void ExecuteLoadItems()
        {
            Description = db.GetCareer(0).Description;
            Link = db.GetCareer(0).Link;
        }

        public void PopulateDatabase()
        {
            db.InsertOrUpdateCareer(new CareerModel()
            {
                Id = 0,
                Description = ScrapeWebsite(),
                Link = "https://www.aims.org.au/job-base"
            });
        }

        private string ScrapeWebsite()
        {
            var doc = new HtmlWeb();
            var text = doc.Load("https://www.aims.org.au/job-base");
            HtmlNode search = text.DocumentNode.SelectSingleNode("//*[@id='mainBar']");
            string scrape = search.InnerHtml;
            //string[] stringSeparators = new string[] { ">", "</a>" };
            //string[] list = scrape.Split(stringSeparators, StringSplitOptions.None);
            return scrape;
        }
    }
}