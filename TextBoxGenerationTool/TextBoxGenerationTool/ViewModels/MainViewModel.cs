using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using TextBoxGenerationTool.Models;
using Xamarin.Forms;

namespace TextBoxGenerationTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public override Task Initialize()
        {
            SelectedFont = "Sindentosa";

            return base.Initialize();
        }

        public override void TopPagePopped(object parameter)
        {
            base.TopPagePopped(parameter);

            var popParam = parameter as TextBoxPageResultModel;
            if (parameter == null)
            {
                return;
            }

            var textParam = popParam.TextInfoModel;

            BorderSize = textParam.BorderSize;
            BorderColor = textParam.BorderColor;
            FontSize = textParam.FontSize;
            TextColor = textParam.TextColor;
            BackgroundColor = textParam.BackgroundColor;
            InputText = textParam.InputText;
            ShadowSize = textParam.ShadowSize;
            SelectedFont = textParam.SelectedFont;

            var urlParam = popParam.UrlInfoModel;

            if (urlParam != null)
            {
                //TODO: implement
            }
        }


        private int _borderSize;
        public int BorderSize
        {
            get => _borderSize;
            private set => Set(ref _borderSize, value);
        }

        private int _shadowSize;
        public int ShadowSize
        {
            get => _shadowSize;
            private set => Set(ref _shadowSize, value);
        }

        private int _fontSize;
        public int FontSize
        {
            get => _fontSize;
            private set => Set(ref _fontSize, value);
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            private set => Set(ref _textColor, value);
        }

        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get => _backgroundColor;
            private set => Set(ref _backgroundColor, value);
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get => _borderColor;
            private set => Set(ref _borderColor, value);
        }

        private string _selectedFont;
        public string SelectedFont
        {
            get => _selectedFont;
            private set => Set(ref _selectedFont, value);
        }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            private set => Set(ref _inputText, value);
        }

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
