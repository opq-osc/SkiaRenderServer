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
            foreach (var child in Children)
            {
                child.Render(canvas);
            }
        }

        public override void AddChild(ElementBase element)
        {
            base.AddChild(element);
            element.RangeSize = new SKSize(Width - Padding.Left - Padding.Right,
                Height - Padding.Top - Padding.Bottom);
        }
    }
}
