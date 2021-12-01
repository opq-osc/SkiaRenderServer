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

        public virtual void Render(SKCanvas canvas)
        {
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
