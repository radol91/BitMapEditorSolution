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
    // Klasa przechowująca dane z nagłowka bitmapy,tablice bajtow pliku bmp oraz tablice pikseli pliku bmp;
    class MyBitmapInfo
    {
        //Czysta tablica pikseli bez dodatkowych bajtow - rozmiar wiersza (Width * 3 (24 bit));
        private byte[,] pixelArray;
        private int bmpWeight;
        private int xSize;
        private int ySize;
        private String bmpPath;
        private byte[] byteArray;
        private int offset;
        private int pixelCount;

        // Konstruktor klasy
        public MyBitmapInfo(Image img, String path)
        {
            Bitmap bitmap = convertTo24bpp(img);
            this.xSize = bitmap.Size.Width;
            this.ySize = bitmap.Size.Height;
            this.byteArray = toByteArray(bitmap, ImageFormat.Bmp);
            this.pixelArray = convertArray(this.byteArray, this.xSize, this.SizeY);
            this.offset = this.byteArray[10];
            this.pixelCount = this.byteArray[28];
            this.bmpPath = path;
            this.bmpWeight = this.offset + bitmap.Width * bitmap.Size.Height * 3;
        }

        // Przepisanie tablicy pikseli na ktorej operuje funkcja asemblerowa i przerobienie jej na bitmape.
        public void finalizeAssemblerFunc(MyBitmap myBitmap)
        {
            myBitmap.PreviousBitmap = (Bitmap)myBitmap.CurrentBitmap.Clone();
            myBitmap.CurrentBitmap = createBitmapFromPixelArray(pixelArray, SizeX, SizeY);
        }

        // Konwertuje bitmape na 24bitowa;
        public static Bitmap convertTo24bpp(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gr = Graphics.FromImage(bmp);
            gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        // Funkcja przerabia obrazek na tablice bajtow;
        public byte[] toByteArray(Image image, ImageFormat format)
        {
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, format);
                return ms.ToArray();
            }
            return null;
        }

        // Konwertuje tablice 1D na 2D;
        public byte[,] convertArray(byte[] Input, int sizeX, int sizeY)
        {
            int width = ((Input.Length - 54) / sizeY);
            int additional = width - (SizeX * 3);
            int line = 0;
            byte[,] Output = new byte[sizeY, width - additional];
            //System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\OutFile.txt");
            for (int i = 54; i < Input.Length; i += width)
            {
                for (int j = 0; j < width - additional; j++)
                {
                    Output[line, j] = Input[i + j];
                    //sw.Write(Input[i + j] + " ");
                }
                //sw.WriteLine("");
                line++;
            }
            //sw.Close();
            return Output;
        }

        // Funkcja tworzy bitmape z tablicy bajtow;
        public Bitmap createBitmapFromByteArray(byte[] pixelArray)
        {
            return new Bitmap(Bitmap.FromStream(new MemoryStream(pixelArray)));
        }

        // Funkcja tworzy bitmape z tablicy pikseli;
        public Bitmap createBitmapFromPixelArray(byte[,] Input, int sizeX, int sizeY)
        {
            int width = ((byteArray.Length - 54) / sizeY);
            int additional = width - (SizeX * 3);
            byte[] additionalArray = new byte[additional];
            byte[] tmpByteArray = new byte[byteArray.Length];
            Bitmap bitmap = new Bitmap(sizeX, sizeY);
            Array.Copy(byteArray, tmpByteArray, offset);

            int i = offset;
            for (int k = 0; k < sizeY; k++)
            {
                for (int n = 0; n < sizeX * 3; n++)
                {
                    tmpByteArray[i] = Input[k, n];
                    i++;
                }
                additionalArray.CopyTo(tmpByteArray, i);
                i+=additional;
            }
                byteArray = (byte[])tmpByteArray.Clone();
            return createBitmapFromByteArray(byteArray);
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
        public byte[,] PixelArray
        {
            get
            {
                return pixelArray;
            }
            set
            {
                pixelArray = value;
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
