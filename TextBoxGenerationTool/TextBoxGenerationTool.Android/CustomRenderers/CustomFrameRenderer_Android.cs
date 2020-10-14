using System.ComponentModel;
using Android.Content;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer_Android))]
namespace TextBoxGenerationTool.Droid.CustomRenderers
{
    public class CustomFrameRenderer_Android : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public CustomFrameRenderer_Android(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e != null && Element != null)
            {
                SetShadow();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e == null)
            {
                return;
            }

            if (e.PropertyName == nameof(CustomFrame.ShadowSize) ||
                e.PropertyName == nameof(CustomFrame.BackgroundColor))
            {
                SetShadow();
            }
        }

        private void SetShadow() 
        {
            var shadowSize = ((CustomFrame)Element).ShadowSize;
            Elevation = shadowSize;
            TranslationZ = 0.0f;
            SetZ(shadowSize);
        }
    }
}