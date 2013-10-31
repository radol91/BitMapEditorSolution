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
        public MyBitmap(Image img, MyBitmapInfo bitmapInfo)
        {
            this.preBitmap = new Bitmap(img);
            this.curBitmap = new Bitmap(img);
            this.bitmapInfo = bitmapInfo;
            img.Dispose();
        }

        private Bitmap preBitmap;
        private Bitmap curBitmap;
        private MyBitmapInfo bitmapInfo;

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

    }
}
