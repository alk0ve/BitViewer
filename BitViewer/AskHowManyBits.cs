using System;
using System.Windows.Forms;

namespace BitViewer
{
    public partial class AskHowManyBits : Form
    {
        public bool pressedOK = false;
        public uint bitsToRead = 1000000;
        public AskHowManyBits()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pressedOK = true;
        }
    }
}
