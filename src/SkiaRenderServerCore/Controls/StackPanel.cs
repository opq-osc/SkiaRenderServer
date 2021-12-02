using SkiaRenderServerCore.Render;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Controls
{
    public class StackPanel : ElementContainerBase
    {
        public Orientation Orientation { get; set; }
        public override void AddChild(ElementBase element)
        {
            base.AddChild(element);
        }

        private int width = 0;
        private int height = 0;

        public override int Width
        {
            get
            {
                if (Orientation == Orientation.Horizontal && width == 0)
                {
                    width += Padding.Left + Padding.Right;
                    foreach (var child in Children)
                        width += child.Width + child.Margin.Left + child.Margin.Right;
                }
                if (Orientation == Orientation.Vertical && width == 0)
                {
                    var childWidth = from child in Children
                                      select child.Width + child.Margin.Left + child.Margin.Right;
                    width = childWidth.Max() + Padding.Left + Padding.Right;
                }
                return width;
            }
            set => width = value;
        }

        public override int Height
        {
            get
            {
                if (Orientation == Orientation.Vertical && height == 0)
                {
                    height += Padding.Top + Padding.Bottom;
                    foreach (var child in Children)
                        height += child.Height + child.Margin.Top + child.Margin.Bottom;
                }
                if (Orientation == Orientation.Horizontal && height == 0)
                {
                    var childHeight = from child in Children
                                      select child.Height + child.Margin.Top + child.Margin.Bottom;
                    height = childHeight.Max() + Padding.Top + Padding.Bottom;
                }
                return height;
            }
            set => height = value;
        }

        protected override void RenderForeground(SKCanvas canvas)
        {
            base.RenderForeground(canvas);
            var offset = 0;
            foreach (var element in Children)
            {
                // 计算子元素区域大小
                var rangeSize = new SKSize(element.Width + element.Margin.Left + element.Margin.Right,
                    element.Height + element.Margin.Top + element.Margin.Bottom);
                if (Orientation == Orientation.Horizontal)
                    rangeSize.Height = Height - Padding.Top - Padding.Bottom;
                if (Orientation == Orientation.Vertical)
                    rangeSize.Width = Width - Padding.Left - Padding.Right;
                element.RangeSize = rangeSize;

                element.Render(canvas);

                if (Orientation == Orientation.Horizontal)
                {
                    canvas.Translate(element.Width + element.Margin.Right + element.Margin.Left, 0); 
                    offset += element.Width + element.Margin.Right + element.Margin.Left;
                }
                
                if (Orientation == Orientation.Vertical)
                {
                    canvas.Translate(0, element.Height + element.Margin.Bottom + element.Margin.Top);
                    offset += element.Height + element.Margin.Bottom + element.Margin.Top;
                }
            }
            if (Orientation == Orientation.Horizontal)
                canvas.Translate(-offset, 0);
            if (Orientation == Orientation.Vertical)
                canvas.Translate(0, -offset);
        }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}
