using Xamarin.Forms;
using TextBoxGenerationTool.Navigation;
using Autofac;

namespace TextBoxGenerationTool
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetupContainer();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void SetupContainer() 
        {
            var containerBuilder = new ContainerBuilder();
            IoC.RegisterCoreDependencies(containerBuilder);
            IoC.Publish(containerBuilder);

            var navigationService = IoC.Resolve<INavigationService>();
            navigationService.InitializeNavigationPage();
        }
    }
}
