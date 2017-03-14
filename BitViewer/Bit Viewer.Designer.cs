using System.Windows.Forms;
namespace BitViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FrameSize1 = new System.Windows.Forms.NumericUpDown();
            this.FrameSize2 = new System.Windows.Forms.NumericUpDown();
            this.LoadBitsButton = new System.Windows.Forms.Button();
            this.bitSize = new System.Windows.Forms.NumericUpDown();
            this.ImagePanel = new BitViewer.DoubleBufferedPanel();
            this.readFileOffset = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.lblTotalFrameSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameSize1
            // 
            this.FrameSize1.Location = new System.Drawing.Point(114, 21);
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
            this.FrameSize1.Size = new System.Drawing.Size(60, 22);
            this.FrameSize1.TabIndex = 3;
            this.FrameSize1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.FrameSize1.ValueChanged += new System.EventHandler(this.FrameSize1_ValueChanged);
            // 
            // FrameSize2
            // 
            this.FrameSize2.Location = new System.Drawing.Point(201, 21);
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
            this.FrameSize2.Size = new System.Drawing.Size(60, 22);
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
            this.LoadBitsButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadBitsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadBitsButton.BackgroundImage")));
            this.LoadBitsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadBitsButton.FlatAppearance.BorderSize = 0;
            this.LoadBitsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBitsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadBitsButton.Location = new System.Drawing.Point(40, 11);
            this.LoadBitsButton.Name = "LoadBitsButton";
            this.LoadBitsButton.Size = new System.Drawing.Size(34, 33);
            this.LoadBitsButton.TabIndex = 5;
            this.LoadBitsButton.UseVisualStyleBackColor = false;
            this.LoadBitsButton.Click += new System.EventHandler(this.LoadBits_Click);
            // 
            // bitSize
            // 
            this.bitSize.Location = new System.Drawing.Point(369, 21);
            this.bitSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.bitSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.bitSize.Name = "bitSize";
            this.bitSize.Size = new System.Drawing.Size(60, 22);
            this.bitSize.TabIndex = 6;
            this.bitSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bitSize.ValueChanged += new System.EventHandler(this.BitSize_Changed);
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.ImagePanel.Location = new System.Drawing.Point(0, 48);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1699, 832);
            this.ImagePanel.TabIndex = 7;
            this.ImagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);
            this.ImagePanel.MouseEnter += new System.EventHandler(this.ImagePanel_MouseEnter);
            this.ImagePanel.MouseWheel += new MouseEventHandler(this.ImagePanel_MouseWheel); 
            // 
            // readFileOffset
            // 
            this.readFileOffset.Location = new System.Drawing.Point(454, 21);
            this.readFileOffset.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.readFileOffset.Name = "readFileOffset";
            this.readFileOffset.Size = new System.Drawing.Size(60, 22);
            this.readFileOffset.TabIndex = 9;
            this.readFileOffset.ValueChanged += new System.EventHandler(this.ChopChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bit Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Frame Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Chop:";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(1702, 48);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 458);
            this.vScrollBar1.TabIndex = 14;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1_ValueChanged);
            // 
            // lblTotalFrameSize
            // 
            this.lblTotalFrameSize.AutoSize = true;
            this.lblTotalFrameSize.Location = new System.Drawing.Point(267, 25);
            this.lblTotalFrameSize.Name = "lblTotalFrameSize";
            this.lblTotalFrameSize.Size = new System.Drawing.Size(45, 14);
            this.lblTotalFrameSize.TabIndex = 15;
            this.lblTotalFrameSize.Text = "Lorem";
            this.lblTotalFrameSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "X";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1720, 508);
            this.Controls.Add(this.LoadBitsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalFrameSize);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readFileOffset);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.bitSize);
            this.Controls.Add(this.FrameSize2);
            this.Controls.Add(this.FrameSize1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Manta Bite";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown FrameSize1;
        private NumericUpDown FrameSize2;
        private Button LoadBitsButton;
        private NumericUpDown bitSize;
        private DoubleBufferedPanel ImagePanel;
        private NumericUpDown readFileOffset;
        private Label label1;
        private Label label2;
        private Label label3;
        private VScrollBar vScrollBar1;
        private Label lblTotalFrameSize;
		private Label label4;
	}

	public class DoubleBufferedPanel : Panel
	{
		public DoubleBufferedPanel()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
		}
	}

}

