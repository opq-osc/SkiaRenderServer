using SkiaRenderServerCore.Struct;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Render
{
    public abstract class ElementBase
    {
        /// <summary>
        /// 绘制区大小，渲染时由父容器指定
        /// </summary>
        public SKSize RangeSize { get; set; }

        /// <summary>
        /// 元素的高度，可能会被重写
        /// </summary>
        public virtual int Height { get; set; }

        /// <summary>
        /// 元素宽度，可能会被重写
        /// </summary>
        public virtual int Width { get; set; }

        /// <summary>
        /// 元素外部边距
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// 元素内部边距
        /// </summary>
        public Padding Padding { get; set; }

        /// <summary>
        /// 父级元素
        /// </summary>
        public ElementBase? Parent { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }

        public void Render(SKCanvas canvas)
        {
            #region 计算布局
            if (Width <= 0) Width = (int)RangeSize.Width - Margin.Left - Margin.Right;
            if (Height <= 0) Height = (int)RangeSize.Height - Margin.Top - Margin.Bottom;

            var margin = Margin;
            if (HorizontalAlignment == HorizontalAlignment.Center)
                margin.Left = margin.Right = ((int)RangeSize.Width - Width) >> 1;
            if (HorizontalAlignment == HorizontalAlignment.Right)
                margin.Left = (int)RangeSize.Width - Width - margin.Right;
            if (VerticalAlignment == VerticalAlignment.Center)
                margin.Top = margin.Bottom = ((int)RangeSize.Height - Height) >> 1;
            if (VerticalAlignment == VerticalAlignment.Bottom)
                margin.Top = (int)RangeSize.Height - Height - margin.Bottom;
            Margin = margin;
            #endregion

            this.RenderBackground(canvas);
            this.RenderForeground(canvas);
            canvas.Translate(-Margin.Left - Padding.Left, -Margin.Top - Padding.Top);
        }

        /// <summary>
        /// 指定如何在Canvas上绘制该元素背景层
        /// </summary>
        /// <param name="canvas"></param>
        protected virtual void RenderBackground(SKCanvas canvas)
        {
            canvas.Translate(Margin.Left, Margin.Top);
        }

        /// <summary>
        /// 指定如何在Canvas上绘制该元素前景层
        /// </summary>
        /// <param name="canvas"></param>
        protected virtual void RenderForeground(SKCanvas canvas)
        {
            canvas.Translate(Padding.Left, Padding.Top);
        }
    }
}
