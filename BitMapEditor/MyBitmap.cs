using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace BitMapEditor
{
    class MyBitmap
    {
        private Bitmap preBitmap;
        private Bitmap curBitmap;
        private MyBitmapInfo bitmapInfo;
        private byte[] byteArray;
        //Czysta tablica pikseli bez dodatkowych bajtow - rozmiar wiersza (Width * 3 (24 bit));
        private byte[,] pixelArray;

        public MyBitmap(Image image, String path)
        {
            this.preBitmap = convertTo24bpp(image);
            this.curBitmap = convertTo24bpp(image);
            this.byteArray = toByteArray(curBitmap, ImageFormat.Bmp);
            this.bitmapInfo = new MyBitmapInfo(image,byteArray[10],byteArray[28],path);
            this.pixelArray = convertArray(this.byteArray, image.Width, image.Height);
            //bitmap.Dispose();
        }

        // Konwertuje bitmape na 24bitowa;
        public static Bitmap convertTo24bpp(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gr = Graphics.FromImage(bmp);
            //gr.DrawImage(bmp, new Rectangle(0, 0, img.Width, img.Height));
            gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        // Przepisanie tablicy pikseli na ktorej operuje funkcja asemblerowa i przerobienie jej na bitmape.
        public void finalizeAssemblerFunc()
        {
            this.preBitmap = this.curBitmap;
            Bitmap bmp = createBitmapFromPixelArray(this.pixelArray, this.bitmapInfo.SizeX, this.bitmapInfo.SizeY);
            this.curBitmap = convertTo24bpp(bmp);
        }

        public void finalizeAssemblerFuncSharp(byte[,] resultArray)
        {
            this.preBitmap = curBitmap;
            this.pixelArray = (byte[,])resultArray.Clone();
            Bitmap bmp = createBitmapFromPixelArray(this.pixelArray, this.bitmapInfo.SizeX, this.bitmapInfo.SizeY);
            this.curBitmap = convertTo24bpp(bmp);
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
            int additional = width - (sizeX * 3);
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
            int additional = width - (sizeX * 3);
            byte[] additionalArray = new byte[additional];
            byte[] tmpByteArray = new byte[byteArray.Length];
            Bitmap bitmap = new Bitmap(sizeX, sizeY);
            Array.Copy(byteArray, tmpByteArray, bitmapInfo.Offset);

            int i = bitmapInfo.Offset;
            for (int k = 0; k < sizeY; k++)
            {
                for (int n = 0; n < sizeX * 3; n++)
                {
                    tmpByteArray[i] = Input[k, n];
                    i++;
                }
                additionalArray.CopyTo(tmpByteArray, i);
                i += additional;
            }
            byteArray = (byte[])tmpByteArray.Clone();
            return createBitmapFromByteArray(byteArray);
        }

        // Nadpisanie byteArray i pixelArray;
        internal void updateArrays()
        {
            this.byteArray = this.toByteArray(this.curBitmap, ImageFormat.Bmp);
            this.pixelArray = this.convertArray(this.byteArray, this.bitmapInfo.SizeX, this.bitmapInfo.SizeY);
        }

        public Bitmap PreviousBitmap{
            get
            {
                return preBitmap;
            }
            set
            {
                preBitmap = value;
            }
        }
        public Bitmap CurrentBitmap
        {
            get
            {
                return curBitmap;
            }
            set
            {
                curBitmap = value;
            }
        }
        public MyBitmapInfo BitmapInfo
        {
            get
            {
                return bitmapInfo;
            }
            set
            {
                bitmapInfo = value;
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

    }
}
