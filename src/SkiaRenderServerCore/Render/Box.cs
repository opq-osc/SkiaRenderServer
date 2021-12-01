using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Render
{
    public class Box : ElementBase
    {
        public SKColor ForegroundColor { get; set; }
        public SKColor BackgroundColor { get; set; }

        protected override void RenderBackground(SKCanvas canvas)
        {
            base.RenderBackground(canvas);

            using var paint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = BackgroundColor
            };

            canvas.DrawRect(0, 0, Width, Height, paint);
        }

        protected override void RenderForeground(SKCanvas canvas)
        {
            base.RenderForeground(canvas);

            using var paint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = ForegroundColor
            };

            canvas.DrawRect(0, 0, Width - Padding.Left - Padding.Right, 
                                  Height - Padding.Top - Padding.Bottom, paint);
        }
    }
}
