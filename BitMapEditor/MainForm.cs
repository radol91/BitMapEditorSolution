using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace BitMapEditor
{
    public partial class MainForm : Form
    {
        private MyBitmap myBitmap;
        private BitmapManager bmpManager;
        private FormViewer formViewer;
        private Stopwatch stopwatch;
        internal enum Implement{ ASEMBLER, C__SHARP };
        internal enum Action { ____INVERSE, ____SHARPEN, GREY_SCALE };
        private List<TimeResult> listTimeResult;
        private BackgroundWorker bW;

        public MainForm()
        {
            InitializeComponent();
            formViewer = new FormViewer();
            bmpManager = new BitmapManager();
            stopwatch = new Stopwatch();
            listTimeResult = new List<TimeResult>();
            bW = new BackgroundWorker();
            bW.RunWorkerAsync();
            progressBar2.Maximum = 100;
            progressBar2.Step = 1;
        }

        private void otwórzPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myBitmap = bmpManager.openImage();
            if (myBitmap != null)
            {
                formViewer.showBitmap(myBitmap.PreviousBitmap, pictureBox1);
                formViewer.showBitmap(myBitmap.CurrentBitmap, pictureBox2);
                formViewer.updateLabel(myBitmap.BitmapInfo.Path, labPath);
                formViewer.updateLabel(myBitmap.BitmapInfo.SizeX + " x " + myBitmap.BitmapInfo.SizeY, labRes);
            }
        
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                bmpManager.saveBitmap(myBitmap);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                bmpManager.saveBitmapAs(myBitmap);
            }
        }

        private void bInvert_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                startAction(Action.____INVERSE, rbAsm.Checked);
            }
        }

        private void b_GreyScale(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                startAction(Action.GREY_SCALE, rbAsm.Checked);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                startAction(Action.____SHARPEN, rbAsm.Checked);
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Radosław Migdał\nGrupa V","O mnie...",MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                bmpManager.BitMapEditor.goBack(myBitmap);
                formViewer.showBitmap(myBitmap.CurrentBitmap, pictureBox2);
            }
        }

        private void startAction(Action action, bool isAsmEnable)
        {
            Implement impl;
            stopwatch.Reset();
            stopwatch.Start();
            if (isAsmEnable)
            {
                impl = Implement.ASEMBLER;
                switch (action)
                {
                    case Action.____INVERSE:
                        break;
                    case Action.GREY_SCALE:                       
                        break;
                    case Action.____SHARPEN:
                        break;
                }
            }
            else
            {
                impl = Implement.C__SHARP;
                switch (action)
                {
                    case Action.____INVERSE:
                        bmpManager.BitMapEditor.inverseBitmap(myBitmap);
                        break;
                    case Action.GREY_SCALE:
                        bmpManager.BitMapEditor.grayScale(myBitmap);
                        break;
                    case Action.____SHARPEN:
                        bmpManager.BitMapEditor.sharpenBitmap(myBitmap);
                        break;
                }
            }
            stopwatch.Stop();

            listTimeResult.Add(new TimeResult(impl.ToString(), 
                                    action.ToString(), 
                                    stopwatch.Elapsed.Seconds,
                                    stopwatch.Elapsed.Milliseconds,
                                    myBitmap.BitmapInfo.SizeX,
                                    myBitmap.BitmapInfo.SizeY));
            timeLabel.Text = stopwatch.Elapsed.Seconds.ToString() + "." + stopwatch.Elapsed.Milliseconds.ToString();
            statusStrip1.Refresh();
            formViewer.showBitmap(myBitmap.CurrentBitmap, pictureBox2);
            formViewer.updateListBox(listBox1, listTimeResult);
        }

        private void tabelaCzasówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible)
                listBox1.Visible = false;
            else
                listBox1.Visible = true;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(100);
                // Report progress.
                backgroundWorker.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }
          
    }
}
