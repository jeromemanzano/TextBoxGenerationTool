using System;
using Xamarin.Forms;

namespace TextBoxGenerationTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public void Initialize() 
        {
            TextColorSlider = 0;
            BackgroundColorSlider = 0;
            BorderColorSlider = 0;
            BorderSizeSlider = 0;
        }

        private string _testTextBind;
        public string TestTextBind
        {
            get => _testTextBind;
            set => Set(ref _testTextBind, value);
        }

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
            set
            {
                Set(ref _borderSizeSlider, value);
                //TextColor = Color.FromHex(value.ToString("X").PadLeft(6, '0'));
            }
        }

        private int _shadowSizeSlider;
        public int ShadowSizeSlider
        {
            get => _shadowSizeSlider;
            set
            {
                Set(ref _shadowSizeSlider, value);
                //TextColor = Color.FromHex(value.ToString("X").PadLeft(6, '0'));
            }
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
            set => Set(ref _textColor, value);
        }

        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => Set(ref _backgroundColor, value);
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get => _borderColor;
            set => Set(ref _borderColor, value);
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
