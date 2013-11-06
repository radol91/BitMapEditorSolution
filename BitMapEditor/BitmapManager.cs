using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BitMapEditor
{
    class BitmapManager
    {
        public BitmapManager()
        {
            this.bitmapEditor = new MyBitmapEditor();
        }

        private MyBitmapEditor bitmapEditor;
        public MyBitmapEditor BitMapEditor{
            get
            {
                return bitmapEditor;
            }
        }

        public MyBitmap openImage(){
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "Plik graficzny (*.bmp)|*.BMP; *.bmp";
            openDialog.FileName = "*.bmp";
            openDialog.ShowDialog();

            if (openDialog.FileName != "*.bmp")
            {
                Image image = Image.FromFile(openDialog.FileName);

                MyBitmapInfo mbi = new MyBitmapInfo(image, openDialog.FileName);
                openDialog.Dispose();
                return new MyBitmap(image, mbi);
            }
            return null;
        }
        
        public void saveBitmap(MyBitmap myBitmap)
        {
            if (myBitmap != null)
            {
                DialogResult result1 = MessageBox.Show("Czy chcesz nadpisać istniejący plik: \n" + myBitmap.BitmapInfo.Path,
                        "Zapisz", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result1 == DialogResult.Yes)
                {
                    myBitmap.CurrentBitmap.Save(myBitmap.BitmapInfo.Path);
                }
            }
        }

        public void saveBitmapAs(MyBitmap myBitmap)
        {
            if (myBitmap != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "moj_plik";
                saveDialog.Filter = "Plik graficzny (*.bmp)|*.BMP; *.bmp";
                saveDialog.ShowDialog();
                myBitmap.CurrentBitmap.Save(saveDialog.FileName);
                saveDialog.Dispose();
            }
        }
    }
}
