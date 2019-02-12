#region

using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.MemberViewModel
{
    public class MembershipPageViewModel : BaseViewModel
    {
        private static int Key;
        private readonly Database db;
        private static MembershipModel Membership;

        public MembershipPageViewModel(int key)
        {
            LoadItemsCommand = new Command(ExecuteLoadNewsCommand);
            db = new Database();
            Key = key;
            ExecuteLoadNewsCommand();
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
            Membership = db.GetMembership(Key);
            Title = Membership.Title;
            string ParsedDescription = Membership.Description.Replace("src=\"/", "src=\"https://www.aims.org.au/");
            Description = ParsedDescription;
            Link = Membership.Link;
            IsBusy = false;
        }
    }
}