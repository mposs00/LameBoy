using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy
{
    class CPU
    {
        short pc = 0x100;
        byte a = 0;
        byte b = 0;
        byte c = 0;
        short hl = 0;
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
                    Console.WriteLine("NOP");
                }
                else if(instr == 0x05)
                {
                    b--;
                    pc++;
                    Console.WriteLine("Decremented b to 0x" + b.ToString("X2"));
                }
                else if(instr == 0x06)
                {
                    byte data = cart.Read8(pc + 1);
                    b = data;
                    pc += 2;
                    Console.WriteLine("Loaded value 0x" + data.ToString("X2") + " into b, advanced to $" + pc.ToString("X4"));
                }
                else if(instr == 0x0E)
                {
                    byte data = cart.Read8(pc + 1);
                    c = data;
                    pc += 2;
                    Console.WriteLine("Loaded value 0x" + data.ToString("X2") + " into c, advanced to $" + pc.ToString("X4"));
                }
                else if(instr == 0x21)
                {
                    short data = cart.Read16(pc + 1);
                    hl = data;
                    pc += 3;
                    Console.WriteLine("Loaded value 0x" + data.ToString("X4") + " into hl");
                }
                else if(instr == 0xAF)
                {
                    byte result = (byte) (a ^ a);
                    a = result;
                    pc++;
                    Console.WriteLine("XORed a with a, resulting in a containing 0x" + a.ToString("X2"));
                }
                else if(instr == 0xC3)
                {
                    short newaddr = cart.Read16(pc + 1);
                    pc = newaddr;
                    Console.WriteLine("Absolute jump to $" + pc.ToString("X4"));
                }
                else if(instr == 0xFF)
                {
                    pc = 0x0038;
                    Console.WriteLine("Jump to reset vector $0038");
                }
                else
                {
                    Console.WriteLine("Unimplemented instr @ $" + pc.ToString("x4") + ", moving to $" + (pc + 1).ToString("X4"));
                    pc++;
                }
                Console.ReadLine();
            }
        }
    }
}
