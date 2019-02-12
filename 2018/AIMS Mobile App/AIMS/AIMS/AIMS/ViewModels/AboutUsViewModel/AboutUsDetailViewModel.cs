#region

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Linq;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.AboutUsViewModel
{
    public class AboutUsDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public AboutUsDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            AboutUs = new ObservableCollection<AboutUsModel>(db.GetAllAboutUs());
        }

        private ObservableCollection<AboutUsModel> aboutUs;

        public ObservableCollection<AboutUsModel> AboutUs
        {
            get { return aboutUs; }
            set
            {
                aboutUs = value;
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
            if (AboutUs != null)
            {
                AboutUs.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/about/rss");
            db.DeleteAllAboutUs();

            int tempId = 0;

            foreach (var item in xDoc.Descendants("item"))
            {
                switch ((string) item.Element("title"))
                {
                    case "AIMS":
                        tempId = 0;
                        goto case "Done";

                    case "Advocacy":
                        tempId = 1;
                        goto case "Done";

                    case "Governance":
                        tempId = 2;
                        goto case "Done";

                    case "State Branches and Divisions":
                        tempId = 3;
                        goto case "Done";

                    case "Constitution & By-Laws":
                        tempId = 4;
                        goto case "Done";

                    case "AIMS Strategic Plan 2016-19":
                        tempId = 5;
                        goto case "Done";

                    case "About Medical Science":
                        tempId = 6;
                        goto case "Done";

                    case "Saal / Foley Lectures":
                        tempId = 7;
                        goto case "Done";

                    case "Frequently Asked Questions":
                        tempId = 8;
                        goto case "Done";

                    case "Done":
                        db.InsertOrUpdateAboutUs(new AboutUsModel()
                        {
                            Id = tempId,
                            Title = (string) item.Element("title"),
                            Link = (string) item.Element("link"),
                            Description = (string) item.Element("description")
                        });
                        break;

                    default:
                        break;
                }
            }

            AboutUs = new ObservableCollection<AboutUsModel>(db.GetAllAboutUs());
            IsBusy = false;
        }
    }
}