using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountryClocksApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClocksPage : ContentPage
    {
        SKPaint whiteFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        SKPaint blackStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };

        SKPaint blackFill = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };
        public ClocksPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.Gray);
            canvas.Scale(e.Info.Width / 400f);
            DrawClocks(e, 0, 0, 8 , 8);
            DrawClocks(e, 0, e.Info.Height / 4, 64, 4);
            DrawClocks(e, 0, e.Info.Height / 2, 128, 3);


        }


        public void DrawClocks(SKPaintSurfaceEventArgs e, int px, int py, int translateW, int translateH)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            DateTime dateTime = DateTime.Now;
            int width = e.Info.Width;
            int height = e.Info.Height;

            
            canvas.Translate(width / translateW, height / translateH);
           

            canvas.DrawCircle(0, 0, 50, whiteFillPaint);

            for (int angle = 0; angle < 360; angle += 6)
            {
                canvas.DrawCircle(0, - 45, angle % 30 == 0 ? 2 : 1, blackFill);
                canvas.RotateDegrees(6);
            }

            //Hour hand
            canvas.Save();
            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            blackStrokePaint.StrokeWidth = 8;
            canvas.DrawLine(0, 0, 0, - 20, blackStrokePaint);
            canvas.Restore();

            //Minute hand
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            blackStrokePaint.StrokeWidth = 4;
            canvas.DrawLine(0, 0, 0, - 30, blackStrokePaint);
            canvas.Restore();

            //Second hand
            canvas.Save();
            float seconds = dateTime.Second + dateTime.Millisecond / 1000f;
            canvas.RotateDegrees(6 * seconds);
            blackStrokePaint.StrokeWidth = 2;
            canvas.DrawLine(0, 0, 0, - 40, blackStrokePaint);
            canvas.Restore();
        }

    }
}