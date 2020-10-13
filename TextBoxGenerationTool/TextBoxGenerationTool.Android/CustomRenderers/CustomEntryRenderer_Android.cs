using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
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

                    var nativeEditText = (global::Android.Widget.EditText)Control;


                    //TODO: adjust border accordingly
                    ShapeDrawable shape = new ShapeDrawable(new RectShape());
                    shape.Paint.Color = formsColor.ToAndroid();
                    shape.Paint.SetStyle(Paint.Style.Stroke);
                    shape.Paint.StrokeWidth = borderThickness;
                    shape.SetPadding(new Rect(borderThickness, borderThickness, borderThickness, borderThickness));
                    nativeEditText.Background = shape;

                    nativeEditText.SetPadding(borderThickness + 2, borderThickness + 2, borderThickness + 2, borderThickness + 2);
                }
            }

        }
    }
}