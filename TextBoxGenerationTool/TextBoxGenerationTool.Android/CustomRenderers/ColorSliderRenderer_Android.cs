using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ColorSlider), typeof(ColorSliderRenderer_Android))]
namespace TextBoxGenerationTool.Droid.CustomRenderers
{
    public class ColorSliderRenderer_Android : SliderRenderer
    {
        public ColorSliderRenderer_Android(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var slider = Element as ColorSlider;

                var thumb = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.OvalShape());
                thumb.SetIntrinsicHeight(30);
                thumb.SetIntrinsicWidth(30);
                thumb.SetColorFilter(Color.White.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
                Control.SetThumb(thumb);

                Control.ProgressDrawable = new ColorDrawable(Color.Transparent.ToAndroid());
                Control.SetPadding(0, 0, 0, 0);
                Control.Background = new GradientDrawable(GradientDrawable.Orientation.LeftRight,
                    new int[] { slider.Color1.ToAndroid(), slider.Color2.ToAndroid(), slider.Color3.ToAndroid(), slider.Color4.ToAndroid(),
                        slider.Color5.ToAndroid(), slider.Color6.ToAndroid(), slider.Color7.ToAndroid() });
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (Control == null)
                return;

            SeekBar seekbar = Control;

            Drawable thumb = seekbar.Thumb;
            int thumbTop = seekbar.Height / 2 - thumb.IntrinsicHeight / 2;

            thumb.SetBounds(thumb.Bounds.Left, thumbTop, thumb.Bounds.Left + thumb.IntrinsicWidth, thumbTop + thumb.IntrinsicHeight);
        }
    }
}