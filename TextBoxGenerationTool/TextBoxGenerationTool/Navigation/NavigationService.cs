using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TextBoxGenerationTool.ViewModels;
using Xamarin.Forms;

namespace TextBoxGenerationTool.Navigation
{
    public class NavigationService : INavigationService
    {

        protected ConditionalWeakTable<IPageViewModel, TaskCompletionSource<object>> _tcsResults = new ConditionalWeakTable<IPageViewModel, TaskCompletionSource<object>>();

        public NavigationPage NavigationPage
        {
            get
            {
                return Application.Current.MainPage as NavigationPage;
            }
        }
        
        public async Task PushAsync(Type viewModelType)
        {
            Page page = CreatePageWithViewModel(viewModelType);

            var vm = page.BindingContext as BaseViewModel;
            await vm.Initialize();

            await NavigationPage.PushAsync(page);
        }

        public async Task PushAsync<T>(Type viewModelType, T parameter)
        {
            Page page = CreatePageWithViewModel(viewModelType);

            var vm = page.BindingContext as BaseViewModel<T>;
            await vm.Initialize(parameter);

            await NavigationPage.PushAsync(page);
        }

        public void InitializeNavigationPage() 
        {
            var page = CreatePageWithViewModel(typeof(MainViewModel));
            (page.BindingContext as BaseViewModel).Initialize();
            Application.Current.MainPage = new NavigationPage(page);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("ViewModel", "Page");
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePageWithViewModel(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            SetBindingContextView(page);

            return page;
        }

        private static void SetBindingContextView(Page view)
        {
            if (view != null && view.BindingContext == null)
            {
                var viewType = view.GetType();
                var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName.Replace("Page", "ViewModel")}, {viewAssemblyName}";

                var viewModelType = Type.GetType(viewModelName);
                if (viewModelType != null)
                {
                    var viewModel = IoC.Resolve(viewModelType) as BaseViewModel;

                    view.BindingContext = viewModel;
                }
            }
        }
    }
}
