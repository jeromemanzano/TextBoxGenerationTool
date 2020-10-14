using System;
using System.ComponentModel;
using TextBoxGenerationTool.CustomControls;
using TextBoxGenerationTool.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer_iOS))]
namespace TextBoxGenerationTool.iOS.CustomRenderers
{
    public class CustomEditorRenderer_iOS : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            var editor = (CustomEditor)Element;

            if (e == null || editor == null)
            {
                return;
            }

            Control.Layer.BorderColor = editor.BorderColor.ToCGColor();
            SetBorderThickness();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e == null)
            {
                return;

            }

            var custom = (CustomEditor)Element;

            if (e.PropertyName == nameof(CustomEditor.BorderColor))
            {
                Control.Layer.BorderColor = custom.BorderColor.ToCGColor();
            }

            if (e.PropertyName == nameof(CustomEditor.BorderThickness))
            {
                SetBorderThickness();
            }
        }

        private void SetBorderThickness() 
        {
            var custom = (CustomEditor)Element;

            Control.Layer.BorderWidth = custom.BorderThickness;
            Control.TextContainerInset = new UIEdgeInsets(custom.BorderThickness, custom.BorderThickness, custom.BorderThickness, custom.BorderThickness);

            Control.SetNeedsDisplay();
        }
    }
}