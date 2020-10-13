using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace TextBoxGenerationTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _openTextPageCommand;
        public ICommand OpenTextPageCommand
        {
            get => _openTextPageCommand ?? (_openTextPageCommand = new AsyncCommand<bool>(OpenTextPage));
        }

        private Task OpenTextPage(bool showUrl)
        {
            return NavigateTo(typeof(TextBoxViewModel), showUrl);
        }
    }
}
