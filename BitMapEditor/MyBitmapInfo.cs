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
        private byte[] prePixelArray;
        private byte[] curPixelArray;
        private int offset;
        private int pixelCount;

        public MyBitmapInfo(Image img, String path)
        {
            // Wyciaganie danych z naglowka bitmapy.
            Bitmap bitmap = new Bitmap(img);
            //BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            //    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //this.bmpStride = bitmapData.Stride;
            //bitmap.UnlockBits(bitmapData);
            this.xSize = bitmap.Size.Width;
            this.ySize = bitmap.Size.Height;
            this.prePixelArray = createPixelArray(bitmap);
            this.curPixelArray = createPixelArray(bitmap);
            this.offset = this.prePixelArray[10];
            this.pixelCount = this.prePixelArray[28];
            this.bmpPath = path;
            this.bmpWeight = this.offset + 4 * 16 + bitmap.Width * bitmap.Size.Height;
            //this.bmpWeight = (int)(this.pixelTab[2]);
            //this.bmpWeight += (int)(this.pixelTab[3] * 256);
            //this.bmpWeight += (int)(this.pixelTab[4] * 65536);
            //this.bmpWeight += (int)(this.pixelTab[5] * 1677690);
            this.bmpWeight /= 8;
        }

        public static byte[] createPixelArray(Bitmap bmp)
        {
            if (bmp != null)
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
            return null;
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
        public byte[] PreviousPixelArray
        {
            get
            {
                return prePixelArray;
            }
            set
            {
                prePixelArray = value;
            }
        }
        public byte[] CurrentPixelArray
        {
            get
            {
                return curPixelArray;
            }
            set
            {
                curPixelArray = value;
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
