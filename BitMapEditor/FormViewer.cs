using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BitMapEditor
{
    class FormViewer
    {
        public void showBitmap(Bitmap bmp, PictureBox picBox)
        {
            picBox.Image = scaleBitmap(bmp,picBox);
        }

        public void updateLabel(String strValue, Label label)
        {
            label.Text = strValue;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private Bitmap scaleBitmap(Bitmap bmp, PictureBox picBox)
        {

            float ratio = 1.0f;
            int thumbHeight = 0;
            int thumbWidth = 0;

            if (bmp.Height > picBox.Height || bmp.Width > picBox.Width)
            {
                Image.GetThumbnailImageAbort myCallback =
                    new Image.GetThumbnailImageAbort(ThumbnailCallback);

                if (bmp.Height >= bmp.Width)
                {
                    ratio = (((float)bmp.Width) / ((float)bmp.Height));
                    thumbHeight = picBox.Height;
                    thumbWidth = (int)((thumbHeight) * (ratio));
                }
                else
                {
                    ratio = (((float)bmp.Height) / ((float)bmp.Width));
                    thumbWidth = picBox.Width;
                    thumbHeight = (int)((thumbWidth) * (ratio));
                }

                Image myThumbnail = bmp.GetThumbnailImage(thumbWidth, thumbHeight, myCallback, IntPtr.Zero);
                return new Bitmap(myThumbnail);
            }
            return bmp;
        }

        public void updateListBox(ListBox listBox1, List<TimeResult> listTimeResult)
        {
            String item = null;
            listBox1.Items.Clear();

            foreach (TimeResult listItem in listTimeResult)
            {
                item = listItem.Implementation + "   " + listItem.FunctionName + "   " + listItem.Seconds + "." + listItem.strMilis
                    + " sec.   " + listItem.Width + " x " + listItem.Height;
                listBox1.Items.Add(item);
            }
        }
    }
}
