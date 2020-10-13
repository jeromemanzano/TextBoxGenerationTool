using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer_Android))]

namespace TextBoxGenerationTool.Droid.CustomRenderers
{
    public class CustomEntryRenderer_Android : EditorRenderer
    {
        public CustomEntryRenderer_Android(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e != null)
            {
                if (e.PropertyName == nameof(CustomEntry.BorderColor) ||
                        e.PropertyName == nameof(CustomEntry.BorderThickness))
                {
                    var formsColor = ((CustomEntry)Element).BorderColor;
                    var borderThickness = ((CustomEntry)Element).BorderThickness;
                    var padding = borderThickness + 2;
                    var nativeEditText = (global::Android.Widget.EditText)Control;

                    var border = new GradientDrawable();
                    border.SetStroke(borderThickness, formsColor.ToAndroid());

                    nativeEditText.Background = border;
                    nativeEditText.SetPadding(padding, padding, padding, padding);
                }

                if (e.PropertyName == nameof(CustomEntry.ShadowSize))
                {
                    //TODO: implement
                    //var shadowSize = ((CustomEntry)Element).ShadowSize;
                    //var nativeEditText = (global::Android.Widget.EditText)Control;
                }
            }
        }
    }
}