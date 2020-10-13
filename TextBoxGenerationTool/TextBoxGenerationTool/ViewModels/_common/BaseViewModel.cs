using System;
using System.Threading.Tasks;
using TextBoxGenerationTool.Navigation;
using TextBoxGenerationTool.Services;

namespace TextBoxGenerationTool.ViewModels
{
    public abstract class BaseViewModel : Observable
    {
        private readonly IDialogService _dialogService;
        protected readonly INavigationService _navigationService;

        public BaseViewModel()
        {
            _navigationService = IoC.Resolve<INavigationService>();
            _dialogService = IoC.Resolve<IDialogService>();
        }


        public virtual Task Initialize() 
        {
            return Task.CompletedTask;
        }

        public virtual void TopPagePopped(object parameter) 
        { 
        }

        public Task NavigateTo(Type viewModelType) 
        {
            return _navigationService.PushAsync(viewModelType);
        }

        public Task NavigateTo<TParameter>(Type viewModelType, TParameter parameter)
        {
            return _navigationService.PushAsync<TParameter>(viewModelType, parameter);
        }

        public Task Close(object parameter = null) 
        {
            return _navigationService.PopAsync(parameter);
        }

        public Task DisplayAlert(string title, string message, string cancel = "close") 
        {
            return _dialogService.DisplayAlert(title, message, cancel);
        }
    }

    public abstract class BaseViewModel<T> : BaseViewModel
    {
        public virtual Task Initialize(T parameter)
        {
            return Task.CompletedTask;
        }
    }
}
