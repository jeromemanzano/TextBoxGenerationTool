using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AlphaSlider), typeof(AlphaSliderRenderer_iOS))]
namespace TextBoxGenerationTool.iOS.CustomRenderers
{
    public class AlphaSliderRenderer_iOS : SliderRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (Control != null)
            {
                var gradientImage = CreateGradientImage(rect.Size);
                Control.SetMaxTrackImage(gradientImage, UIControlState.Normal);
                Control.SetMinTrackImage(gradientImage, UIControlState.Normal);
            }
        }

        public UIImage CreateGradientImage(CGSize rect)
        {
            var customSlider = Element as ColorSlider;

            var gradientLayer = new CAGradientLayer()
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5),
                Colors = new CGColor[]
                {
                    Color.Transparent.ToCGColor(),
                    Color.Black.ToCGColor()
                },
                Frame = new CGRect(0, 0, rect.Width, rect.Height),
            };

            UIGraphics.BeginImageContext(gradientLayer.Frame.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image.CreateResizableImage(UIEdgeInsets.Zero);
        }
    }
}