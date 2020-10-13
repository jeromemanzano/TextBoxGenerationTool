﻿using System;
using System.Collections.ObjectModel;
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
            FontSizeSlider = 10;

            SelectedFont = "Sindentosa";

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
                UpdateTextColor();
            }
        }

        private int _backgroundColorSlider;
        public int BackgroundColorSlider
        {
            get => _backgroundColorSlider;
            set
            {
                Set(ref _backgroundColorSlider, value);
                UpdateBackgroundColor();
            }
        }

        private int _borderColorSlider;
        public int BorderColorSlider
        {
            get => _borderColorSlider;
            set
            {
                Set(ref _borderColorSlider, value);
                UpdateBorderColor();
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

            return Close(result);
        }

        private void UpdateTextColor()
        {
            var rgb = Color.FromHex(TextColorSlider.ToString("X").PadLeft(6, '0'));
            TextColor = Color.FromRgba(rgb.R, rgb.G, rgb.B, TextAlpha);
        }

        private void UpdateBackgroundColor()
        {
            var rgb = Color.FromHex(BackgroundColorSlider.ToString("X").PadLeft(6, '0'));
            BackgroundColor = Color.FromRgba(rgb.R, rgb.G, rgb.B, BackgroundAlpha);
        }

        private void UpdateBorderColor()
        {
            var rgb = Color.FromHex(BorderColorSlider.ToString("X").PadLeft(6, '0'));
            BorderColor = Color.FromRgba(rgb.R, rgb.G, rgb.B, BorderAlpha);
        }
    }
}
