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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
