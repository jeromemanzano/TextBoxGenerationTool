using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextBoxGenerationTool.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerControl : ContentView
    {
        public event EventHandler<Color> PickedColorChanged;
        private bool _pickerInitialized = false;

        public static readonly BindableProperty PickedColorProperty
            = BindableProperty.Create(
                nameof(PickedColor),
                typeof(Color),
                typeof(ColorPickerControl),
                Color.Default,
                BindingMode.OneWayToSource);

        public Color PickedColor
        {
            get { return (Color)GetValue(PickedColorProperty); }
            set { SetValue(PickedColorProperty, value); }
        }

        public static readonly BindableProperty BaseColorProperty
            = BindableProperty.Create(
                nameof(BaseColor),
                typeof(Color),
                typeof(ColorPickerControl),
                Color.Red,
                BindingMode.OneWay,
                null,
                OnBaseColorPropertyChanged);

        public Color BaseColor
        {
            get { return (Color)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }

        private SKPoint _lastTouchPoint;

        public ColorPickerControl()
        {
            InitializeComponent();
        }

        private static void OnBaseColorPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var control = (ColorPickerControl)bindable;
            control.SkCanvasView.InvalidateSurface();
        }

        private void SkCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var skImageInfo = e.Info;
            var skSurface = e.Surface;
            var skCanvas = skSurface.Canvas;

            var skCanvasWidth = skImageInfo.Width;
            var skCanvasHeight = skImageInfo.Height;

            skCanvas.Clear(SKColors.White);

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;

                var colors = new SKColor[]
                {
                    new SKColor(255, 255, 255), //White
					SKColor.Parse(BaseColor.ToHex()) //Base
                };

                using (var shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(skCanvasWidth, 0),
                    colors,
                    null,
                    SKShaderTileMode.Clamp))
                {
                    paint.Shader = shader;
                    skCanvas.DrawPaint(paint);
                }
            }

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;

                var colors = new SKColor[]
                {
                    SKColors.Transparent,
                    SKColors.Black
                };

                using (var shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(0, skCanvasHeight),
                    colors,
                    null,
                    SKShaderTileMode.Clamp))
                {
                    paint.Shader = shader;
                    skCanvas.DrawPaint(paint);
                }
            }

            SKColor touchPointColor;
            var outerRingRadius =
                ((float)skCanvasWidth / (float)skCanvasHeight) * (float)18;

            var innerRingRadius =
                ((float)skCanvasWidth / (float)skCanvasHeight) * (float)12;

            if (!_pickerInitialized)
            {
                _pickerInitialized = true;
                _lastTouchPoint = new SKPoint(skImageInfo.Width - innerRingRadius, innerRingRadius);
            }

            using (SKBitmap bitmap = new SKBitmap(skImageInfo))
            {
                IntPtr dstpixels = bitmap.GetPixels();

                skSurface.ReadPixels(skImageInfo,
                    dstpixels,
                    skImageInfo.RowBytes,
                    (int)_lastTouchPoint.X, (int)_lastTouchPoint.Y);

                touchPointColor = bitmap.GetPixel(0, 0);
            }

            using (SKPaint paintTouchPoint = new SKPaint())
            {
                paintTouchPoint.Style = SKPaintStyle.Fill;
                paintTouchPoint.Color = SKColors.White;
                paintTouchPoint.IsAntialias = true;

                skCanvas.DrawCircle(
                    _lastTouchPoint.X,
                    _lastTouchPoint.Y,
                    outerRingRadius, paintTouchPoint);

                paintTouchPoint.Color = touchPointColor;

                skCanvas.DrawCircle(
                    _lastTouchPoint.X,
                    _lastTouchPoint.Y,
                    innerRingRadius, paintTouchPoint);
            }

            PickedColor = touchPointColor.ToFormsColor();
            PickedColorChanged?.Invoke(this, PickedColor);
        }

        private void SkCanvasView_OnTouch(object sender, SKTouchEventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (!e.InContact)
                    return;
            }

            _lastTouchPoint = e.Location;

            var canvasSize = SkCanvasView.CanvasSize;

            if ((e.Location.X > 0 && e.Location.X < canvasSize.Width) &&
                (e.Location.Y > 0 && e.Location.Y < canvasSize.Height))
            {
                e.Handled = true;

                SkCanvasView.InvalidateSurface();
            }
        }
    }
}