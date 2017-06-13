using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BitViewer
{
    public partial class MainForm : Form
    {

        private int GetVisibleBitRowCount()
        {
            int effectivePanelHeight = Math.Max(0, hScrollBar1.Visible ? (ImagePanel.Height - hScrollBar1.Height) : ImagePanel.Height);
            int visibleBitRowCount = 1 + (int)(effectivePanelHeight / (BASIC_BORDER_SIZE + (uint)bitSize.Value));
            if (visibleBitRowCount <= 0)
                throw new System.OverflowException("Number of visible bit rows exceeds int32.");
            return visibleBitRowCount;
        }
        private int GetVisibleBitColumnCount()
        {
            int effectivePanelWidth = Math.Max(0, vScrollBar1.Visible ? (ImagePanel.Width - vScrollBar1.Width) : ImagePanel.Width);
            int visibleBitColumnCount = 1 + (int)(effectivePanelWidth / (BASIC_BORDER_SIZE + (uint)bitSize.Value));
            if (visibleBitColumnCount <= 0)
                throw new System.OverflowException("Number of visible bit columns exceeds int32.");
            return visibleBitColumnCount;
        }

        //use arrow and page keys to navigate your bits
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ImagePanel.Focused)
            {
                if (keyData == Keys.Left)
                {
                    hScrollBar1.Value = Math.Max(0, hScrollBar1.Value - 1);
                    return true;
                }
                if (keyData == Keys.Right)
                {
                    hScrollBar1.Value = (int)Math.Min((uint)hScrollBar1.Maximum, (uint)hScrollBar1.Value + 1);
                    return true;
                }
                if (keyData == Keys.Up)
                {
                    vScrollBar1.Value = Math.Max(0, vScrollBar1.Value - 1);
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    vScrollBar1.Value = (int)Math.Min((uint)vScrollBar1.Maximum, (uint)vScrollBar1.Value + 1);
                    return true;
                }
                if (keyData == Keys.PageDown)
                {
                   vScrollBar1.Value = (int)Math.Min((uint)vScrollBar1.Maximum, (uint)vScrollBar1.Value + ((uint)GetVisibleBitRowCount())/2);
                   return true;
                }
                if (keyData == Keys.PageUp)
                {
                    vScrollBar1.Value = Math.Max(0, vScrollBar1.Value - GetVisibleBitRowCount()/2);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData); ;
        }

        long MAX_READ_LENGTH = (int.MaxValue / 8);
        List<Packet> fileData = null;
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
                if (fileData == null)
                {
                    // in case the user canceled 
                    return;
                }

                this.Text = String.Format("{0} - {1}", programName, fileName);
                PaintBits();
            }


        }
        private List<Packet> GetPacketsFromPcap(string fileName)
        {
            // LV structure, first 6*4 bytes are global header, Then 4*4bytes packet header - the last 4bytes in the header are the actual length.
            byte[] bytesFromFile = File.ReadAllBytes(fileName);
            List<Packet> fileData = new List<Packet>();
            int index = 24;
            int packetIndex = 0;
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
                fileData.Add(new Packet(packetData, packetIndex));
                index += currentPacketLength + 16;
                packetIndex += 1;
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

        private List<Packet> GetRawBitsFromFile(string fileName)
        {
            byte[] bytesFromFile;

            // if the file is large enough - we'll need to ask the user which segment to open
            FileInfo fileToOpen = new FileInfo(fileName);

            
            if (fileToOpen.Length < MAX_READ_LENGTH)
            {
                // file is small enough to read in its entirety
                bytesFromFile = File.ReadAllBytes(fileName);
            }
            else
            {
                AskHowManyBits askForm = new AskHowManyBits();
                askForm.numericUpDownOffset.Maximum = fileToOpen.Length - 1;

                if (askForm.ShowDialog() == DialogResult.Cancel)
                {
                    return null;
                }
                decimal lengthToRead = askForm.numericUpDownLength.Value;


                FileStream fileStream = File.OpenRead(fileName);
                fileStream.Seek((long)askForm.numericUpDownOffset.Value, SeekOrigin.Begin);
                long effectiveReadSize = Math.Min((long)askForm.numericUpDownLength.Value, (fileToOpen.Length - (long)askForm.numericUpDownOffset.Value));
                bytesFromFile = new byte[effectiveReadSize];
                // TODO: note that the last argument here must be int, so if
                // we plan on reading more we'll need to work around this
                fileStream.Read(bytesFromFile, 0, (int)effectiveReadSize);
            }

            // rev8 all the bytes!
            REV8(bytesFromFile);
            List<Packet> data = new List<Packet>();
            data.Add(new Packet(bytesFromFile, 0));
            return data;
        }

        private void PaintBits()
        {
            if (ImagePanel.Width * ImagePanel.Height == 0) return;
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
            while (packetIndex < fileData.Count && currentChop >= fileData.ElementAt(packetIndex).data.Length)
            {
                currentChop -= fileData.ElementAt(packetIndex).data.Length;
                packetIndex++;
            }
            // now the chop refers to the current packet only

            int visibleBitsPerLine = GetVisibleBitColumnCount();
            int visibleNumLines = GetVisibleBitRowCount();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // configure the scroll bars
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            uint numLines = 0;
            for (int j = packetIndex; j < fileData.Count; j++)
                if (j == packetIndex)
                    numLines += ((uint)fileData.ElementAt(j).data.Length - (uint)currentChop + currentFrameSize - 1) / currentFrameSize;
                else
                    numLines += ((uint)fileData.ElementAt(j).data.Length + currentFrameSize - 1) / currentFrameSize;

            // the scrollbar's max is set to the frame size if it is needed.
            if (visibleBitsPerLine - 1 < currentFrameSize)
            {
                hScrollBar1.Maximum = (int)currentFrameSize - visibleBitsPerLine + 10;
                hScrollBar1.Visible = true;
            }
            else
            {
                hScrollBar1.Value = 0;
                hScrollBar1.Visible = false;
            }
            // the maximum should be the number of bits we're not seeing
            if (numLines - 1 > visibleNumLines)
            {
                vScrollBar1.Maximum = (int)(numLines - visibleNumLines) + 10;
                vScrollBar1.Visible = true;
            }
            else
            {
                vScrollBar1.Value = 0;
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
            using (SolidBrush packetBrush = new SolidBrush(Color.Turquoise))
            {
                // draw background
                g.FillRectangle(bgBrush, 0, 0, ImagePanel.Width, ImagePanel.Height);

                // draw red lines between bytes
                for (int i = 1; i <= ((Math.Min(visibleBitsPerLine, currentFrameSize) + 7) / 8); ++i)
                {
                    g.FillRectangle(redBrush, (8 * i - hScrollBar1.Value % 8) * (bitSizeInPixels + BASIC_BORDER_SIZE) - BASIC_BORDER_SIZE,
                        0, BASIC_BORDER_SIZE, ImagePanel.Height);
                }


                // draw all them bits
                int index = (int)currentFrameSize * (int)vScrollBar1.Value;
                while (packetIndex < fileData.Count && index >= (fileData.ElementAt(packetIndex).data.Length - currentChop))
                {
                    int skippedBits = (int)fileData.ElementAt(packetIndex).data.Count - (int)currentChop;
                    int skippedLines = (int)Math.Ceiling((double)skippedBits / (int)currentFrameSize);
                    int skippedSlots = skippedLines * skippedBits;
                    index -= skippedLines * (int)currentFrameSize;
                    // we remove from the index all the lines we skipped, the bits we skipped + the empty slots remained in the line.
                    packetIndex++;
                    currentChop = 0;
                }
                index += (int)currentChop;
                //packetIndex points to the packet the has to be displayed currently, index points to the first bitIndex to be found at the topmost visible row.
                if (packetIndex < fileData.Count)
                {
                    bool packetFinished;
                    //draw rows
                    for (int y = 0; y < visibleNumLines; ++y)
                    {
                        packetFinished = false;
                        if (index >= fileData.ElementAt(packetIndex).data.Count)
                        {

                            currentChop = 0;
                            index = 0;
                            packetFinished = true;
                            packetIndex++;
                            if (packetIndex >= fileData.Count)
                                break;
                        }
                        //draw a row
                        index += hScrollBar1.Value;
                        for (int x = 0; x < currentFrameSize - hScrollBar1.Value; ++x)
                        {
                            if (index >= fileData.ElementAt(packetIndex).data.Count)
                                break;
                            if (x < visibleBitsPerLine)
                            {
                                // draw a pixel
                                if (fileData.ElementAt(packetIndex).data[index])
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
                        if (packetFinished) g.FillRectangle(packetBrush, 0, y * (bitSizeInPixels + BASIC_BORDER_SIZE) - 1, ImagePanel.Width, BASIC_BORDER_SIZE);
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

        private void HScrollBar1_ValueChanged(object sender, EventArgs e)
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

            if (ModifierKeys.HasFlag(Keys.Control))
            {
                // zoom
                if (e.Delta < 0)
                {
                    bitSize.Value = Math.Max(bitSize.Value - 1, bitSize.Minimum);
                }
                else
                {
                    bitSize.Value = Math.Min(bitSize.Value + 1, bitSize.Maximum);
                }
            }
            else
            {
                // scroll
                if (e.Delta < 0)
                {
                    vScrollBar1.Value = Math.Min(vScrollBar1.Maximum, vScrollBar1.Value + 1);
                }
                else
                {
                    vScrollBar1.Value = Math.Max(vScrollBar1.Minimum, vScrollBar1.Value - 1);
                }
            }
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if (fileData == null)
                return;
            decimal msb = sortStart.Value;
            decimal lsb = sortEnd.Value;
            if (msb <= lsb)
                fileData.Sort(
                    delegate (Packet pac1, Packet pac2)
                     {
                         int indexDiff = pac1.index - pac2.index;
                         if (lsb > pac1.data.Length)
                         {
                             if (lsb > pac2.data.Length)
                                 return indexDiff;
                             else
                                 return -1;
                         }
                         else
                         {
                             if (lsb > pac2.data.Length)
                                 return 1;
                             else
                                 for (int i = (int)msb; i <= lsb; i++)
                                 {
                                     if (pac1.data[i] != pac2.data[i])
                                     {
                                         if (pac1.data[i])
                                             return 1;
                                         return -1;
                                     }
                                 }
                             return indexDiff;
                         }
                     });
            PaintBits();
        }

        private void ImagePanel_MouseClick(object sender, MouseEventArgs e)
        {
            ImagePanel.Focus();
            if (e.Button == MouseButtons.Right)
            {
                int col = hScrollBar1.Value + e.Location.X / (int)(bitSize.Value + BASIC_BORDER_SIZE);
                int row = vScrollBar1.Value + e.Location.Y / (int)(bitSize.Value + BASIC_BORDER_SIZE);
                string coordinates = "(" + col.ToString() + "," + row.ToString() + ")";
                toolTip1.Show(coordinates, ImagePanel, e.Location, 1234);
                //MessageBox.Show(col.ToString() + ":" + row.ToString());
            }
        }

        private void sortStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sortEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            //if (fileData == null) return;
            //int max_packet_length = 0;
            //foreach Packet p in fileData


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
