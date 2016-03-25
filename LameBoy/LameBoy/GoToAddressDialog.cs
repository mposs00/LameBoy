using System;
using System.Windows.Forms;

namespace LameBoy
{
    public partial class GoToAddressDialog : Form
    {
        public int Address { get; private set; } = -1;
        private int maxSize;

        public GoToAddressDialog()
        {
            InitializeComponent();
        }

        public static int Prompt(int maxSize, IWin32Window owner)
        {
            var dialog = new GoToAddressDialog();
            dialog.maxSize = maxSize;
            dialog.ShowDialog(owner);
            return dialog.Address;
        }

        private void GoToAddressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                if (textBoxAddress.Text == String.Empty)
                    return;
                int addr = -1;
                bool result = Int32.TryParse(textBoxAddress.Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out addr);
                if(!result)
                {
                    MessageBox.Show(this, "This address is invalid.", "Address Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                if(addr > maxSize || addr < 0)
                {
                    MessageBox.Show(this, String.Format("The address must be between 0x0 and 0x{0:X}.", maxSize), "Address Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                Address = addr;                    
            }

        }
    }
}
