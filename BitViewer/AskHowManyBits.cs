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

        private void numericUpDownOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            //block non numeric input
            if (e.KeyChar < '0' || e.KeyChar > '9')
                //allow backspaces
                if (e.KeyChar != '\x08')
                    e.Handled = true;
        }

        private void numericUpDownLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            //block non numeric input
            if (e.KeyChar < '0' || e.KeyChar > '9')
                //allow backspaces
                if (e.KeyChar != '\x08')
                    e.Handled = true;
        }
    }
}
