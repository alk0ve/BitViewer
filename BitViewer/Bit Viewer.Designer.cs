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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FrameSize1 = new System.Windows.Forms.NumericUpDown();
            this.FrameSize2 = new System.Windows.Forms.NumericUpDown();
            this.LoadBitsButton = new System.Windows.Forms.Button();
            this.bitSize = new System.Windows.Forms.NumericUpDown();
            this.ImagePanel = new BitViewer.DoubleBufferedPanel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.readFileOffset = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalFrameSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Sort = new System.Windows.Forms.Button();
            this.sortStart = new System.Windows.Forms.NumericUpDown();
            this.sortEnd = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).BeginInit();
            this.ImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortEnd)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameSize1
            // 
            this.FrameSize1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrameSize1.AutoSize = true;
            this.FrameSize1.Location = new System.Drawing.Point(113, 43);
            this.FrameSize1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.FrameSize1.Size = new System.Drawing.Size(88, 22);
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
            this.FrameSize2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrameSize2.AutoSize = true;
            this.FrameSize2.Location = new System.Drawing.Point(227, 43);
            this.FrameSize2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.FrameSize2.Size = new System.Drawing.Size(90, 22);
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
            this.LoadBitsButton.AutoSize = true;
            this.LoadBitsButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadBitsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadBitsButton.BackgroundImage")));
            this.LoadBitsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoadBitsButton.FlatAppearance.BorderSize = 0;
            this.LoadBitsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBitsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadBitsButton.Location = new System.Drawing.Point(2, 3);
            this.LoadBitsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LoadBitsButton.Name = "LoadBitsButton";
            this.tableLayoutPanel1.SetRowSpan(this.LoadBitsButton, 2);
            this.LoadBitsButton.Size = new System.Drawing.Size(100, 74);
            this.LoadBitsButton.TabIndex = 5;
            this.LoadBitsButton.UseVisualStyleBackColor = false;
            this.LoadBitsButton.Click += new System.EventHandler(this.LoadBits_Click);
            // 
            // bitSize
            // 
            this.bitSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bitSize.Location = new System.Drawing.Point(549, 43);
            this.bitSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bitSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.bitSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bitSize.Name = "bitSize";
            this.bitSize.Size = new System.Drawing.Size(109, 22);
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
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.AutoSize = true;
            this.ImagePanel.BackColor = System.Drawing.Color.Transparent;
            this.ImagePanel.Controls.Add(this.hScrollBar1);
            this.ImagePanel.Controls.Add(this.vScrollBar1);
            this.ImagePanel.Location = new System.Drawing.Point(0, 80);
            this.ImagePanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(960, 452);
            this.ImagePanel.TabIndex = 0;
            this.ImagePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImagePanel_MouseClick);
            this.ImagePanel.MouseEnter += new System.EventHandler(this.ImagePanel_MouseEnter);
            this.ImagePanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ImagePanel_MouseWheel);
            this.ImagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 434);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(942, 18);
            this.hScrollBar1.TabIndex = 21;
            this.hScrollBar1.Visible = false;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.HScrollBar1_ValueChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(942, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 452);
            this.vScrollBar1.TabIndex = 14;
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1_ValueChanged);
            // 
            // readFileOffset
            // 
            this.readFileOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.readFileOffset.Location = new System.Drawing.Point(678, 43);
            this.readFileOffset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.readFileOffset.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.readFileOffset.Name = "readFileOffset";
            this.readFileOffset.Size = new System.Drawing.Size(96, 22);
            this.readFileOffset.TabIndex = 9;
            this.readFileOffset.ValueChanged += new System.EventHandler(this.ChopChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bit Size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(113, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Frame Size:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Chop:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTotalFrameSize
            // 
            this.lblTotalFrameSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalFrameSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalFrameSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalFrameSize.Location = new System.Drawing.Point(319, 40);
            this.lblTotalFrameSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalFrameSize.Name = "lblTotalFrameSize";
            this.lblTotalFrameSize.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblTotalFrameSize.Size = new System.Drawing.Size(97, 40);
            this.lblTotalFrameSize.TabIndex = 15;
            this.lblTotalFrameSize.Text = "Lorem";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(205, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(18, 40);
            this.label4.TabIndex = 16;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Sort
            // 
            this.Sort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Sort, 2);
            this.Sort.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sort.ForeColor = System.Drawing.Color.Black;
            this.Sort.Location = new System.Drawing.Point(827, 3);
            this.Sort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(136, 34);
            this.Sort.TabIndex = 17;
            this.Sort.Text = "SORT";
            this.Sort.UseVisualStyleBackColor = true;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // sortStart
            // 
            this.sortStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortStart.Location = new System.Drawing.Point(827, 43);
            this.sortStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sortStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sortStart.Name = "sortStart";
            this.sortStart.Size = new System.Drawing.Size(64, 22);
            this.sortStart.TabIndex = 18;
            this.sortStart.ValueChanged += new System.EventHandler(this.sortStart_ValueChanged);
            // 
            // sortEnd
            // 
            this.sortEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortEnd.AutoSize = true;
            this.sortEnd.Location = new System.Drawing.Point(895, 43);
            this.sortEnd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sortEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sortEnd.Name = "sortEnd";
            this.sortEnd.Size = new System.Drawing.Size(68, 22);
            this.sortEnd.TabIndex = 19;
            this.sortEnd.ValueChanged += new System.EventHandler(this.sortEnd_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.51188F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.632604F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.29068F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.80881F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.67036F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41293F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.5252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.071741F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.075788F));
            this.tableLayoutPanel1.Controls.Add(this.LoadBitsButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sortEnd, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.sortStart, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.Sort, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.FrameSize2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.readFileOffset, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalFrameSize, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.bitSize, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.FrameSize1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 80);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(959, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ImagePanel);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(600, 80);
            this.Name = "MainForm";
            this.Text = "Lorem Ipsum";
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitSize)).EndInit();
            this.ImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.readFileOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortEnd)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private Button Sort;
        private NumericUpDown sortStart;
        private NumericUpDown sortEnd;
        private HScrollBar hScrollBar1;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolTip toolTip1;
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

