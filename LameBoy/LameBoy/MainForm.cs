using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LameBoy
{
    public partial class MainForm : Form
    {
        CPU cpu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cpu = new CPU(Handle, panelGraphics.Handle);
        }

        private void menuItemOpenRom_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "ゲームボーイ ROMs (*.gb, *.gbc, *.bin, *.rom)|*.gb;*.gbc;*.bin;*.rom|All Files (*.*)|*.*";
            fd.FilterIndex = 1;

            fd.Multiselect = false;

            var okSelected = fd.ShowDialog();
            if (okSelected == DialogResult.OK)
            {
                Cart cart = new Cart(fd.FileName);
                cpu.SetCart(cart);

                Console.WriteLine(cart.GetCartType());

                Thread cputhread = new Thread(new ThreadStart(cpu.exec));
                cputhread.Start();
            }
        }
    }
}
