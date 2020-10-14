using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer_Android))]

namespace TextBoxGenerationTool.Droid.CustomRenderers
{
    public class CustomEditorRenderer_Android : EditorRenderer
    {
        public CustomEditorRenderer_Android(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e != null)
            {
                Android.Support.V4.Widget.TextViewCompat.SetAutoSizeTextTypeWithDefaults(Control, 1);

                SetBorder();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e == null)
            {
                return;
            }

            if (e.PropertyName == nameof(CustomEditor.BorderColor) ||
                e.PropertyName == nameof(CustomEditor.BorderThickness))
            {
                SetBorder();
            }
        }

        private void SetBorder() 
        { 
            var editor = Element as CustomEditor;
            var formsColor = editor.BorderColor;
            var borderThickness = editor.BorderThickness;
            var padding = borderThickness + 2;
            var nativeEditText = (global::Android.Widget.EditText)Control;

            nativeEditText.SetPadding(padding, nativeEditText.PaddingTop, padding, nativeEditText.PaddingBottom);

            var border = new GradientDrawable();
            border.SetStroke(borderThickness, formsColor.ToAndroid());

            nativeEditText.Background = border;
        }
    }
}