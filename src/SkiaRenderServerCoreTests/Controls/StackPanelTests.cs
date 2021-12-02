using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiaRenderServerCore.Controls;
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

namespace SkiaRenderServerCore.Controls.Tests
{
    [TestClass()]
    public class StackPanelTests
    {
        [TestMethod()]
        public void StackPanelTest1()
        {
            var panel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Padding = new Padding(100, 0),
                RangeSize = new SKSize(1000, 2000),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(0, 50),
                Height = 300
            });
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Red,
                Padding = new Padding(0, 50),
                Height = 300
            });
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Yellow,
                Padding = new Padding(0, 50),
                Height = 300
            });
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Black,
                Padding = new Padding(0, 50),
                Height = 300
            });
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Green,
                Padding = new Padding(0, 50),
                Height = 300
            });


            var bitmap = new SKBitmap(1000, 2000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            panel.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("StackPanelTest1.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("StackPanelTest1.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        [TestMethod()]
        public void StackPanelTest2()
        {
            var panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Padding = new Padding(0, 100),
                RangeSize = new SKSize(2000, 1000),
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(50, 0),
                Width = 300
            });
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(50, 0),
                Width = 300
            }); 
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(50, 0),
                Width = 300
            }); 
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(50, 0),
                Width = 300
            }); 
            panel.AddChild(new Box
            {
                ForegroundColor = SKColors.Blue,
                Padding = new Padding(50, 0),
                Width = 300
            });


            var bitmap = new SKBitmap(2000, 1000);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            panel.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("StackPanelTest2.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("StackPanelTest2.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        [TestMethod()]
        public void StackPanelTest3()
        {
            var panel1 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                //HorizontalAlignment = HorizontalAlignment.Center,
            };
            panel1.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Blue,
            });
            panel1.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Yellow,
            });
            panel1.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Green,
            });

            var panel2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                //HorizontalAlignment = HorizontalAlignment.Center,
            };
            panel2.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Blue,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Yellow,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                ForegroundColor = SKColors.Green,
            });

            var panel3 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                RangeSize = new SKSize(600, 500),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            panel3.AddChild(panel1);
            panel3.AddChild(panel2);


            var bitmap = new SKBitmap(600, 500);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            panel3.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("StackPanelTest3.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("StackPanelTest3.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        [TestMethod()]
        public void StackPanelTest4()
        {
            var panel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                //VerticalAlignment = VerticalAlignment.Center,
            };

            panel1.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Red,
            });
            panel1.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Orange,
            });
            panel1.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Purple,
            });

            var panel2 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                //VerticalAlignment = VerticalAlignment.Center,
            };

            panel2.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Red,
            });
            panel2.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Orange,
            });
            panel2.AddChild(new Box
            {
                Height = 100,
                ForegroundColor = SKColors.Purple,
            });

            var panel3 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                RangeSize = new SKSize(500, 600),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            //panel3.AddChild(panel2);
            panel3.AddChild(panel1);
            panel3.AddChild(panel2);


            var bitmap = new SKBitmap(500, 600);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            panel3.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("StackPanelTest4.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("StackPanelTest4.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }

        [TestMethod()]
        public void StackPanelTest5()
        {
            var panel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                //VerticalAlignment = VerticalAlignment.Center,
            };

            panel1.AddChild(new Box
            {
                Height = 100,
                Width = 300,
                ForegroundColor = SKColors.Red,
            });
            panel1.AddChild(new Box
            {
                Height = 100,
                Width = 400,
                ForegroundColor = SKColors.Orange,
            });
            panel1.AddChild(new Box
            {
                Height = 100,
                Width = 500,
                ForegroundColor = SKColors.Green,
            });

            var panel2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Height = 600
                //HorizontalAlignment = HorizontalAlignment.Center,
            };
            panel2.AddChild(new Box
            {
                Width = 100,
                Height = 300,
                ForegroundColor = SKColors.Red,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                Height = 250,
                ForegroundColor = SKColors.Orange,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                Height = 200,
                ForegroundColor = SKColors.Yellow,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                Height = 150,
                ForegroundColor = SKColors.Blue,
            });
            panel2.AddChild(new Box
            {
                Width = 100,
                Height = 100,
                ForegroundColor = SKColors.Purple,
            });

            var panel3 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                RangeSize = new SKSize(500, 600),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            //panel3.AddChild(panel2);
            panel3.AddChild(panel1);
            panel3.AddChild(panel2);


            var bitmap = new SKBitmap(500, 600);
            var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.White);

            panel3.Render(canvas);

            var image = SKImage.FromBitmap(bitmap);
            var file = File.Open("StackPanelTest5.png", FileMode.Create);
            image.Encode(SKEncodedImageFormat.Png, 90).SaveTo(file);
            file.Close();

            var fileInfo = new FileInfo("StackPanelTest5.png");
            Assert.IsTrue(fileInfo.Exists);
            Process.Start("explorer.exe", fileInfo.FullName);
        }
    }
}