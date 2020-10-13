using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer_Android))]

namespace TextBoxGenerationTool.Droid.CustomRenderers
{
    public class CustomLabelRenderer_Android : LabelRenderer
    {
        public CustomLabelRenderer_Android(Context context) : base(context)
        {
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e != null)
            {
                if (e.PropertyName == nameof(CustomLabel.BorderColor) ||
                        e.PropertyName == nameof(CustomLabel.BorderThickness))
                {
                    var formsColor = ((CustomLabel)Element).BorderColor;
                    var borderThickness = ((CustomLabel)Element).BorderThickness;
                    var padding = borderThickness + 2;
                    var nativeEditText = (global::Android.Widget.TextView)Control;

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