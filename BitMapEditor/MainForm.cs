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
        internal enum Action { BMP_INVERSE, BMP__SHARPEN, BMP_GREYSCALE };
        private List<TimeResult> listTimeResult;

        public MainForm()
        {
            InitializeComponent();
            progressBar2.Step = 1;
            progressBar2.Maximum = 100;
            formViewer = new FormViewer();
            bmpManager = new BitmapManager();
            stopwatch = new Stopwatch();
            listTimeResult = new List<TimeResult>();
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
                startAction(Action.BMP_INVERSE, rbAsm.Checked);
            }
        }

        private void b_GreyScale(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                startAction(Action.BMP_GREYSCALE, rbAsm.Checked);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                startAction(Action.BMP__SHARPEN, rbAsm.Checked);
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
            progressBar2.Value = 0;
            Implement impl;
            stopwatch.Reset();
            stopwatch.Start();
            if (isAsmEnable)
            {
                impl = Implement.ASEMBLER;
                switch (action)
                {
                    case Action.BMP_INVERSE:
                        break;
                    case Action.BMP_GREYSCALE:                       
                        break;
                    case Action.BMP__SHARPEN:
                        break;
                }
            }
            else
            {
                impl = Implement.C__SHARP;
                switch (action)
                {
                    case Action.BMP_INVERSE:
                        bmpManager.BitMapEditor.inverseBitmap(myBitmap);
                        break;
                    case Action.BMP_GREYSCALE:
                        bmpManager.BitMapEditor.grayScale(myBitmap);
                        break;
                    case Action.BMP__SHARPEN:
                        bmpManager.BitMapEditor.sharpenBitmap(myBitmap);
                        break;
                        
                }
            }
            stopwatch.Stop();
            progressBar2.Value = progressBar2.Maximum;
            listTimeResult.Add(new TimeResult(impl.ToString(), 
                                    action.ToString(), 
                                    stopwatch.Elapsed.Seconds,
                                    stopwatch.Elapsed.Milliseconds,
                                    myBitmap.BitmapInfo.SizeX,
                                    myBitmap.BitmapInfo.SizeY));
            timeLabel.Text = stopwatch.Elapsed.Seconds.ToString() + "." + TimeResult.convertMilis(stopwatch.Elapsed.Milliseconds);
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

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbCpp.Checked = true;
        }

        private void asemblerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rbAsm.Checked = true;
        }
    }
}
