using System;

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
        bool interruptsEnabled = true;
        Cart cart;
        byte instr;
        bool cpuOut = false;

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
                if (cpuOut)
                {
                    Console.WriteLine("PC: $" + pc.ToString("X4"));
                    Console.WriteLine("Instruction: 0x" + instr.ToString("X2"));
                }
                if (instr == 0x00)
                {
                    pc++;
                    if (cpuOut)
                        Console.WriteLine("NOP");
                }
                else if (instr == 0x05)
                {
                    b--;
                    pc++;
                    if (b == 0x00)
                        f += 0x40; //0x40 = 0b01000000, zero flag
                    else
                        f = 0;
                    if (cpuOut)
                        Console.WriteLine("Decremented b to 0x" + b.ToString("X2"));
                }
                else if (instr == 0x06)
                {
                    byte data = cart.Read8(pc + 1);
                    b = data;
                    pc += 2;
                    if (cpuOut)
                        Console.WriteLine("Loaded value 0x" + data.ToString("X2") + " into b, advanced to $" + pc.ToString("X4"));
                }
                else if (instr == 0x0D)
                {
                    c--;
                    pc++;
                    if (c == 0x00)
                        f += 0x40;
                    else
                        f = 0;
                    if (cpuOut)
                        Console.WriteLine("Decremented c to 0x" + c.ToString("X2"));
                }
                else if (instr == 0x0E)
                {
                    byte data = cart.Read8(pc + 1);
                    c = data;
                    pc += 2;
                    if (cpuOut)
                        Console.WriteLine("Loaded value 0x" + data.ToString("X2") + " into c, advanced to $" + pc.ToString("X4"));
                }
                else if (instr == 0x20)
                {
                    if (!((f & 0x40) == 0x40))
                    {
                        //Relative jumps are stored as a two's complement binary number, and must account for the instruction
                        //just executed, so the PC must also be incremented
                        pc++;
                        byte loc = cart.Read8(pc);
                        bool negative = ((loc & 0x80) == 0x80);
                        if (negative)
                        {
                            loc = (byte)(255 - loc);
                            pc -= loc;
                        }
                        else
                        {
                            pc += loc;
                        }
                        if (cpuOut)
                            Console.WriteLine("PC advanced by 0x" + loc.ToString("X2") + " to address $" + pc.ToString("X4"));
                    }
                    else
                    {
                        pc += 2;
                        if (cpuOut)
                            Console.WriteLine("Zero flag set, PC incremented");
                    }
                    f = 0;
                }
                else if (instr == 0x21)
                {
                    ushort data = (ushort)cart.Read16(pc + 1);
                    hl = data;
                    pc += 3;
                    if (cpuOut)
                        Console.WriteLine("Loaded value 0x" + data.ToString("X4") + " into hl");
                }
                else if (instr == 0x32)
                {
                    cart.Write8(hl, a);
                    if (cpuOut)
                        Console.WriteLine("a copied to $" + hl.ToString("X2") + " and HL decremented");
                    hl--;
                    pc++;
                }
                else if (instr == 0x3E)
                {
                    pc++;
                    a = cart.Read8(pc);
                    pc++;
                    cpuOut = true;
                    if (cpuOut)
                        Console.WriteLine("Loaded value 0x" + a.ToString("X2") + " into a");
                }
                else if (instr == 0xAF)
                {
                    byte result = (byte)(a ^ a);
                    a = result;
                    pc++;
                    if (cpuOut)
                        Console.WriteLine("XORed a with a, resulting in a containing 0x" + a.ToString("X2"));
                }
                else if (instr == 0xC3)
                {
                    short newaddr = cart.Read16(pc + 1);
                    pc = newaddr;
                    if (cpuOut)
                        Console.WriteLine("Absolute jump to $" + pc.ToString("X4"));
                }
                else if (instr == 0xE0)
                {
                    pc++;
                    byte offset = cart.Read8(pc);
                    cart.Write8(0xFF00 + offset, a);
                    pc++;
                    if (cpuOut)
                        Console.WriteLine("Register a=0x" + a.ToString("X2") + " copied to $FF" + offset.ToString("X2"));
                }
                else if (instr == 0xF0)
                {
                    pc++;
                    byte offset = cart.Read8(pc);
                    a = cart.Read8(0xFF00 + offset);
                    pc++;
                    if (cpuOut)
                        Console.WriteLine("$FF" + offset.ToString("X2") + "=0x" + a.ToString("X2") + " copied to register a");
                }
                else if(instr == 0xF3)
                {
                    interruptsEnabled = false;
                    pc++;
                    if (cpuOut)
                        Console.WriteLine("Interrupts disabled");
                }
                else if(instr == 0xFF)
                {
                    pc = 0x0038;
                    if (cpuOut)
                        Console.WriteLine("Jump to reset vector $0038");
                }
                else
                {
                    cpuOut = true;
                    Console.WriteLine("Unimplemented instr 0x" + instr.ToString("X2") + " @ $" + pc.ToString("x4") + ", moving to $" + (pc + 1).ToString("X4"));
                    Console.ReadLine();
                    pc++;
                }
            }
        }
    }
}
