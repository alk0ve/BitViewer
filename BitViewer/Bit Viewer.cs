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
        BitArray myBits;
        string inputFile;
        int bitCount=0;
        string bmpFile = "C:\\Bit Files\\TemporaryBMPFile.bmp";
        List<byte> myBytes;
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
        public static byte[] BitReverseTable =
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
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                inputFile = openFileDialog1.FileName;
                /*
                AskHowManyBits ask = new AskHowManyBits();
                while(!ask.pressedOK)
                { }
                int maxBitsToRead = (int)ask.BitsToReadInput.Value;
                ask.Close();
                */
                try
                {
                    myBytes = new List<byte>(File.ReadAllBytes(inputFile));
                    bitCount = myBytes.Count * 8; //Dunnu how to use not alligned files yet. Should fix that.
                    byte[] headerBytes = new byte[] {0x42, 0x4D, 0x7E, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3E, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x64, 0x00, 0x00, 0x00, 0x64, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00};
                    headerBytes = headerBytes.Reverse().ToArray();
                    if (!IsRev8.Checked)
                    {
                        for (int i = 0; i < myBytes.Count; i++)
                        {
                            myBytes[i] = BitReverseTable[myBytes[i]]; //Byte reversal is a bitch
                        }
                    }
                    myBytes.AddRange(headerBytes);
                    myBytes.Reverse();
                    myBits = new BitArray(myBytes.ToArray());
                    RefreshBMP();
                }
                catch (IOException)
                {
                    MessageBox.Show("Exception threw because of that stupid file you choosed. You happy? I'm Sad.", "Exception!");
                }
            }

        }

        private void BitsPicture_Click(object sender, EventArgs e)
        {

        }
        private void RefreshBMP()
        {
            int width = (int)(FrameSize1.Value * FrameSize2.Value);
            int height = (int)((bitCount - (int)readFileOffset.Value) / (FrameSize1.Value * FrameSize2.Value));
            int fileLength = height * ((width + 31) / 32) * 32 + 62 * 8;
            if (width >= bitCount - (int)readFileOffset.Value)
            {
                width = bitCount - (int)readFileOffset.Value;
                height = 1;
                fileLength = width + 62 * 8;
            }
            //int height = (int)((bitCount + (FrameSize1.Value * FrameSize2.Value - 1)) / (FrameSize1.Value * FrameSize2.Value));
            BitsPicture.Size = new Size(width * (int)bitSize.Value, height * (int)bitSize.Value);// ((bitCount - (int)readFileOffset.Value) / width + 1) * (int)bitSize.Value);
            BitsPicture.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            BitArray myBMPBits = new BitArray(fileLength);
            /*for (int i = 0; i < 62; i++)
            {
                for (int j = 0; j >= 0; j++)
                {
                    myBMPBits[i] = myBits[i*8+j];
                }
            }*/
            int reminder = (32 - Math.Abs(width) % 32) % 32;
            int readOffset = (int)readFileOffset.Value;
            if(reminder == 0)
            {
                if (readOffset == 0)
                {
                    for (int i = 0; i < myBMPBits.Length; i++)
                    {
                        myBMPBits[i] = myBits[i];
                    }
                }
                else
                {
                    //FUCK THAT DOESN'T WORK AT ALL
                    for (int i = 0; i < 62 * 8; i++)
                    {
                        myBMPBits[i] = myBits[i];
                    }
                    for (int i = 62 * 8; i < myBMPBits.Length; i ++)
                    {
                        int a = i - readOffset % 8 + 8 * (readOffset / 8) + ((readOffset % 8 - i % 8) > 0 ? 16 : 0) - 496;
                        myBMPBits[i] = myBits[i - readOffset % 8 + 8 * (readOffset / 8) + ((i % 8 - readOffset % 8) > 0 ? 16 : 0)];
                                                                                                        // 7,6,5,4,3,2,1,0,15,14,13,12,11,10,9,8 - > 8,7,6,5,4,3,2,1,16,15,14,13,12,11,10, 9 
                                                                                                        //i - 1 + (i % 8 - readOffset % 8 > 0 ? 0 : 8)
                               /*                                                                       // 7,6,5,4,3,2,1,0,15,14,13,12,11,10,9,8 - > 9,8,7,6,5,4,3,2,17,16,15,14,13,12,11,10   
                        0-> - 1
                        1->0
                        2->1
                        
                        0->15
                        1->0
                        2->1
                        3->2
                        7->6
                        8->23

                        2:
                        0->14
                        1->15
                        2->0
                            ..
                        7->5
                        8->22*/
                    }
                }
               
            }
            else
            {
                int offset = 0;
                int maxLine = width * height;
                for (int i = 0; i < 62 * 8; i++)
                {
                    myBMPBits[i] = myBits[i];
                }
                for (int line = 0; line < maxLine; line += width)
                {
                    int maxj = line + width + 62*8;
                    for (int j = line + 62*8; j < maxj; j++)
                    {
                        myBMPBits[j + offset] = myBits[j + readOffset];
                    }
                    for (int j = 0; j < reminder; j++)
                    {
                        myBMPBits[maxj + offset + j] = false;
                    }
                   
                    offset += reminder;
                }
            }
            int temp = (fileLength + 7) / 8;
            for (int i = 2; i <= 5; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    myBMPBits[i * 8 + j] = (temp % 2) == 1;
                    temp/=2;
                }
            }
            temp = (fileLength + 7) / 8 - 62;
            for (int i = 34; i <= 37; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    myBMPBits[i * 8 + j] = (temp % 2) == 1;
                    temp /= 2;
                }
            }
            temp = width;
            for (int i = 18; i <= 21; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    myBMPBits[i * 8 + j] = (temp % 2) == 1;
                    temp /= 2;
                }
            }
            temp = height;
            for (int i = 22; i <= 25; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    myBMPBits[i * 8 + j] = (temp % 2) == 1;
                    temp /= 2;
                }
            }
            byte[] myBytes = new byte[myBMPBits.Length / 8 + (myBMPBits.Length % 8 == 0 ? 0 : 1)];
            myBMPBits.CopyTo(myBytes, 0);
            File.WriteAllBytes(bmpFile, myBytes);
            Stream bmpStream = new MemoryStream(myBytes);
            /*Color zero = Color.White;
            Color one = Color.Black;
            byte currByte = myBytes[0];
            for (int line = 0; line < imageSize / width; line++)
            {
                int bitnum = line * width;
                int offset = 0;
                for (; bitnum % 8 != 0; bitnum++)
                {
                    //that's probably little indian..
                    myBitmap.SetPixel(bitnum - line * width, line, Color.FromArgb(255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2)));
                    //myBitmap.SetPixel(bitnum-line*width,line,Color.FromArgb(255*((currByte+1)%2),Color.Black);
                    currByte /= 2;
                    offset++;
                }
                for (int byteinline = 0; byteinline < (width - offset) / 8 - 1; byteinline++)
                {
                    currByte = myBytes[bitnum / 8];
                    //that's probably little indian..
                    for (int i = 0; i < 8; i++)
                    {
                        myBitmap.SetPixel(bitnum - line * width, line, Color.FromArgb(255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2)));
                        currByte /= 2;
                        bitnum++;
                    }
                }
                for (; bitnum < (line + 1) * width; bitnum++)
                {
                    if (bitnum % 8 == 0)
                        currByte = myBytes[bitnum / 8];
                    //that's probably little indian..
                    myBitmap.SetPixel(bitnum - line * width, line, Color.FromArgb(255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2), 255 * ((currByte + 1) % 2)));
                    //myBitmap.SetPixel(bitnum-line*width,line,Color.FromArgb(255*((currByte+1)%2),Color.Black);
                    currByte /= 2;
                }
                if (line % 100 == 99)
                {
                    BitsPicture.Image = myBitmap;
                    BitsPicture.Refresh();
                }
            }
             * */
            BitsPicture.Image = new Bitmap(bmpStream);
            
        }

        private void FrameSize1_ValueChanged(object sender, EventArgs e)
        {
            if (bitCount != 0)
            {
                RefreshBMP();
            }
        }

        private void FrameSize2_ValueChanged(object sender, EventArgs e)
        {
            if (bitCount != 0)
            {
                RefreshBMP();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (bitCount != 0)
            {
                RefreshBMP();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                inputFile = openFileDialog1.FileName;
                Stream st = new MemoryStream(File.ReadAllBytes(inputFile));
                BitsPicture.Image = new Bitmap(st);
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (bitCount != 0)
            {
                RefreshBMP();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void IsRev8_CheckedChanged(object sender, EventArgs e)
        {
            if (bitCount != 0)
            {
                bool a;
                bool b;
                bool c;
                bool d;
                for (int i = 62 * 8; i < myBits.Count; i += 8)
                {
                    a = myBits[i];
                    b = myBits[i + 1];
                    c = myBits[i + 2];
                    d = myBits[i + 3];
                    myBits[i] = myBits[i + 7];
                    myBits[i + 1] = myBits[i + 6];
                    myBits[i + 2] = myBits[i + 5];
                    myBits[i + 3] = myBits[i + 4];
                    myBits[i + 4] = d;
                    myBits[i + 5] = c;
                    myBits[i + 6] = b;
                    myBits[i + 7] = a;
                }
                RefreshBMP();
            }
        }
    }
}
