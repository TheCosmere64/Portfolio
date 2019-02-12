#region

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Xml.Linq;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.MemberViewModel
{
    public class MemberDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public MemberDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            Membership = new ObservableCollection<MembershipModel>(db.GetAllMemberships());
        }

        private ObservableCollection<MembershipModel> membership;

        public ObservableCollection<MembershipModel> Membership
        {
            get { return membership; }
            set
            {
                membership = value;
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
            if (Membership != null)
            {
                Membership.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/membership-information/rss");
            db.DeleteAllMemberships();

            int tempId = 0;

            foreach (var item in xDoc.Descendants("item"))
            {
                switch ((string) item.Element("title"))
                {
                    //Filters out the unused elements from the RSS feed (Sub catagories of Fellowship)
                    case "Anatomical Pathology/Histopathology":
                        break;
                    case "Clinical Biochemistry":
                        break;
                    case "Cytopathology":
                        break;
                    case "General/Core Pathology":
                        break;
                    case "Haematology":
                        break;
                    case "Immunology":
                        break;
                    case "Microbiology":
                        break;
                    case "Transfusion Science":
                        break;

                    //Filters Out the old membership pricing
                    case "Corporate Membership Fees":
                        break;
                    case "Individual Membership Fees":
                        break;
                    case "Student Membership Fees":
                        break;
                    case "Join Now! ":
                        break;

                    case "Join AIMS today!":
                        tempId = 0;
                        goto default;
                    case "Certification of Supporting Documentation - Membership ":
                        tempId = 1;
                        goto default;
                    case "Membership Benefits":
                        tempId = 2;
                        goto default;
                    case "Membership Options":
                        tempId = 3;
                        goto default;
                    case "AIMS Membership Exam":
                        tempId = 4;
                        goto default;
                    case "Fellowship":
                        tempId = 5;
                        goto default;
                    case "Faces of the Fellowship":
                        tempId = 6;
                        goto default;
                    case "Code of Conduct":
                        tempId = 7;
                        goto default;
                    case "Good Standing":
                        tempId = 8;
                        goto default;
                    case "Membership Fees ":
                        tempId = 9;
                        goto default;
                    case "Life Membership Award":
                        tempId = 10;
                        goto default;
                    case "Corporate Members":
                        tempId = 11;
                        goto default;
                    default:
                        db.InsertOrUpdateMembership(new MembershipModel()
                        {
                            Id = tempId,
                            Title = (string) item.Element("title"),
                            Link = (string) item.Element("link"),
                            Description = (string) item.Element("description")
                        });
                        break;
                }
            }

            Membership = new ObservableCollection<MembershipModel>(db.GetAllMemberships());
            IsBusy = false;
        }
    }
}