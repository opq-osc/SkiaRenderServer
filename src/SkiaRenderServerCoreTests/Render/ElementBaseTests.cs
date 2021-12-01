using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiaRenderServerCore.Render;
using SkiaRenderServerCore.Struct;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaRenderServerCore.Render.Tests
{
    [TestClass()]
    public class ElementRenderTest
    {
        [TestMethod()]
        public void RenderTest()
        {
            var grid = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(200, 200),
                Padding = new Padding(0, 0)
            };
            grid.Children.Add(new Box
            {
                Width = 600,
                Height = 600,
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(100, 100),
            });
            grid.Children.Add(new Box
            {
                Width = 400,
                Height = 400,
                Margin = new Margin(200, 200),
                Padding = new Padding(100, 100),
                BackgroundColor = SKColors.Green,
                ForegroundColor = SKColors.Orange,
            });

            var bitmap = new SKBitmap(1200, 1200);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }
    }
}