using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
