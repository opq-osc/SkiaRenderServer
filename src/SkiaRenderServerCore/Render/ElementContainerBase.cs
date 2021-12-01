using SkiaRenderServerCore.Struct;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Render
{
    public class ElementContainerBase : ElementBase
    {
        public ElementContainerBase()
        {
            Children = new();
        }

        /// <summary>
        /// 子元素
        /// </summary>
        public List<ElementBase> Children { get; set; }

    }
}
