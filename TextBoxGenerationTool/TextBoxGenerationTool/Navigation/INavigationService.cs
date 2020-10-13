using System;
using System.Threading.Tasks;

namespace TextBoxGenerationTool.Navigation
{
    public interface INavigationService
    {
        void InitializeNavigationPage();

        Task PushAsync(Type viewModelType);

        Task PushAsync<T>(Type viewModelType, T parameter);

        Task PopAsync(object parameter = null);
    }
}
