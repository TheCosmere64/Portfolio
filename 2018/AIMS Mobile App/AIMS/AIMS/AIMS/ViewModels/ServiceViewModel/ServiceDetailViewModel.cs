#region

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Linq;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.ServiceViewModel
{
    public class ServiceDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public ServiceDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            Services = new ObservableCollection<ServiceModel>(db.GetAllServices());
        }

        private ObservableCollection<ServiceModel> services;

        public ObservableCollection<ServiceModel> Services
        {
            get { return services; }
            set
            {
                services = value;
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
            if (Services != null)
            {
                Services.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/services/rss");
            db.DeleteAllServices();

            int tempId = 0;

            foreach (var item in xDoc.Descendants("item"))
            {
                switch ((string) item.Element("title"))
                {
                    case "Qualification Assessment":
                        tempId = 0;
                        goto case "Done";

                    case "Undergraduate Programs":
                        tempId = 1;
                        goto case "Done";

                    case "Postgraduate Programs":
                        tempId = 2;
                        goto case "Done";

                    case "AIMS Professional Examination":
                        tempId = 3;
                        goto case "Done";

                    case "AIMS Pathology Collector / Phlebotomy Examination":
                        tempId = 4;
                        goto case "Done";

                    case "Immunohaematology Quality Assurance Program":
                        tempId = 5;
                        goto case "Done";

                    case "Corporate Opportunities ":
                        tempId = 6;
                        goto case "Done";

                    case "Done":
                        db.InsertOrUpdateService(new ServiceModel()
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

            Services = new ObservableCollection<ServiceModel>(db.GetAllServices());
            IsBusy = false;
        }
    }
}