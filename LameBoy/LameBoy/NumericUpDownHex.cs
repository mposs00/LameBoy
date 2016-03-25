using System;
using System.Windows.Forms;

namespace LameBoy
{
    class NumericUpDownHex : NumericUpDown
    {
        protected override void OnTextBoxTextChanged(object source, EventArgs e)
        {
            Text = Convert.ToInt32(Value).ToString("X4");
        }
    }
}
