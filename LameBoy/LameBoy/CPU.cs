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
        byte f = 0;
        ushort hl = 0;
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
                //TODO: Properly set the flags on each instruction
                //TODO: Don't output the PC every time it changes, only once on each CPU cycle
                instr = cart.Read8(pc);
                Console.WriteLine("PC: $" + pc.ToString("X4"));
                Console.WriteLine("Instruction: 0x" + instr.ToString("X2"));
                if (instr == 0x00)
                {
                    pc++;
                    Console.WriteLine("NOP");
                }
                else if(instr == 0x05)
                {
                    b--;
                    pc++;
                    if (b == 0x00)
                        f += 0x40; //0x40 = 0b01000000, zero flag
                    else
                        f = 0;
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
                else if (instr == 0x20)
                {
                    if(!((f & 0x40) == 0x40))
                    {
                        //Relative jumps are stored as a two's complement binary number, and must account for the instruction
                        //just executed, so the PC must also be incremented
                        pc++;
                        byte loc = cart.Read8(pc);
                        bool negative = ((loc & 0x80) == 0x80);
                        if (negative)
                        {
                            loc = (byte) (255 - loc);
                            pc -= loc;
                        }
                        else
                        {
                            pc += loc;
                        }
                        Console.WriteLine("PC advanced by 0x" + loc.ToString("X2") + " to address $" + pc.ToString("X4"));
                    }
                    else
                    {
                        pc += 2;
                        Console.WriteLine("Zero flag set, PC incremented");
                    }
                    f = 0;
                }
                else if(instr == 0x21)
                {
                    ushort data = (ushort) cart.Read16(pc + 1);
                    hl = data;
                    pc += 3;
                    Console.WriteLine("Loaded value 0x" + data.ToString("X4") + " into hl");
                }
                else if(instr == 0x32)
                {
                    Console.WriteLine(hl);
                    cart.Write8(hl, a);
                    Console.WriteLine("a copied to $" + hl.ToString("X2") + " and HL decremented");
                    hl--;
                    pc++;
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
