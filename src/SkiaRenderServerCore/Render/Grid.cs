using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Render
{
    public class Grid : ElementContainerBase
    {
        public Grid() : base() { }

        public SKColor BackgroundColor { get; set; }

        public override void Render(SKCanvas canvas)
        {
            this.RenderBackground(canvas);
            this.RenderForeground(canvas);
            foreach (var child in Children)
            {
                child.Render(canvas);
            }
            canvas.Translate(-Margin.Left - Padding.Left, -Margin.Top - Padding.Top);
        }

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
    }
}
