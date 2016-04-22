using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LameBoy
{
    public partial class Debugger : Form
    {
        CPU cpu;

        List<Tuple<int, string[]>> romDisassembly;

        public Debugger(CPU cpu)
        {
            InitializeComponent();
            this.cpu = cpu;
            this.cpu.StateChange += OnStateChange;
        }

        //This only runs when a game is actually loaded.
        public void Initialize()
        {
            romDisassembly = new List<Tuple<int, string[]>>();
            PopulateDisassembly();
            listViewDisassemblyROM.ContextMenuStrip = contextMenuStripDisasm;
            listViewMemory.VirtualListSize = 4096;
        }

        public void OnStateChange(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    UpdateState();
                }));
            }
            else
                UpdateState();
        }

        public void UpdateState()
        {
            if (cpu.CPUState == State.Paused || cpu.CPUState == State.Stopped)
            {
                splitContainer.Enabled = true;
                UpdateRegisters();
            }
            else
            {
                splitContainer.Enabled = false;
            }

            if ((cpu.CPUState & State.Running) != 0)
            {
                toolStripLabelStatus.Image = LameBoy.Properties.Resources.DebuggerGo;
                toolStripLabelStatus.Text = "Running";
            }
            else if (cpu.CPUState == State.Paused)
            {
                toolStripLabelStatus.Image = LameBoy.Properties.Resources.DebuggerPause;
                toolStripLabelStatus.Text = "Paused";
            }
            else if (cpu.CPUState == State.Stopped)
            {
                toolStripLabelStatus.Image = LameBoy.Properties.Resources.DebbugerStop;
                toolStripLabelStatus.Text = "Stopped";
            }
        }

        public void Go()
        {
            cpu.Resume();
        }

        public void Stop()
        {
            cpu.Pause();
        }

        public void Step()
        {
            if (cpu.CPUState == State.Stopped) return;
            cpu.Pause();
            cpu.Execute();
            UpdateRegisters();
            ShowExecLine();
        }

        public void ShowExecLine()
        {
            var pc = cpu.registers.PC;
            int instrIndex = romDisassembly.IndexOf(romDisassembly.FirstOrDefault(instruction => instruction.Item1 == pc));
            if (instrIndex < 0) return;
            listViewDisassemblyROM.SelectedIndices.Clear();
            listViewDisassemblyROM.SelectedIndices.Add(instrIndex);
            listViewDisassemblyROM.EnsureVisible(instrIndex);
        }

        public void PopulateDisassembly()
        {
            var cart = cpu.GameCart;
            int i = 0;
            listViewDisassemblyROM.VirtualListSize = 0x3fff;
            //TODO make more CPU-agnostic - maybe define a memory range for ROM?
            while (i < 0x3fff)
            {
                Opcode op = OpcodeTable.Table[cpu.GameCart.Read8(i)];
                string disasm = op.Disassembly,
                    rawBytes = "";

                switch (op.Length)
                {
                    case 3:
                        disasm = String.Format(disasm, cart.Read16(i + 1));
                        rawBytes = String.Format("{0:X2} {1:X2} {2:X2}", cart.Read8(i), cart.Read8(i + 1), cart.Read8(i + 2));
                        break;
                    case 2:
                        disasm = String.Format(disasm, cart.Read8(i + 1), "???");
                        rawBytes = String.Format("{0:X2} {1:X2}", cart.Read8(i), cart.Read8(i + 1));
                        break;
                    case 1:
                        rawBytes = String.Format("{0:X2}", cart.Read8(i));
                        break;
                }

                string[] opItem = new[]
                {
                    String.Format("{0:X4}", i),
                    rawBytes,
                    disasm
                };
                romDisassembly.Add(new Tuple<int, string[]>(i, opItem));
                i += op.Length;
            }
            listViewDisassemblyROM.VirtualListSize = romDisassembly.Count;
        }

        private void listViewDisassemblyROM_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int i = e.ItemIndex;
            e.Item = new ListViewItem(romDisassembly[i].Item2);
        }

        public void UpdateDisassembly()
        {
            listViewDisassemblyROM.SelectedItems.Clear();
            listViewDisassemblyROM.Items.Find(String.Format("{0}", cpu.registers.PC), false)[0].Selected = true;
        }

        public void UpdateRegisters()
        {
            numericUpDownAF.Value = cpu.registers.AF;
            numericUpDownBC.Value = cpu.registers.BC;
            numericUpDownDE.Value = cpu.registers.DE;
            numericUpDownHL.Value = cpu.registers.HL;
            numericUpDownSP.Value = cpu.registers.SP;
            numericUpDownPC.Value = cpu.registers.PC;

            checkBoxZ.Checked = cpu.registers.Z;
            checkBoxS.Checked = cpu.registers.N;
            checkBoxH.Checked = cpu.registers.HC;
            checkBoxC.Checked = cpu.registers.CA;
        }

        private void listViewMemory_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(String.Format("{0:X4}", e.ItemIndex * 0x10));
            for (int i = 0; i < 16; i++)
                e.Item.SubItems.Add(String.Format("{0:X2}", cpu.GameCart.Read8(e.ItemIndex * 0x10 + i)));
        }

        private void editTextBox_Leave(object sender, EventArgs e)
        {
            editTextBox.Visible = false;
        }

        private void listViewMemory_DoubleClick(object sender, MouseEventArgs e)
        {
            var hitTest = listViewMemory.HitTest(e.Location);
            if (hitTest.SubItem.Text == hitTest.Item.Text) return;

            Rectangle rowBounds = hitTest.SubItem.Bounds;
            Rectangle labelBounds = hitTest.Item.GetBounds(ItemBoundsPortion.Label);
            int leftMargin = labelBounds.Left - 1;

            editTextBox.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin - 1, rowBounds.Height);
            editTextBox.Text = hitTest.SubItem.Text;
            editTextBox.SelectAll();
            editTextBox.Visible = true;
            editTextBox.Focus();
        }

        private void editTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (editTextBox.TextLength > 0)
                {
                    byte num;
                    bool success = Byte.TryParse(editTextBox.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num);
                    if (!success) return;

                    var hitTest = listViewMemory.HitTest(editTextBox.Location);
                    int address = hitTest.Item.Index * 0x10 + hitTest.Item.SubItems.IndexOf(hitTest.SubItem) - 1;
                    cpu.GameCart.Write8(address, num);
                }
                editTextBox.Visible = false;
            }
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void toolStripButtonStep_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            Stop();
            ShowExecLine();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Why 'as'? Returns null if not castable.
            string tag = ((NumericUpDown)sender).Tag as string;
            var regs = cpu.registers;
            switch (tag)
            {
                case "Registers.AF":
                    regs.AF = (ushort)numericUpDownAF.Value;
                    break;
                case "Registers.BC":
                    regs.BC = (ushort)numericUpDownBC.Value;
                    break;
                case "Registers.DE":
                    regs.DE = (ushort)numericUpDownDE.Value;
                    break;
                case "Registers.HL":
                    regs.HL = (ushort)numericUpDownHL.Value;
                    break;
                case "Registers.SP":
                    regs.SP = (ushort)numericUpDownSP.Value;
                    break;
                case "Registers.PC":
                    regs.PC = (ushort)numericUpDownPC.Value;
                    break;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            string tag = ((CheckBox)sender).Tag as string;
            var regs = cpu.registers;
            switch (tag)
            {
                case "Flags.Z":
                    regs.Z = checkBoxZ.Checked;
                    break;
                case "Flags.S":
                    regs.S = checkBoxS.Checked;
                    break;
                case "Flags.H":
                    regs.HC = checkBoxH.Checked;
                    break;
                case "Flags.C":
                    regs.CA = checkBoxC.Checked;
                    break;
            }
        }

        private void goToAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int address = GoToAddressDialog.Prompt(cpu.GameCart.RAM.Length, this);
            if (address > 0)
            {
                int index = romDisassembly.IndexOf(romDisassembly.FirstOrDefault(instruction => instruction.Item1 == address));
                if (index < 0)
                {
                    MessageBox.Show(this, "Address could not be found in disassembly.", "Could Not Find Opcode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                listViewDisassemblyROM.SelectedIndices.Clear();
                listViewDisassemblyROM.SelectedIndices.Add(index);
                listViewDisassemblyROM.EnsureVisible(index);
            }
        }

        private void Debugger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
