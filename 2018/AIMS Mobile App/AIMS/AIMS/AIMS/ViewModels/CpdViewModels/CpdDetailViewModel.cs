#region

using System.Collections.ObjectModel;
using System.Windows.Input;
using AIMS.Core.Database;
using AIMS.Core.Models;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

#endregion

namespace AIMS.ViewModels.CpdViewModels
{
    public class CpdDetailViewModel : BaseViewModel, IViewModel
    {
        private readonly Database db;

        public CpdDetailViewModel()
        {
            db = new Database();
            LoadItemsCommand = new Command(ExecuteLoadActivitiesCommand);
        }

        private ObservableCollection<ActivityModel> activities;

        public ObservableCollection<ActivityModel> Activities
        {
            get { return activities; }
            set
            {
                activities = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadItemsCommand { get; set; }

        public void ExecuteLoadActivitiesCommand()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            if(activities != null)
            {
                Activities.Clear();
            }
            Activities = new ObservableCollection<ActivityModel>(db.GetAllActivities());
            IsBusy = false;
        }
    }
}