using SkiaRenderServerCore.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Layout
{
    public abstract class Widget
    {
        /// <summary>
        /// 设置元素在容器中的水平对齐方式
        /// </summary>
        public HorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// 设置元素在容器中的垂直对其方式
        /// </summary>
        public VerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        /// 设置/获取元素宽度，该值可能受父容器约束影响而被重写
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 设置/获取元素高度，该值可能受父容器约束影响而被重写
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 设置/获取元素外边距
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// 设置/获取元素内边距
        /// </summary>
        public Padding Padding { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        public abstract (int Width, int Height) SetConstraint(int maxWidth, int maxHeight, int minWidth, int minHeight);

        /// <summary>
        /// 重新计算元素布局
        /// </summary>
        public abstract void UpdateLayout();

        public (int Width, int Height) SetConstraint(int maxWidth, int maxHeight) => SetConstraint(maxWidth, maxHeight, 0, 0);
    }
}
