namespace BitMapEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzPlikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cofnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.implementacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaCzasówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.labRes = new System.Windows.Forms.Label();
            this.labResName = new System.Windows.Forms.Label();
            this.labPath = new System.Windows.Forms.Label();
            this.labPathName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupImpl = new System.Windows.Forms.GroupBox();
            this.rbCpp = new System.Windows.Forms.RadioButton();
            this.rbAsm = new System.Windows.Forms.RadioButton();
            this.groupOperacje = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.groupImpl.SuspendLayout();
            this.groupOperacje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bInvert_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaToolStripMenuItem,
            this.implementacjaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzPlikToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            resources.ApplyResources(this.plikToolStripMenuItem, "plikToolStripMenuItem");
            // 
            // otwórzPlikToolStripMenuItem
            // 
            resources.ApplyResources(this.otwórzPlikToolStripMenuItem, "otwórzPlikToolStripMenuItem");
            this.otwórzPlikToolStripMenuItem.Name = "otwórzPlikToolStripMenuItem";
            this.otwórzPlikToolStripMenuItem.Click += new System.EventHandler(this.otwórzPlikToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            resources.ApplyResources(this.zapiszToolStripMenuItem, "zapiszToolStripMenuItem");
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zapiszJakoToolStripMenuItem
            // 
            resources.ApplyResources(this.zapiszJakoToolStripMenuItem, "zapiszJakoToolStripMenuItem");
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            this.zapiszJakoToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            resources.ApplyResources(this.zamknijToolStripMenuItem, "zamknijToolStripMenuItem");
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cofnijToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            resources.ApplyResources(this.edycjaToolStripMenuItem, "edycjaToolStripMenuItem");
            // 
            // cofnijToolStripMenuItem
            // 
            this.cofnijToolStripMenuItem.Name = "cofnijToolStripMenuItem";
            resources.ApplyResources(this.cofnijToolStripMenuItem, "cofnijToolStripMenuItem");
            this.cofnijToolStripMenuItem.Click += new System.EventHandler(this.cofnijToolStripMenuItem_Click);
            // 
            // implementacjaToolStripMenuItem
            // 
            this.implementacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.asemblerToolStripMenuItem,
            this.tabelaCzasówToolStripMenuItem});
            this.implementacjaToolStripMenuItem.Name = "implementacjaToolStripMenuItem";
            resources.ApplyResources(this.implementacjaToolStripMenuItem, "implementacjaToolStripMenuItem");
            // 
            // cToolStripMenuItem
            // 
            resources.ApplyResources(this.cToolStripMenuItem, "cToolStripMenuItem");
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            // 
            // asemblerToolStripMenuItem
            // 
            resources.ApplyResources(this.asemblerToolStripMenuItem, "asemblerToolStripMenuItem");
            this.asemblerToolStripMenuItem.Name = "asemblerToolStripMenuItem";
            // 
            // tabelaCzasówToolStripMenuItem
            // 
            this.tabelaCzasówToolStripMenuItem.Name = "tabelaCzasówToolStripMenuItem";
            resources.ApplyResources(this.tabelaCzasówToolStripMenuItem, "tabelaCzasówToolStripMenuItem");
            this.tabelaCzasówToolStripMenuItem.Click += new System.EventHandler(this.tabelaCzasówToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            resources.ApplyResources(this.pomocToolStripMenuItem, "pomocToolStripMenuItem");
            // 
            // infoToolStripMenuItem
            // 
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.timeLabel,
            this.toolStripStatusLabel2});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            resources.ApplyResources(this.timeLabel, "timeLabel");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.labRes);
            this.groupInfo.Controls.Add(this.labResName);
            this.groupInfo.Controls.Add(this.labPath);
            this.groupInfo.Controls.Add(this.labPathName);
            this.groupInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.groupInfo, "groupInfo");
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.TabStop = false;
            // 
            // labRes
            // 
            resources.ApplyResources(this.labRes, "labRes");
            this.labRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labRes.Name = "labRes";
            // 
            // labResName
            // 
            resources.ApplyResources(this.labResName, "labResName");
            this.labResName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labResName.Name = "labResName";
            // 
            // labPath
            // 
            resources.ApplyResources(this.labPath, "labPath");
            this.labPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labPath.Name = "labPath";
            // 
            // labPathName
            // 
            resources.ApplyResources(this.labPathName, "labPathName");
            this.labPathName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labPathName.Name = "labPathName";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.b_GreyScale);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupImpl
            // 
            this.groupImpl.Controls.Add(this.rbCpp);
            this.groupImpl.Controls.Add(this.rbAsm);
            this.groupImpl.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.groupImpl, "groupImpl");
            this.groupImpl.Name = "groupImpl";
            this.groupImpl.TabStop = false;
            // 
            // rbCpp
            // 
            resources.ApplyResources(this.rbCpp, "rbCpp");
            this.rbCpp.ForeColor = System.Drawing.SystemColors.InfoText;
            this.rbCpp.Name = "rbCpp";
            this.rbCpp.TabStop = true;
            this.rbCpp.UseVisualStyleBackColor = true;
            // 
            // rbAsm
            // 
            resources.ApplyResources(this.rbAsm, "rbAsm");
            this.rbAsm.ForeColor = System.Drawing.SystemColors.InfoText;
            this.rbAsm.Name = "rbAsm";
            this.rbAsm.TabStop = true;
            this.rbAsm.UseVisualStyleBackColor = true;
            // 
            // groupOperacje
            // 
            this.groupOperacje.Controls.Add(this.button1);
            this.groupOperacje.Controls.Add(this.button2);
            this.groupOperacje.Controls.Add(this.button3);
            this.groupOperacje.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.groupOperacje, "groupOperacje");
            this.groupOperacje.Name = "groupOperacje";
            this.groupOperacje.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            // 
            // progressBar2
            // 
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Step = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupOperacje);
            this.Controls.Add(this.groupImpl);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupImpl.ResumeLayout(false);
            this.groupImpl.PerformLayout();
            this.groupOperacje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem implementacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupImpl;
        private System.Windows.Forms.GroupBox groupOperacje;
        private System.Windows.Forms.RadioButton rbCpp;
        private System.Windows.Forms.RadioButton rbAsm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem otwórzPlikToolStripMenuItem;
        private System.Windows.Forms.Label labPathName;
        private System.Windows.Forms.Label labPath;
        private System.Windows.Forms.Label labRes;
        private System.Windows.Forms.Label labResName;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cofnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem tabelaCzasówToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

