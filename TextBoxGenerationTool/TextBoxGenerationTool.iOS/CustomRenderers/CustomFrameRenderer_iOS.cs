using System.ComponentModel;
using System.Drawing;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer_iOS))]
namespace TextBoxGenerationTool.iOS.CustomRenderers
{
    public class CustomFrameRenderer_iOS : FrameRenderer
    {
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
            this.Layer.ShadowRadius = shadowSize;
            this.Layer.ShadowOffset = new SizeF(0, shadowSize);
        }
    }
}