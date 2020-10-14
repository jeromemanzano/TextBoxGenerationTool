using Xamarin.Forms;

namespace TextBoxGenerationTool.CustomControls
{
    public class CustomEditor : Editor
    {
        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(Color), Color.Transparent);
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(int), 0, BindingMode.OneWay, null, OnBorderPropertyChanged);
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static BindableProperty ShadowSizeProperty = BindableProperty.Create(nameof(ShadowSize), typeof(int), typeof(int), 0);
        public int ShadowSize
        {
            get { return (int)GetValue(ShadowSizeProperty); }
            set { SetValue(ShadowSizeProperty, value); }
        }

        private static void OnBorderPropertyChanged(BindableObject bindable, object value, object newValue) 
        {
            var control = (CustomEditor)bindable;
            control.InvalidateMeasure();
        }
    }
}
