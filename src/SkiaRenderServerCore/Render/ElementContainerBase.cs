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
        protected List<ElementBase> Children { get; set; }

        /// <summary>
        /// 添加子元素
        /// </summary>
        /// <param name="element"></param>
        public virtual void AddChild(ElementBase element)
        {
            Children.Add(element);
            element.Parent = this;
        }

        public IEnumerable<ElementBase> GetChildren()
        {
            return Children.AsReadOnly();
        }

    }
}
