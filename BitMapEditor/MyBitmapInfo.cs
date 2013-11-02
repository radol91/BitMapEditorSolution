using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BitMapEditor
{
    class MyBitmapInfo
    {
        private int bmpWeight;
        private int xSize;
        private int ySize;
        private String bmpPath;
        private byte[] byteArray;
        private byte[,] pixelArray;
        private int offset;
        private int pixelCount;

        public MyBitmapInfo(Image img, String path)
        {
            // Wyciaganie danych z naglowka bitmapy.
            Bitmap bitmap = convertTo24bpp(img);
            this.xSize = bitmap.Size.Width;
            this.ySize = bitmap.Size.Height;
            this.byteArray = toByteArray(bitmap, ImageFormat.Bmp);
            //Czysta tablica pikseli bez dodatkowych bajtow - rozmiar wiersza (Width * 3 (24 bit));
            this.pixelArray = convertArray(this.byteArray, this.xSize, this.SizeY);
            this.offset = this.byteArray[10];
            this.pixelCount = this.byteArray[28];
            this.bmpPath = path;
            this.bmpWeight = this.offset + 4 * 16 + bitmap.Width * bitmap.Size.Height;
            Bitmap b = createBitmapFromPixelArray(this.pixelArray, SizeY, SizeX);
            b.Save("C:/vvv.bmp");
            //this.bmpWeight = (int)(this.pixelTab[2]);
            //this.bmpWeight += (int)(this.pixelTab[3] * 256);
            //this.bmpWeight += (int)(this.pixelTab[4] * 65536);
            //this.bmpWeight += (int)(this.pixelTab[5] * 1677690);
        }

        public static Bitmap convertTo24bpp(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gr = Graphics.FromImage(bmp);
            gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        public static byte[] toByteArray(Image image, ImageFormat format)
        {
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, format);
                return ms.ToArray();
            }
            return null;
        }

        public byte[,] convertArray(byte[] Input, int sizeX, int sizeY)
        {
            int width = ((Input.Length - 54) / sizeY);
            int additional = width - (SizeX * 3);
            int line = 0;
            byte[,] Output = new byte[sizeY, width - additional];
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\OutFile.txt");
            for (int i = 54; i < Input.Length; i += width)
            {
                for (int j = 0; j < width - additional; j++)
                {
                    Output[line, j] = Input[i + j];
                    sw.Write(Input[i + j]+" ");
                }
                sw.WriteLine("");
                line++;
            }
            sw.Close();
            return Output;
        }

        // Funkcja negatyw bedzie zwaracac byte[] i ta funkcja przerobie ja na bitmape, 
        public Bitmap createBitmapFromByteArray(byte[] pixelArray)
        {
            Image img = Bitmap.FromStream(new MemoryStream(pixelArray));
            return new Bitmap(img);
        }

        public Bitmap createBitmapFromPixelArray(byte[,] Input, int bitmapHeight , int bitmapWidth)
        {
            Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight);

            for (int i = 0; i < bitmapWidth; i+=3)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    int r = Input[i,j];
                    int g = Input[i + 1,j];
                    int b = Input[i + 2,j];
                    bitmap.SetPixel(i, j, Color.FromArgb(r,g,b));
                }
            }
            return bitmap;
        }

        public int Weight
        {
            get
            {
                return bmpWeight;
            }
        }
        public String Path
        {
            get
            {
                return bmpPath;
            }
            set
            {
                bmpPath = value;
            }
        }
        public int SizeX
        {
            get
            {
                return xSize;
            }
            set
            {
                xSize = value;
            }
        }
        public int SizeY
        {
            get
            {
                return ySize;
            }
            set
            {
                ySize = value;
            }

        }
        public byte[] ByteArray
        {
            get
            {
                return byteArray;
            }
            set
            {
                byteArray = value;
            }
        }
        public int Offset
        {
            get
            {
                return offset;
            }
        }
        public int BitPerPixel
        {
            get
            {
                return pixelCount;
            }
        }
    }
}
