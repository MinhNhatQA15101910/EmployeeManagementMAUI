using UserManagement.MAUI.Models;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}