#region

using AIMS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace AIMS.Views.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageMaster : ContentPage
    {
        public ListView ListView;

        public HomePageMaster()
        {
            InitializeComponent();

            BindingContext = new HomePageMasterViewModel();
            ListView = MenuItemsListView;
            AimsLogo.Source = "AIMSLogo_NoText_LowRes.png";
        }
    }
}