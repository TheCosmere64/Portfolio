#region

using System.Collections.ObjectModel;
using AIMS.Core.Models;
using AIMS.Helpers;
using AIMS.Views.AboutUsPages;
using AIMS.Views.CareersPages;
using AIMS.Views.CpdPages;
using AIMS.Views.EventPages;
using AIMS.Views.JournalPages;
using AIMS.Views.MasterDetailPages;
using AIMS.Views.MembershipPages;
using AIMS.Views.ProfilePages;
using AIMS.Views.ServicePages;

#endregion

namespace AIMS.ViewModels
{
    public class HomePageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<HomePageMenuItem> MenuItems { get; set; }

        public HomePageMasterViewModel()
        {
            bool loggedIn = LoggedIn.loggedIn;
            if (loggedIn)
            {
                MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
                {
                    new HomePageMenuItem
                        {Id = 0, Title = "Profile", Image = "Profile.png", TargetType = typeof(ProfileDetail)},
                    new HomePageMenuItem
                        {Id = 1, Title = "News", Image = "newspaper.png", TargetType = typeof(HomePageDetail)},
                    new HomePageMenuItem
                        {Id = 2, Title = "Membership", Image = "MemberShip.png", TargetType = typeof(MembershipDetail)},
                    new HomePageMenuItem
                        {Id = 3, Title = "Services", Image = "Services.png", TargetType = typeof(ServiceDetail)},
                    new HomePageMenuItem {Id = 4, Title = "CPD", Image = "CPD.png", TargetType = typeof(CpdDetail)},
                    new HomePageMenuItem
                        {Id = 5, Title = "Events", Image = "Events.png", TargetType = typeof(EventDetail)},
                    new HomePageMenuItem
                        {Id = 6, Title = "Careers", Image = "Careers.png", TargetType = typeof(CareersDetail)},
                    new HomePageMenuItem
                    {
                        Id = 7, Title = "Journal/Publications", Image = "JournalPublications.png",
                        TargetType = typeof(JournalDetail)
                    },
                    new HomePageMenuItem
                        {Id = 8, Title = "About Us", Image = "AboutUs.png", TargetType = typeof(AboutUsDetail)}
                });
            }
            else
            {
                MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
                {
                    new HomePageMenuItem
                        {Id = 0, Title = "News", Image = "newspaper.png", TargetType = typeof(HomePageDetail)},
                    new HomePageMenuItem
                        {Id = 1, Title = "Membership", Image = "MemberShip.png", TargetType = typeof(MembershipDetail)},
                    new HomePageMenuItem
                        {Id = 2, Title = "Service", Image = "Services.png", TargetType = typeof(ServiceDetail)},
                    new HomePageMenuItem
                        {Id = 3, Title = "Events", Image = "Events.png", TargetType = typeof(EventDetail)},
                    new HomePageMenuItem
                        {Id = 4, Title = "Careers", Image = "Careers.png", TargetType = typeof(CareersDetail)},
                    new HomePageMenuItem
                    {
                        Id = 5, Title = "Journal/Publications", Image = "JournalPublications.png",
                        TargetType = typeof(JournalDetail)
                    },
                    new HomePageMenuItem
                        {Id = 6, Title = "About Us", Image = "AboutUs.png", TargetType = typeof(AboutUsDetail)}
                });
            }
        }
    }
}