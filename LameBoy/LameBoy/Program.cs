using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LameBoy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //TODO: Include test ROMs for the time being
            //Including commercial games is illegal but this is a private repo so its sorta ok
            //But lets not deal with that right now, I'm sure you can get a hold of a pokemon red rom
            //And then we need a dialog to pick the file

            /*
            Cart cart = new Cart(@"C:\Users\Denton\Desktop\tetris.gb");

            CPU cpu = new CPU(cart);
            Console.WriteLine(cart.GetCartType());

            Thread cputhread = new Thread(new ThreadStart(cpu.exec));
            cputhread.Start();
            */
            //while (true) rt.Render();
            //Console.ReadLine();
            bool[] bits = OpcodeTable.ByteToBits(0xAB);
            Console.WriteLine(OpcodeTable.BitsToByte(bits).ToString("X2"));
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
