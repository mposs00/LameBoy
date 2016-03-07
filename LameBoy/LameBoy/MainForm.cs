using LameBoy.Graphics;
using System;
using System.Diagnostics;
using System.IO;
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

                if(File.ReadAllBytes(fd.FileName).Length == 0x10000 && cart.GetCartType() == CartType.ROM)
                {
                    //Doesn't execute CPU when loading a ramdump
                    return;
                }

                Thread cputhread = new Thread(new ThreadStart(cpu.exec));
                cputhread.Start();
            }
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            //Set palette BGB
            Palette.SetColors(new byte[] { 0xE0, 0xF8, 0xD0 }, new byte[] { 0x88, 0xC0, 0x70 }, new byte[] { 0x34, 0x68, 0x56 }, new byte[] { 0x08, 0x18, 0x20 });
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            //Set palette Dark Green
            Palette.SetColors(new byte[] { 156, 189, 15 }, new byte[] { 140, 173, 15 }, new byte[] { 48, 98, 48 }, new byte[] { 15, 56, 15 });
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            //Set palette gray
            Palette.SetColors(new byte[] { 255, 255, 255 }, new byte[] { 192, 192, 192 }, new byte[] { 127, 127, 127 }, new byte[] { 0, 0, 0 });
        }
    }
}
