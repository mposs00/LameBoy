using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy
{
    class CPU
    {
        int pc = 0x100;
        Cart cart;
        byte instr;

        public CPU(Cart cart)
        {
            this.cart = cart;
        }
        //Main interpreter loop
        public void exec()
        {
            while (true)
            {
                instr = cart.Read8(pc);
                Console.WriteLine("PC: 0x" + instr.ToString("X2"));
                if (instr == 0x00)
                {
                    pc++;
                }
                else if(instr == 0xC3)
                {
                    short newaddr = cart.Read16(pc + 1);
                    pc = newaddr;
                    Console.WriteLine("Absolute Jump to $" + pc.ToString("X4"));
                }
                else
                {
                    Console.WriteLine("Unimplemented instr @ $" + pc.ToString("x4") + ", moving to $" + pc++.ToString("X4"));
                }
                Console.ReadLine();
            }
        }
    }
}
