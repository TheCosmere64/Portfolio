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

namespace AIMS.ViewModels.JournalViewModel
{
    public class JournalDetailViewModel : BaseViewModel
    {
        private readonly Database db;

        public JournalDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            Journals = new ObservableCollection<JournalModel>(db.GetAllJournals());
        }

        private ObservableCollection<JournalModel> journals;

        public ObservableCollection<JournalModel> Journals
        {
            get { return journals; }
            set
            {
                journals = value;
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
            if (Journals != null)
            {
                Journals.Clear();
            }

            XDocument xDoc = XDocument.Load("https://www.aims.org.au/news-media/rss");
            db.DeleteAllJournals();

            int tempId = 0;

            foreach (var item in xDoc.Descendants("item"))
            {
                switch ((string) item.Element("title"))
                {
                    case "Australian Journal of Medical Science":
                        tempId = 0;
                        goto case "Done";

                    case "Competency Standards":
                        tempId = 1;
                        goto case "Done";

                    case "AIMS Annual Reports":
                        tempId = 2;
                        goto case "Done";

                    case "Submissions & Documents":
                        tempId = 3;
                        goto case "Done";

                    case "Useful Links":
                        tempId = 4;
                        goto case "Done";

                    case "Students' Section":
                        tempId = 5;
                        goto case "Done";

                    case "Done":
                        var date = DateTime.ParseExact((string) item.Element("pubDate"),
                            "ddd',' dd MMM yyyy HH:mm:ss K",
                            CultureInfo.InvariantCulture);
                        db.InsertOrUpdateJournal(new JournalModel()
                        {
                            Id = tempId,
                            Title = (string) item.Element("title"),
                            Link = (string) item.Element("link"),
                            Description = (string) item.Element("description"),
                            DatePublished = date.ToString("ddd, dd MMM yyyy")
                        });
                        break;

                    default:
                        break;
                }
            }

            Journals = new ObservableCollection<JournalModel>(db.GetAllJournals());
            IsBusy = false;
        }
    }
}