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
        BitArray gBits;
        uint BASIC_GRID_SIZE = 10;

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
            if (readFileOffset.Value >= gBits.Length)
            {
                // nothing to show
                BitsPicture.Image = new Bitmap(1, 1);
                return;
            }

            // set cursor to waiting
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();


            uint bitsPerLine = (uint)FrameSize1.Value * (uint)FrameSize2.Value;
            uint numLines = ((uint)gBits.Length - (uint)readFileOffset.Value + bitsPerLine - 1) / bitsPerLine;
            uint bitSizeInPixels = BASIC_GRID_SIZE * (uint)bitSize.Value;

            Bitmap bitsBitmap = new Bitmap((int)bitsPerLine, (int)numLines);
            
            using (Graphics g = Graphics.FromImage(bitsBitmap))
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                IEnumerator iterator = gBits.GetEnumerator();
                iterator.MoveNext(); // now points to the first element

                // skip bits as needed
                for (int i = 0; i < readFileOffset.Value; ++i)
                {
                    iterator.MoveNext();
                }

                // read all the complete lines (except the last, possibly incomplete, line)
                for (int y = 0; y < (numLines - 1); ++y)
                {
                    for (int x = 0; x < bitsPerLine; ++x)
                    {
                        if ((bool)iterator.Current)
                        {
                            // draw a pixel
                            g.FillRectangle(blueBrush, x, y, 1, 1);
                        }

                        iterator.MoveNext();
                    }
                }

                // read the last, possibly incomplete, line
                for (int x = 0; x < (gBits.Length % bitsPerLine); ++x)
                {
                    if ((bool)iterator.Current)
                    {
                        // draw a pixel
                        g.FillRectangle(blueBrush, x, numLines - 1, 1, 1);
                    }

                    if (!iterator.MoveNext())
                    {
                        break;
                    }
                }
            }

            // set cursor to normal
            Cursor.Current = Cursors.Default;
            Application.DoEvents();

            // display image
            BitsPicture.Height = (int)(numLines * bitSizeInPixels);
            BitsPicture.Width = (int)(bitSizeInPixels * bitsPerLine);
            BitsPicture.Image = bitsBitmap;
            
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                Stream st = new MemoryStream(File.ReadAllBytes(openFileDialog1.FileName));
                BitsPicture.Image = new Bitmap(st);
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            RefreshBMP();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BitsPicture_LocationChanged(object sender, EventArgs e)
        {

        }

    }
}
