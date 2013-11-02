using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

namespace BitMapEditor
{
    class MyBitmapEditor
    {
        private const int MAX = 256;
        internal void grayScale(MyBitmap myBitmap)
        {
            myBitmap.PreviousBitmap = (Bitmap)myBitmap.CurrentBitmap.Clone();
            // Wykorzystanie modelu YUV
            const float rMod = 0.299f;
            const float gMod = 0.587f;
            const float bMod = 0.114f;
            Graphics g = Graphics.FromImage(myBitmap.CurrentBitmap);
       
            ColorMatrix colorMatrix = new ColorMatrix(new[]
            {
                new[] {rMod, rMod, rMod, 0, 1},
                new[] {gMod, gMod, gMod, 0, 1},
                new[] {bMod, bMod, bMod, 0, 1},
                new[] {0.0f, 0.0f, 0.0f, 1, 1},
                new[] {0.0f, 0.0f, 0.0f, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            int x = myBitmap.BitmapInfo.SizeX;
            int y = myBitmap.BitmapInfo.SizeY;
            g.DrawImage(myBitmap.CurrentBitmap, new Rectangle(0, 0, x, y), 0, 0, x, y, GraphicsUnit.Pixel, attributes);
            g.Dispose();
        }


        internal void sharpenBitmap(MyBitmap myBitmap)
        {            
            Bitmap sharpenImage = new Bitmap(myBitmap.BitmapInfo.SizeX, myBitmap.BitmapInfo.SizeY);

            int filterWidth = 3;
            int filterHeight = 3;
            int width = myBitmap.BitmapInfo.SizeX;
            int height = myBitmap.BitmapInfo.SizeY;

            // Tablica maski.
            int[,] filter = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };

            //double factor = 1.0;
            //double bias = 0.0;

            Color[,] result = new Color[width, height];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    int red = 0, green = 0, blue = 0;
                    Color imageColor = myBitmap.CurrentBitmap.GetPixel(x, y);

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + width) % width;
                            int imageY = (y - filterHeight / 2 + filterY + height) % height;

                            Color bmpColor = myBitmap.CurrentBitmap.GetPixel(imageX, imageY);
                            red += bmpColor.R * filter[filterX, filterY];
                            green += bmpColor.G * filter[filterX, filterY];
                            blue += bmpColor.B * filter[filterX, filterY];
                        }

                        int r = Math.Min(Math.Max(red, 0), 255);
                        int g = Math.Min(Math.Max(green, 0), 255);
                        int b = Math.Min(Math.Max(blue, 0), 255);
                        //int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        //int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        //int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }

            myBitmap.CurrentBitmap = sharpenImage;
        }

        internal void goBack(MyBitmap myBitmap)
        {
            Bitmap tmp = (Bitmap)myBitmap.PreviousBitmap.Clone();
            myBitmap.CurrentBitmap = myBitmap.PreviousBitmap;
            myBitmap.PreviousBitmap = tmp;
        }

        internal void inverseBitmap(MyBitmap myBitmap)
        {
            myBitmap.PreviousBitmap = (Bitmap)myBitmap.CurrentBitmap.Clone();
            Graphics g = Graphics.FromImage(myBitmap.CurrentBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(new[]
            {
                new[] {-1.0f, 0.0f, 0.0f, 0, 0},
                new[] {0.0f, -1.0f, 0.0f, 0, 0},
                new[] {0.0f, 0.0f, -1.0f, 0, 0},
                new[] {0.0f, 0.0f, 0.0f, 1, 0},
                new[] {1.0f, 1.0f, 1.0f, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            int x = myBitmap.BitmapInfo.SizeX;
            int y = myBitmap.BitmapInfo.SizeY;
            g.DrawImage(myBitmap.CurrentBitmap, new Rectangle(0, 0, x, y), 0, 0, x, y, GraphicsUnit.Pixel, attributes);
            g.Dispose();
        }

        internal Bitmap createBitmapFromPixelArray(byte[] pixelArray)
        {
            Image img = Bitmap.FromStream(new MemoryStream(pixelArray));
            return new Bitmap(img);
        }
    }
}

