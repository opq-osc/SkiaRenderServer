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
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(200, 200),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                Width = 600,
                Height = 600,
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(100, 100),
            });
            grid1.AddChild(new Box
            {
                Width = 400,
                Height = 400,
                Margin = new Margin(200, 200),
                Padding = new Padding(100, 100),
                BackgroundColor = SKColors.Green,
                ForegroundColor = SKColors.Orange,
            });

            var grid2 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(1000, 200),
                Padding = new Padding(0, 0)
            };
            grid2.AddChild(new Box
            {
                Width = 600,
                Height = 600,
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(100, 100),
            });
            grid2.AddChild(new Box
            {
                Width = 400,
                Height = 400,
                Margin = new Margin(200, 200),
                Padding = new Padding(100, 100),
                BackgroundColor = SKColors.Green,
                ForegroundColor = SKColors.Orange,
            });

            var grid3 = new Grid
            {
                Width = 2000,
                Height = 1200,
                BackgroundColor = SKColors.Purple,
                Margin = new Margin(200, 0),
            };
            grid3.AddChild(grid1);
            grid3.AddChild(grid2);
            

            var bitmap = new SKBitmap(2400, 1200);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid3.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 水平左对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest2()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                HorizontalAlignment = HorizontalAlignment.Left
            });

            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest2.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest2.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 水平右对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest3()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                HorizontalAlignment = HorizontalAlignment.Right
            });
           
            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest3.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest3.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 水平中心对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest4()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest3.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest3.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 垂直顶部对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest5()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                VerticalAlignment = VerticalAlignment.Top
            });

            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest5.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest5.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 垂直底部对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest6()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                VerticalAlignment = VerticalAlignment.Bottom
            });

            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest6.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest6.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        /// <summary>
        /// 垂直中心对齐
        /// </summary>
        [TestMethod()]
        public void RenderTest7()
        {
            var grid1 = new Grid()
            {
                Width = 800,
                Height = 800,
                BackgroundColor = SKColors.Blue,
                Margin = new Margin(100, 100),
                Padding = new Padding(0, 0)
            };
            grid1.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Margin = new Margin(50, 50),
                Width = 400,
                Height = 400,
                VerticalAlignment = VerticalAlignment.Center
            });

            var bitmap = new SKBitmap(1000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            grid1.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("RenderTest7.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("RenderTest7.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }
    }
}