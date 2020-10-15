using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TextBoxGenerationTool.CustomControls
{
    public class ColorSlider : Slider
    {
        public Color Color1 { get; set; } = Color.FromRgb(255, 0, 0);
        public Color Color2 { get; set; } = Color.FromRgb(255, 255, 0);
        public Color Color3 { get; set; } = Color.FromRgb(0, 255, 0);
        public Color Color4 { get; set; } = Color.FromRgb(0, 255, 255);
        public Color Color5 { get; set; } = Color.FromRgb(0, 0, 255);
        public Color Color6 { get; set; } = Color.FromRgb(255, 0, 255);
        public Color Color7 { get; set; } = Color.FromRgb(255, 0, 0);
    }
}
