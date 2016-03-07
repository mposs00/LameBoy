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
        GPU gpu;
        Thread cpuThread;
        Thread gpuThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gpu = new GPU(Handle, panelGraphics.Handle);
            cpu = new CPU(gpu);
            gpuThread = new Thread(new ThreadStart(gpu.RenderScene));
            gpuThread.Start();

        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            gpu.Shutdown();
            gpu.Terminate();
            cpu.Terminate();
        }

        private void menuItemOpenRom_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "Game Boy ROMs (*.gb, *.gbc, *.bin, *.rom)|*.gb;*.gbc;*.bin;*.rom|All Files (*.*)|*.*";
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

                cpuThread = new Thread(new ThreadStart(cpu.Execute));
                cpuThread.Start();

                gpuThread = new Thread(new ThreadStart(gpu.RenderScene));
                gpuThread.Start();
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

        private void menuItem15_Click(object sender, EventArgs e)
        {
            //Random Palette
            Random r = new Random();
            Palette.SetColors(new byte[] { (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256) }, new byte[] { (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256) }, new byte[] { (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256) }, new byte[] { (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256) });
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            //scale 1
            cpu.SetScale(1);
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            //scale 2
            cpu.SetScale(2);
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            //scale 3
            cpu.SetScale(3);
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            //scale 4
            cpu.SetScale(4);
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            //scale 5
            cpu.SetScale(5);
        }
    }
}
