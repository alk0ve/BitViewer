namespace BitViewer
{
    
    partial class Form1
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
        public class PictureBoxWithInterpolationMode : System.Windows.Forms.PictureBox
        {
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs paintEventArgs)
            {
                paintEventArgs.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                base.OnPaint(paintEventArgs);
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BitsPicture = new BitViewer.Form1.PictureBoxWithInterpolationMode();
            this.FrameSize1 = new System.Windows.Forms.NumericUpDown();
            this.FrameSize2 = new System.Windows.Forms.NumericUpDown();
            this.LoadBitsButton = new System.Windows.Forms.Button();
            this.bitSize = new System.Windows.Forms.NumericUpDown();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.btnHeyLena = new System.Windows.Forms.Button();
            this.readFileOffset = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IsRev = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BitsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).BeginInit();
            this.ImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // BitsPicture
            // 
            this.BitsPicture.BackColor = System.Drawing.Color.SeaShell;
            this.BitsPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.BitsPicture.Location = new System.Drawing.Point(4, 4);
            this.BitsPicture.Name = "BitsPicture";
            this.BitsPicture.Size = new System.Drawing.Size(1473, 780);
            this.BitsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BitsPicture.TabIndex = 0;
            this.BitsPicture.TabStop = false;
            this.BitsPicture.Click += new System.EventHandler(this.BitsPicture_Click);
            // 
            // FrameSize1
            // 
            this.FrameSize1.Location = new System.Drawing.Point(12, 19);
            this.FrameSize1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.FrameSize1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrameSize1.Name = "FrameSize1";
            this.FrameSize1.Size = new System.Drawing.Size(120, 20);
            this.FrameSize1.TabIndex = 3;
            this.FrameSize1.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.FrameSize1.ValueChanged += new System.EventHandler(this.FrameSize1_ValueChanged);
            // 
            // FrameSize2
            // 
            this.FrameSize2.Location = new System.Drawing.Point(138, 19);
            this.FrameSize2.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.FrameSize2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrameSize2.Name = "FrameSize2";
            this.FrameSize2.Size = new System.Drawing.Size(120, 20);
            this.FrameSize2.TabIndex = 4;
            this.FrameSize2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrameSize2.ValueChanged += new System.EventHandler(this.FrameSize2_ValueChanged);
            // 
            // LoadBitsButton
            // 
            this.LoadBitsButton.Location = new System.Drawing.Point(274, 12);
            this.LoadBitsButton.Name = "LoadBitsButton";
            this.LoadBitsButton.Size = new System.Drawing.Size(115, 31);
            this.LoadBitsButton.TabIndex = 5;
            this.LoadBitsButton.Text = "Load Bits From File";
            this.LoadBitsButton.UseVisualStyleBackColor = true;
            this.LoadBitsButton.Click += new System.EventHandler(this.LoadBits_Click);
            // 
            // bitSize
            // 
            this.bitSize.Location = new System.Drawing.Point(519, 19);
            this.bitSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.bitSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bitSize.Name = "bitSize";
            this.bitSize.Size = new System.Drawing.Size(63, 20);
            this.bitSize.TabIndex = 6;
            this.bitSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bitSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.Color.SeaShell;
            this.ImagePanel.Controls.Add(this.BitsPicture);
            this.ImagePanel.Location = new System.Drawing.Point(0, 45);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1474, 771);
            this.ImagePanel.TabIndex = 7;
            // 
            // btnHeyLena
            // 
            this.btnHeyLena.Location = new System.Drawing.Point(642, 19);
            this.btnHeyLena.Name = "btnHeyLena";
            this.btnHeyLena.Size = new System.Drawing.Size(293, 20);
            this.btnHeyLena.TabIndex = 8;
            this.btnHeyLena.Text = "Hey Lena I don\'t remember what that button does";
            this.btnHeyLena.UseVisualStyleBackColor = true;
            this.btnHeyLena.Click += new System.EventHandler(this.btnHeyLena_Click);
            // 
            // readFileOffset
            // 
            this.readFileOffset.Location = new System.Drawing.Point(997, 19);
            this.readFileOffset.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.readFileOffset.Name = "readFileOffset";
            this.readFileOffset.Size = new System.Drawing.Size(120, 20);
            this.readFileOffset.TabIndex = 9;
            this.readFileOffset.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bit Size:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Frame Size          X            Frame Size";
            // 
            // IsRev
            // 
            this.IsRev.AutoSize = true;
            this.IsRev.Location = new System.Drawing.Point(408, 19);
            this.IsRev.Name = "IsRev";
            this.IsRev.Size = new System.Drawing.Size(89, 17);
            this.IsRev.TabIndex = 13;
            this.IsRev.Text = "Reverse Line";
            this.IsRev.UseVisualStyleBackColor = true;
            this.IsRev.CheckedChanged += new System.EventHandler(this.IsRev8_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(994, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Skip first bits:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 815);
            this.Controls.Add(this.IsRev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readFileOffset);
            this.Controls.Add(this.btnHeyLena);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.bitSize);
            this.Controls.Add(this.LoadBitsButton);
            this.Controls.Add(this.FrameSize2);
            this.Controls.Add(this.FrameSize1);
            this.Name = "Form1";
            this.Text = "BitViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BitsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).EndInit();
            this.ImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FrameSize1;
        private System.Windows.Forms.NumericUpDown FrameSize2;
        private System.Windows.Forms.Button LoadBitsButton;
        private System.Windows.Forms.NumericUpDown bitSize;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.Button btnHeyLena;
        private System.Windows.Forms.NumericUpDown readFileOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsRev;
        public Form1.PictureBoxWithInterpolationMode BitsPicture;
        private System.Windows.Forms.Label label3;
    }
}

