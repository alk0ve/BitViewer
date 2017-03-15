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


    public partial class MainForm : Form
    {
        List<BitArray> fileData = null;
        Bitmap bitsBitmap = null;
        string programName = "Manta Byte";

        uint BASIC_BORDER_SIZE = 1;

        public MainForm()
        {
            InitializeComponent();
            UpdateTotalFrameSize();
            this.Text = programName;

        }

        private void LoadBits_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                if (fileName.ToLower().EndsWith(".pcap"))
                {
                    fileData = GetPacketsFromPcap(fileName);
                }
                else
                {
                    fileData = GetRawBitsFromFile(fileName);
                }
                this.Text = String.Format("{0} - {1}", programName, fileName);
                PaintBits();

            }


        }
        private List<BitArray> GetPacketsFromPcap(string fileName)
        {
            // LV structure, first 6*4 bytes are global header, Then 4*4bytes packet header - the last 4bytes in the header are the actual length.
            byte[] bytesFromFile = File.ReadAllBytes(fileName);



            List<BitArray> fileData = new List<BitArray>();
            int index = 24;
            int currentPacketLength;
            while (index < bytesFromFile.Length)
            {
                Byte[] lengthFieldBytes = new Byte[4];
                Array.Copy(bytesFromFile, index + 12, lengthFieldBytes, 0, 4);
                //Array.Reverse(lengthFieldBytes);
                currentPacketLength = System.BitConverter.ToInt32(lengthFieldBytes, 0);
                Byte[] packetData = new Byte[currentPacketLength];
                Array.Copy(bytesFromFile, index + 16, packetData, 0, currentPacketLength);
                //rev8 all the bytes
                REV8(packetData);
                fileData.Add(new BitArray(packetData));
                index += currentPacketLength + 16;
            }
            return fileData;
        }

        private void REV8(byte[] arr)
        {
            byte[] BitReverseTable =
        {
            0x00, 0x80, 0x40, 0xc0, 0x20, 0xa0, 0x60, 0xe0,
            0x10, 0x90, 0x50, 0xd0, 0x30, 0xb0, 0x70, 0xf0,
            0x08, 0x88, 0x48, 0xc8, 0x28, 0xa8, 0x68, 0xe8,
            0x18, 0x98, 0x58, 0xd8, 0x38, 0xb8, 0x78, 0xf8,
            0x04, 0x84, 0x44, 0xc4, 0x24, 0xa4, 0x64, 0xe4,
            0x14, 0x94, 0x54, 0xd4, 0x34, 0xb4, 0x74, 0xf4,
            0x0c, 0x8c, 0x4c, 0xcc, 0x2c, 0xac, 0x6c, 0xec,
            0x1c, 0x9c, 0x5c, 0xdc, 0x3c, 0xbc, 0x7c, 0xfc,
            0x02, 0x82, 0x42, 0xc2, 0x22, 0xa2, 0x62, 0xe2,
            0x12, 0x92, 0x52, 0xd2, 0x32, 0xb2, 0x72, 0xf2,
            0x0a, 0x8a, 0x4a, 0xca, 0x2a, 0xaa, 0x6a, 0xea,
            0x1a, 0x9a, 0x5a, 0xda, 0x3a, 0xba, 0x7a, 0xfa,
            0x06, 0x86, 0x46, 0xc6, 0x26, 0xa6, 0x66, 0xe6,
            0x16, 0x96, 0x56, 0xd6, 0x36, 0xb6, 0x76, 0xf6,
            0x0e, 0x8e, 0x4e, 0xce, 0x2e, 0xae, 0x6e, 0xee,
            0x1e, 0x9e, 0x5e, 0xde, 0x3e, 0xbe, 0x7e, 0xfe,
            0x01, 0x81, 0x41, 0xc1, 0x21, 0xa1, 0x61, 0xe1,
            0x11, 0x91, 0x51, 0xd1, 0x31, 0xb1, 0x71, 0xf1,
            0x09, 0x89, 0x49, 0xc9, 0x29, 0xa9, 0x69, 0xe9,
            0x19, 0x99, 0x59, 0xd9, 0x39, 0xb9, 0x79, 0xf9,
            0x05, 0x85, 0x45, 0xc5, 0x25, 0xa5, 0x65, 0xe5,
            0x15, 0x95, 0x55, 0xd5, 0x35, 0xb5, 0x75, 0xf5,
            0x0d, 0x8d, 0x4d, 0xcd, 0x2d, 0xad, 0x6d, 0xed,
            0x1d, 0x9d, 0x5d, 0xdd, 0x3d, 0xbd, 0x7d, 0xfd,
            0x03, 0x83, 0x43, 0xc3, 0x23, 0xa3, 0x63, 0xe3,
            0x13, 0x93, 0x53, 0xd3, 0x33, 0xb3, 0x73, 0xf3,
            0x0b, 0x8b, 0x4b, 0xcb, 0x2b, 0xab, 0x6b, 0xeb,
            0x1b, 0x9b, 0x5b, 0xdb, 0x3b, 0xbb, 0x7b, 0xfb,
            0x07, 0x87, 0x47, 0xc7, 0x27, 0xa7, 0x67, 0xe7,
            0x17, 0x97, 0x57, 0xd7, 0x37, 0xb7, 0x77, 0xf7,
            0x0f, 0x8f, 0x4f, 0xcf, 0x2f, 0xaf, 0x6f, 0xef,
            0x1f, 0x9f, 0x5f, 0xdf, 0x3f, 0xbf, 0x7f, 0xff
        };
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = BitReverseTable[arr[i]];
            }
        }

        private List<BitArray> GetRawBitsFromFile(string fileName)
        {
            byte[] bytesFromFile = File.ReadAllBytes(fileName);

            // rev8 all the bytes
            REV8(bytesFromFile);
            List<BitArray> data = new List<BitArray>();
            data.Add(new BitArray(bytesFromFile));
            return data;
        }

        private void PaintBits()
        {
            decimal currentChop = readFileOffset.Value; // the chop value can change while drawing so we need a constant value for the painting process.
            uint currentFrameSize = (uint)FrameSize1.Value * (uint)FrameSize2.Value;
            if (fileData == null)
            {
                // nothing to show
                ImagePanel.BackgroundImage = new Bitmap(1, 1);
                return;
            }
            uint bitSizeInPixels = (uint)bitSize.Value;
            // set cursor to waiting
            Cursor.Current = Cursors.WaitCursor;
            int packetIndex = 0;
            while (packetIndex < fileData.Count && currentChop >= fileData.ElementAt(packetIndex).Length)
            {
                currentChop -= fileData.ElementAt(packetIndex).Length;
                packetIndex++;
            }
            // now the chop refers to the current packet only

            uint visibleBitsPerLine = (uint)ImagePanel.Width / (BASIC_BORDER_SIZE + bitSizeInPixels);
            uint visibleNumLines = (uint)ImagePanel.Height / (BASIC_BORDER_SIZE + (uint)bitSize.Value);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // configure the scroll bars
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            uint numLines = 0;
            for (int j = packetIndex; j < fileData.Count; j++)
                if (j == packetIndex)
                    numLines += ((uint)fileData.ElementAt(j).Length - (uint)currentChop + currentFrameSize - 1) / currentFrameSize;
                else
                    numLines += ((uint)fileData.ElementAt(j).Length + currentFrameSize - 1) / currentFrameSize;



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
            // Draw the currently visible bits
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (bitsBitmap != null) bitsBitmap.Dispose(); // added to prevent mem leaks of the Bitmap object
            bitsBitmap = new Bitmap(ImagePanel.Width, ImagePanel.Height);

            SolidBrush currentBitBrush = null;

            using (Graphics g = Graphics.FromImage(bitsBitmap))
            using (SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue))
            using (SolidBrush whiteBrush = new SolidBrush(Color.SeaShell))
            using (SolidBrush bgBrush = new SolidBrush(Color.Silver))
            using (SolidBrush redBrush = new SolidBrush(Color.Firebrick))
            {
                // draw background
                g.FillRectangle(bgBrush, 0, 0, ImagePanel.Width, ImagePanel.Height);

                // draw red lines between bytes
                for (int i = 1; i < ((Math.Min(visibleBitsPerLine, currentFrameSize) + 7) / 8); ++i)
                {
                    g.FillRectangle(redBrush, 8 * i * (bitSizeInPixels + BASIC_BORDER_SIZE) - BASIC_BORDER_SIZE,
                        0, 2, ImagePanel.Height);
                }


                // draw all them bits
                int index = (int)currentFrameSize * (int)vScrollBar1.Value;
                while (packetIndex < fileData.Count && index >= (fileData.ElementAt(packetIndex).Count - currentChop))
                {
                    int skippedBits = (int)fileData.ElementAt(packetIndex).Count - (int)currentChop;
                    int skippedLines = (int)Math.Ceiling((double)skippedBits / (int)currentFrameSize);
                    int skippedSlots = skippedLines * skippedBits;
                    index -= skippedLines * (int)currentFrameSize;
                    // we remove from the index all the lines we skipped, the bits we skipped + the empty slots remained in the line.
                    packetIndex++;
                    currentChop = 0;
                }
                index += (int)currentChop;
                if (packetIndex < fileData.Count)
                {
                    for (int y = 0; y < visibleNumLines; ++y)
                    {
                        if (index >= fileData.ElementAt(packetIndex).Count)
                        {
                            currentChop = 0;
                            index = 0;
                            packetIndex++;
                            if (packetIndex >= fileData.Count)
                                break;
                        }
                        for (int x = 0; x < currentFrameSize; ++x)
                        {
                            if (index >= fileData.ElementAt(packetIndex).Count)
                                break;
                            if (x < visibleBitsPerLine)
                            {
                                // draw a pixel
                                if (fileData.ElementAt(packetIndex)[index])
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
                            }
                            // else we don't draw the pixel
                            index++;
                        }
                    }
                }
            }



            // display image
            ImagePanel.BackgroundImage = bitsBitmap;
            // set cursor to normal
            Cursor.Current = Cursors.Default;
            //Application.DoEvents();
        }

        private void UpdateTotalFrameSize()
        {
            uint totalFrameSize = (uint)FrameSize1.Value * (uint)FrameSize2.Value;
            lblTotalFrameSize.Text = String.Format("={0}", totalFrameSize);
        }

        private void FrameSize1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalFrameSize();
            PaintBits();
        }

        private void FrameSize2_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalFrameSize();
            PaintBits();
        }

        private void BitSize_Changed(object sender, EventArgs e)
        {
            if (bitSize.Value < 12)
                if (bitSize.Value < 5)
                    BASIC_BORDER_SIZE = 0;
                else
                    BASIC_BORDER_SIZE = 1;
            else
                BASIC_BORDER_SIZE = 2;

            PaintBits();
        }

        private void ChopChanged(object sender, EventArgs e)
        {
            PaintBits();
        }

        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            PaintBits();
        }

        private void ImagePanel_Resize(object sender, EventArgs e)
        {
            PaintBits();
        }
        private void ImagePanel_MouseEnter(object sender, EventArgs e)
        {
            ImagePanel.Focus();
        }
        private void ImagePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            ImagePanel.Focus();
            if (e.Delta < 0)
            { vScrollBar1.Value = Math.Min(vScrollBar1.Maximum, vScrollBar1.Value + 1); }
            else
            { vScrollBar1.Value = Math.Max(vScrollBar1.Minimum, vScrollBar1.Value - 1); }

        }

        private void Sort_Click(object sender, EventArgs e)
        {
            decimal msb = sortStart.Value;
            decimal lsb = sortEnd.Value;
            if (msb <= lsb)
                fileData.Sort(
                    delegate (BitArray arr1, BitArray arr2)
                     {
                         if (lsb > arr1.Length)
                         {
                             if (lsb > arr2.Length)
                                 return 0;
                             else
                                 return -1;
                         }
                         else
                         {
                             if (lsb > arr2.Length)
                                 return 1;
                             else
                                 for (int i = (int)msb; i <= lsb; i++)
                                 {
                                     if (arr1[i] != arr2[i])
                                     {
                                         if (arr1[i])
                                             return 1;
                                         return -1;
                                     }
                                 }
                             return 0;
                         }
                     });
            PaintBits();
        }
    }
}
