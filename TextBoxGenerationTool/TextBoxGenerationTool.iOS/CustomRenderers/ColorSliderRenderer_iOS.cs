using System;
using CoreAnimation;
using CoreGraphics;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ColorSlider), typeof(ColorSliderRenderer_iOS))]
namespace TextBoxGenerationTool.iOS.CustomRenderers
{
    public class ColorSliderRenderer_iOS : SliderRenderer
    {
        void OnControlValueChanged(object sender, EventArgs eventArgs)
        {
            ((IElementController)Element).SetValueFromRenderer(Slider.ValueProperty, Control.Value);
        }

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
                    customSlider.Color1.ToCGColor(),
                    customSlider.Color2.ToCGColor(),
                    customSlider.Color3.ToCGColor(),
                    customSlider.Color4.ToCGColor(),
                    customSlider.Color5.ToCGColor(),
                    customSlider.Color6.ToCGColor(),
                    customSlider.Color7.ToCGColor()
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