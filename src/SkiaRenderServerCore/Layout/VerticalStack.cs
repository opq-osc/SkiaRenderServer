using SkiaRenderServerCore.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Layout
{
    public class VerticalStack : Container
    {
        /// <summary>
        /// 设置/获取容器中元素的间隙
        /// </summary>
        public int Spacing { get; set; }

        public override (int Width, int Height) SetConstraint(int maxWidth, int maxHeight, int minWidth, int minHeight)
        {
            var height = 0;
            foreach (var child in Children)
            {
                var childSize = child.SetConstraint(maxWidth - Padding.Left - Padding.Right - child.Margin.Left - child.Margin.Right,
                    maxHeight - Padding.Top - Padding.Bottom - child.Margin.Top - child.Margin.Bottom);
                height += child.Height + child.Margin.Top + child.Margin.Bottom;
            }

            if (Width == 0) Width = maxWidth;
            else if (Width < minWidth) Width = minWidth;
            else if (Width > maxWidth) Width = maxWidth;

            // VerticalStack的Height取决于子元素，与初始设置值无关
            Height = height;
            if (Height > maxHeight) Height = maxHeight;
            if (Height < minHeight) Height = minHeight;

            return (Width, Height);
        }

        public override void UpdateLayout()
        {
            var ans = Padding.Top;
            foreach (var child in Children)
            {
                child.Left = child.HorizontalAlignment switch
                {
                    HorizontalAlignment.Left => Padding.Left + child.Margin.Left,
                    HorizontalAlignment.Right => Width - Padding.Right - child.Margin.Right - child.Width,
                    HorizontalAlignment.Center => (Width - child.Width
                                                    + Padding.Left + child.Margin.Left
                                                    - Padding.Right - child.Margin.Right) / 2,
                    _ => throw new NotImplementedException()
                };
                child.Top = ans + child.Margin.Top;
                ans += child.Margin.Top + child.Height + child.Margin.Bottom;
            }
        }
    }
}

#if false

1. 向子元素传递约束，子元素返回尺寸；子元素确定自身尺寸的过程对父元素是透明的
2. 确定子元素位置（根据子元素尺寸及Padding Margin 对齐方式）

#endif