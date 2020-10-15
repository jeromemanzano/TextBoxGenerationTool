using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using TextBoxGenerationTool.Models;
using TextBoxGenerationTool.Services;
using Xamarin.Forms;

namespace TextBoxGenerationTool.ViewModels
{
    public class TextBoxViewModel : BaseViewModel<bool>
    {
        private readonly IRestService _restService;

        public TextBoxViewModel(IRestService restService)
        {
            _restService = restService;
        }

        public override Task Initialize(bool showUrl)
        {
            TextColorSlider = 0;
            BackgroundColorSlider = 0;
            BorderColorSlider = 0;
            BorderSizeSlider = 0;
            FontSizeSlider = 15;
            ShadowSizeSlider = 0;

            SelectedFont = Fonts.First();

            ShowUrl = showUrl;

            return base.Initialize();
        }

        public ObservableCollection<string> Fonts { get; } = new ObservableCollection<string>()
        {
            "Sindentosa",
            "PlayfairDisplay-Regular",
        };

        private int _textColorSldier;
        public int TextColorSlider
        {
            get => _textColorSldier;
            set
            {
                Set(ref _textColorSldier, value);
                TextPickerBaseColor = SliderToColor(value);
            }
        }

        private int _backgroundColorSlider;
        public int BackgroundColorSlider
        {
            get => _backgroundColorSlider;
            set
            {
                Set(ref _backgroundColorSlider, value);
                BackgroundPickerBaseColor = SliderToColor(value);
            }
        }

        private int _borderColorSlider;
        public int BorderColorSlider
        {
            get => _borderColorSlider;
            set
            {
                Set(ref _borderColorSlider, value);
                BorderPickerBaseColor = SliderToColor(value);
            }
        }

        private int _borderSizeSlider;
        public int BorderSizeSlider
        {
            get => _borderSizeSlider;
            set => Set(ref _borderSizeSlider, value);
        }

        private int _shadowSizeSlider;
        public int ShadowSizeSlider
        {
            get => _shadowSizeSlider;
            set => Set(ref _shadowSizeSlider, value);
        }

        private int _fontSizeSlider;
        public int FontSizeSlider
        {
            get => _fontSizeSlider;
            set => Set(ref _fontSizeSlider, value);
        }

        private double _textAlpha;
        public double TextAlpha
        {
            get => _textAlpha;
            set
            {
                Set(ref _textAlpha, value);
                UpdateTextColor();
            }
        }

        private double _backgroundAlpha;
        public double BackgroundAlpha
        {
            get => _backgroundAlpha;
            set
            {
                Set(ref _backgroundAlpha, value);
                UpdateBackgroundColor();
            }
        }

        private double _borderAlpha;
        public double BorderAlpha
        {
            get => _borderAlpha;
            set
            {
                Set(ref _borderAlpha, value);
                UpdateBorderColor();
            }
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

        private Color _backgroundPickerBaseColor;
        public Color BackgroundPickerBaseColor
        {
            get => _backgroundPickerBaseColor;
            private set => Set(ref _backgroundPickerBaseColor, value);
        }

        private Color _borderPickerBaseColor;
        public Color BorderPickerBaseColor
        {
            get => _borderPickerBaseColor;
            set => Set(ref _borderPickerBaseColor, value);
        }

        private Color _textPickerBaseColor;
        public Color TextPickerBaseColor
        {
            get => _textPickerBaseColor;
            set => Set(ref _textPickerBaseColor, value);
        }

        private Color _textPickedColor;
        public Color TextPickedColor
        {
            get => _textPickedColor;
            set
            {
                Set(ref _textPickedColor, value);
                UpdateTextColor();
            }
        }

        private Color _borderPickedColor;
        public Color BorderPickedColor
        {
            get => _borderPickedColor;
            set
            {
                Set(ref _borderPickedColor, value);
                UpdateBorderColor();
            }
        }

        private Color _backgroundPickedColor;
        public Color BackgroundPickedColor
        {
            get => _backgroundPickedColor;
            set
            {
                Set(ref _backgroundPickedColor, value);
                UpdateBackgroundColor();
            }
        }

        private string _selectedFont;
        public string SelectedFont
        {
            get => _selectedFont;
            set => Set(ref _selectedFont, value);
        }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => Set(ref _inputText, value);
        }

        private string _inputUrl;
        public string InputUrl
        {
            get => _inputUrl;
            set => Set(ref _inputUrl, value);
        }

        private bool _showUrl;
        public bool ShowUrl
        {
            get => _showUrl;
            private set => Set(ref _showUrl, value);
        }

        private bool? _urlValid;
        public bool? UrlValid
        {
            get => _urlValid;
            private set => Set(ref _urlValid, value);
        }
        

        private ICommand _closePageCommand;
        public ICommand ClosePageCommand
        {
            get => _closePageCommand ?? (_closePageCommand = new AsyncCommand(ClosePage));
        }

        private ICommand _verifyUrlCommand;
        public ICommand VerifyUrlCommand
        {
            get => _verifyUrlCommand ?? (_verifyUrlCommand = new AsyncCommand(VerifyUrl));
        }

        private async Task VerifyUrl() 
        {
            try
            {
                var cts = new CancellationTokenSource(30000);
                var result = await _restService.VerifyUrl(InputUrl, cts.Token);

                if (result == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Success", "200 - Valid Url");
                }
                else 
                { 
                    await DisplayAlert("Error", $"{result} - Invalid Url");
                }
            }
            catch (OperationCanceledException opEx) 
            { 
                await DisplayAlert("Error", "We didn't receive any response. Please check your connection and try again");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message);
            }
        }

        private Task ClosePage()
        {
            var result = new TextBoxPageResultModel();
            result.TextInfoModel = new TextInfoModel 
            { 
                TextColor = TextColor,
                BackgroundColor= BackgroundColor,
                BorderColor = BorderColor,
                FontSize = FontSizeSlider,
                BorderSize = BorderSizeSlider,
                ShadowSize = ShadowSizeSlider,
                SelectedFont = SelectedFont,
                InputText = InputText
            };

            if (ShowUrl)
            {
                result.UrlInfoModel = new UrlInfoModel()
                {
                    IsVerified = UrlValid == true,
                    Url = InputUrl
                };
            }

            return Close(result);
        }

        private void UpdateTextColor()
        {
            TextColor = Color.FromRgba(TextPickedColor.R, TextPickedColor.G, TextPickedColor.B, TextAlpha);
        }

        private void UpdateBackgroundColor()
        {
            BackgroundColor = Color.FromRgba(BackgroundPickedColor.R, BackgroundPickedColor.G, BackgroundPickedColor.B, BackgroundAlpha);
        }

        private void UpdateBorderColor()
        {
            BorderColor = Color.FromRgba(BorderPickedColor.R, BorderPickedColor.G, BorderPickedColor.B, BorderAlpha);
        }

        private Color SliderToColor(int value)
        {
            int Reduce()
            {
                return 148 - (value % 68) - 68;
            }

            int Increase()
            {
                return 80 + (value % 68);
            }

            if (value < 69)
            {
                return Color.FromRgb(148, Increase(), 80);
            }
            else if (value < 137)
            {
                return Color.FromRgb(Reduce(), 148, 80);
            }
            else if (value < 205)
            {
                return Color.FromRgb(80, 148, Increase());
            }
            else if (value < 273)
            {
                return Color.FromRgb(80, Reduce(), 148);
            }
            else if (value < 341)
            {
                return Color.FromRgb(Increase(), 80, 148);
            }
            else
            {
                return Color.FromRgb(148, 80, Reduce());
            }
        }
    }
}
