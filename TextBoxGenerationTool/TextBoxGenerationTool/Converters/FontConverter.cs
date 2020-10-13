using System;
using System.Globalization;
using Xamarin.Forms;

namespace TextBoxGenerationTool.Converters
{
    public class FontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var font = value as string;

            return Device.RuntimePlatform == Device.Android ? $"{font}.ttf#{font}" : font;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
