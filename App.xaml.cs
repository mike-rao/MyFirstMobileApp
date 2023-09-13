using MyFirstMobileApp.ViewViewModels.Main;

namespace MyFirstMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();
            MainPage = new MainView();
        }
    }
}