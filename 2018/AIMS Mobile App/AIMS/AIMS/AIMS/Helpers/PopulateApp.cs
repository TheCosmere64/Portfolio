using System.Threading.Tasks;

namespace AIMS.Helpers
{
    public class PopulateApp
    {
        public async Task<int> Execute()
        {
            
            ViewModels.AboutUsViewModel.AboutUsDetailViewModel aboutUsVm =
                new ViewModels.AboutUsViewModel.AboutUsDetailViewModel();

            ViewModels.EventViewModel.EventDetailViewModel eventVm =
                new ViewModels.EventViewModel.EventDetailViewModel();

            ViewModels.HomeViewModel.HomePageDetailViewModel homeVm =
                new ViewModels.HomeViewModel.HomePageDetailViewModel();

            ViewModels.JournalViewModel.JournalDetailViewModel journalvm =
                new ViewModels.JournalViewModel.JournalDetailViewModel();

            ViewModels.MemberViewModel.MemberDetailViewModel memberVm =
                new ViewModels.MemberViewModel.MemberDetailViewModel();

            ViewModels.ServiceViewModel.ServiceDetailViewModel serviceVm =
                new ViewModels.ServiceViewModel.ServiceDetailViewModel();

            ViewModels.CareerViewModel.CareerDetailViewModel careerVm =
                new ViewModels.CareerViewModel.CareerDetailViewModel();

            Task[] tasks = new Task[7];
            tasks[0] = new Task(() => eventVm.ExecuteLoadNewsCommand());
            tasks[1] = new Task(() => aboutUsVm.ExecuteLoadNewsCommand());
            tasks[2] = new Task(() => homeVm.ExecuteLoadNewsCommand());
            tasks[3] = new Task(() => journalvm.ExecuteLoadNewsCommand());
            tasks[4] = new Task(() => memberVm.ExecuteLoadNewsCommand());
            tasks[5] = new Task(() => serviceVm.ExecuteLoadNewsCommand());
            tasks[6] = new Task(() => careerVm.PopulateDatabase());

           

            Parallel.ForEach(tasks, (t) => { t.Start(); });
            await Task.WhenAll(tasks);

            return 1;
        }
    }
}