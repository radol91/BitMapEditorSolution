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
        private enum Implement{ ASEMBLER, C__SHARP };
        private enum Action { BMP_INVERSE, BMP__SHARPEN, BMP_GREYSCALE };
        private enum State { RUNNING = 0, READY = 1 }
        string[] StateStrings = { "Operacja w toku...", "Gotowe." };
        private List<TimeResult> listTimeResult;
        private Action action;
        private Implement impl;

        delegate void runBackgroundFunc(MyBitmap myBitmap);
        private runBackgroundFunc rb;

        public MainForm()
        {
            InitializeComponent();
            progressBar.Step = 1;
            progressBar.Maximum = 100;
            formViewer = new FormViewer();
            bmpManager = new BitmapManager();
            stopwatch = new Stopwatch();
            listTimeResult = new List<TimeResult>();
        }


        private void otwórzPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
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
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy || myBitmap != null)
            {
                bmpManager.saveBitmap(myBitmap);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy || myBitmap != null)
            {
                bmpManager.saveBitmapAs(myBitmap);
            }
        }

        private void bInvert_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                action = Action.BMP_INVERSE;
                startAction(rbAsm.Checked);
            }
        }

        private void b_GreyScale(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                action = Action.BMP_GREYSCALE;
                startAction(rbAsm.Checked);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myBitmap != null)
            {
                action = Action.BMP__SHARPEN;
                startAction(rbAsm.Checked);
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
            funcState.Text = StateStrings[(int)State.RUNNING];
            if (!backgroundWorker.IsBusy || myBitmap != null)
            {
                bmpManager.BitMapEditor.goBack(myBitmap);
                formViewer.showBitmap(myBitmap.CurrentBitmap, pictureBox2);
            }
            funcState.Text = StateStrings[(int)State.READY];
        }

        private void startAction(bool isAsmEnable)
        {
            funcState.Text = StateStrings[(int)State.RUNNING];
            if (!backgroundWorker.IsBusy)
            {
                stopwatch.Reset();
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
                            rb = bmpManager.BitMapEditor.inverseBitmap;
                            break;
                        case Action.BMP_GREYSCALE:
                            rb = bmpManager.BitMapEditor.grayScale;
                            break;
                        case Action.BMP__SHARPEN:
                            rb = bmpManager.BitMapEditor.sharpenBitmap;
                            break;
                    }
                }
                backgroundWorker.RunWorkerAsync(myBitmap);
            }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Value = 0;
            stopwatch.Start();
            rb(myBitmap);
            stopwatch.Stop();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = progressBar.Maximum;
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
            backgroundWorker.CancelAsync();
            funcState.Text = StateStrings[(int)State.READY];
        }


    }
}
