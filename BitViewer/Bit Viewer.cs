using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace BitViewer
{
    public partial class Form1 : Form
    {
        BitArray gBits = null;
        uint BASIC_BORDER_SIZE = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadBits_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                gBits = new BitArray(File.ReadAllBytes(openFileDialog1.FileName));
                RefreshBMP();
            }

        }

        private void RefreshBMP()
        {
            if ((gBits == null) || (readFileOffset.Value >= gBits.Length))
            {
                // nothing to show
                ImagePanel.BackgroundImage = new Bitmap(1, 1);
                return;
            }

            // set cursor to waiting
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            uint bitSizeInPixels = (uint)bitSize.Value;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // configure the scroll bars
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            uint visibleBitsPerLine = (uint)ImagePanel.Width / (BASIC_BORDER_SIZE + bitSizeInPixels);
            uint visibleNumLines = (uint)ImagePanel.Height / (BASIC_BORDER_SIZE + (uint)bitSize.Value);

            uint bitsPerLine = (uint)FrameSize1.Value * (uint)FrameSize2.Value;
            uint numLines = ((uint)gBits.Length - (uint)readFileOffset.Value + bitsPerLine - 1) / bitsPerLine;

            // the maximum should be the number of bits we're not seeing
            if (numLines > visibleNumLines)
            {
                vScrollBar1.Maximum = (int)(numLines - visibleNumLines);
                vScrollBar1.Visible = true;
            }
            else
            {
                vScrollBar1.Visible = false;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Done with the scroll bars
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Bitmap bitsBitmap = new Bitmap(ImagePanel.Width, ImagePanel.Height);

            SolidBrush currentBitBrush = null;

            using (Graphics g = Graphics.FromImage(bitsBitmap))
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (SolidBrush grayBrush = new SolidBrush(Color.Gray))
            {
                g.FillRectangle(grayBrush, 0, 0, ImagePanel.Width, ImagePanel.Height);

                IEnumerator iterator = gBits.GetEnumerator();
                iterator.MoveNext(); // now points to the first element

                // skip bits as needed
                for (int i = 0; i < (readFileOffset.Value + bitsPerLine * vScrollBar1.Value); ++i)
                {
                    iterator.MoveNext();
                }

                // draw all them bits
                bool iterationEnded = false;
                for (int y = 0; y < visibleNumLines; ++y)
                {
                    if (iterationEnded)
                    {
                        break;
                    }
                    for (int x = 0; x < bitsPerLine; ++x)
                    {
                        // draw a pixel
                        if ((bool)iterator.Current)
                        {
                            currentBitBrush = blueBrush;
                        }
                        else
                        {
                            currentBitBrush = whiteBrush;
                        }

                        g.FillRectangle(currentBitBrush,
                                x * (bitSizeInPixels + BASIC_BORDER_SIZE),
                                y * (bitSizeInPixels + BASIC_BORDER_SIZE),
                                bitSizeInPixels,
                                bitSizeInPixels);

                        if (!iterator.MoveNext())
                        {
                            iterationEnded = true;
                            break;
                        }
                    }
                }
            }

            // set cursor to normal
            Cursor.Current = Cursors.Default;
            Application.DoEvents();

            // display image
            // ImagePanel.Height = (int)(numLines * bitSizeInPixels);
            // ImagePanel.Width = (int)(bitSizeInPixels * bitsPerLine);
            ImagePanel.BackgroundImage = bitsBitmap;
            
        }

        private void FrameSize1_ValueChanged(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void FrameSize2_ValueChanged(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void btnHeyLena_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOW THAT THE CODE CHANGED, WHAT SHOULD THIS BUTTON DO?", "OH NO");
            return;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                // Stream st = new MemoryStream(File.ReadAllBytes(openFileDialog1.FileName));
                // BitsPicture.Image = new Bitmap(st);
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            RefreshBMP();
        }

    }
}
