using Xamarin.Forms;

namespace TextBoxGenerationTool.CustomControls
{
    public class CustomFrame : Frame
    {
        public static BindableProperty ShadowSizeProperty = BindableProperty.Create(nameof(ShadowSize), typeof(int), typeof(int), 0);
        public int ShadowSize
        {
            get { return (int)GetValue(ShadowSizeProperty); }
            set { SetValue(ShadowSizeProperty, value); }
        }
    }
}
