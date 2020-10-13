﻿using Xamarin.Forms;

namespace TextBoxGenerationTool.CustomControls
{
    public class CustomLabel : Label
    {
        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(Color), Color.Transparent);
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(int), 0);
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static BindableProperty ShadowSizeProperty = BindableProperty.Create(nameof(ShadowSize), typeof(int), typeof(int), 0);
        public int ShadowSize
        {
            get { return (int)GetValue(ShadowSizeProperty); }
            set { SetValue(ShadowSizeProperty, value); }
        }
    }
}