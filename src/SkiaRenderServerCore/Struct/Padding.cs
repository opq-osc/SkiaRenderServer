﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Struct
{
    public struct Padding
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public Padding(int value)
        {
            Left = value;
            Top = value;
            Right = value;
            Bottom = value;
        }

        public Padding(int horizontal, int vertical)
        {
            Left = horizontal;
            Top = vertical;
            Right = horizontal;
            Bottom = vertical;
        }

        public Padding(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
}
