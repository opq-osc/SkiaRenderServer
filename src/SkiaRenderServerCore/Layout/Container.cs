using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Layout
{
    public abstract class Container : Widget
    {
        public Container() : base()
        {
            _children = new();
        }

        public abstract override (int Width, int Height) SetConstraint(int maxWidth, int maxHeight, int minWidth, int minHeight);

        public abstract override void UpdateLayout();

        public IEnumerable<Widget> Children => _children.AsReadOnly();

        private readonly List<Widget> _children;
    }
}
