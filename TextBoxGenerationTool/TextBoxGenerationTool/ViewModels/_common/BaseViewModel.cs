using System;
using System.Threading.Tasks;
using TextBoxGenerationTool.Navigation;

namespace TextBoxGenerationTool.ViewModels
{
    public abstract class BaseViewModel : Observable, IPageViewModel
    {
        public BaseViewModel()
        {
            NavigationService = IoC.Resolve<INavigationService>();
        }

        protected INavigationService NavigationService { get; }

        public virtual Task Initialize() 
        {
            return Task.CompletedTask;
        }

        public virtual void TopPagePopped(object parameter) 
        { 
        }

        public Task NavigateTo(Type viewModelType) 
        {
            return NavigationService.PushAsync(viewModelType);
        }

        public Task NavigateTo<TParameter>(Type viewModelType, TParameter parameter)
        {
            return NavigationService.PushAsync<TParameter>(viewModelType, parameter);
        }

        public Task Close(object parameter = null) 
        {
            return NavigationService.PopAsync(parameter);
        }
    }

    public abstract class BaseViewModel<T> : BaseViewModel, IPageViewModel
    {
        public virtual Task Initialize(T parameter)
        {
            return Task.CompletedTask;
        }
    }
}
