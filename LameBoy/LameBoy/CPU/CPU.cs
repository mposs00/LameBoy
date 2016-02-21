using System;
using System.Diagnostics;

namespace LameBoy
{
    class CPU
    {
        Registers registers = new Registers { PC = 0x100 };

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
                instr = cart.Read8(registers.PC);
                if (cpuOut)
                {
                    Debug.WriteLine("PC: $" + registers.PC.ToString("X4"));
                    Debug.WriteLine("Instruction: 0x" + instr.ToString("X2"));
                }
                if (instr == 0x00)
                {
                    registers.PC++;
                    if (cpuOut)
                        Debug.WriteLine("NOP");
                }
                else if (instr == 0x05)
                {
                    registers.B--;
                    registers.PC++;
                    if (registers.B == 0x00)
                        registers.F += 0x40; //0x40 = 0b01000000, zero flag
                    else
                        registers.F = 0;
                    if (cpuOut)
                        Debug.WriteLine("Decremented b to 0x" + registers.B.ToString("X2"));
                }
                else if (instr == 0x06)
                {
                    byte data = cart.Read8(registers.PC + 1);
                    registers.B = data;
                    registers.PC += 2;
                    if (cpuOut)
                        Debug.WriteLine("Loaded value 0x" + data.ToString("X2") + " into b, advanced to $" + registers.PC.ToString("X4"));
                }
                else if (instr == 0x0D)
                {
                    registers.C--;
                    registers.PC++;
                    if (registers.C == 0x00)
                        registers.F += 0x40;
                    else
                        registers.F = 0;
                    if (cpuOut)
                        Debug.WriteLine("Decremented c to 0x" + registers.C.ToString("X2"));
                }
                else if (instr == 0x0E)
                {
                    byte data = cart.Read8(registers.PC + 1);
                    registers.C = data;
                    registers.PC += 2;
                    if (cpuOut)
                        Debug.WriteLine("Loaded value 0x" + data.ToString("X2") + " into c, advanced to $" + registers.PC.ToString("X4"));
                }
                else if (instr == 0x20)
                {
                    if (!((registers.F & 0x40) == 0x40))
                    {
                        //Relative jumps are stored as a two's complement binary number, and must account for the instruction
                        //just executed, so the PC must also be incremented
                        registers.PC++;
                        byte loc = cart.Read8(registers.PC);
                        bool negative = ((loc & 0x80) == 0x80);
                        if (negative)
                        {
                            loc = (byte)(255 - loc);
                            registers.PC -= loc;
                        }
                        else
                        {
                            registers.PC += loc;
                        }
                        if (cpuOut)
                            Debug.WriteLine("PC advanced by 0x" + loc.ToString("X2") + " to address $" + registers.PC.ToString("X4"));
                    }
                    else
                    {
                        registers.PC += 2;
                        if (cpuOut)
                            Debug.WriteLine("Zero flag set, PC incremented");
                    }
                    registers.F = 0;
                }
                else if (instr == 0x21)
                {
                    ushort data = (ushort)cart.Read16(registers.PC + 1);
                    registers.HL = data;
                    registers.PC += 3;
                    if (cpuOut)
                        Debug.WriteLine("Loaded value 0x" + data.ToString("X4") + " into hl");
                }
                else if (instr == 0x32)
                {
                    cart.Write8(registers.HL, registers.A);
                    if (cpuOut)
                        Debug.WriteLine("a copied to $" + registers.HL.ToString("X2") + " and HL decremented");
                    registers.HL--;
                    registers.PC++;
                }
                else if (instr == 0x3E)
                {
                    registers.PC++;
                    registers.A = cart.Read8(registers.PC);
                    registers.PC++;
                    cpuOut = true;
                    if (cpuOut)
                        Debug.WriteLine("Loaded value 0x" + registers.A.ToString("X2") + " into a");
                }
                else if (instr == 0xAF)
                {
                    byte result = (byte)(registers.A ^ registers.A);
                    registers.A = result;
                    registers.PC++;
                    if (cpuOut)
                        Debug.WriteLine("XORed a with a, resulting in a containing 0x" + registers.A.ToString("X2"));
                }
                else if (instr == 0xC3)
                {
                    ushort newaddr = cart.Read16(registers.PC + 1);
                    registers.PC = newaddr;
                    if (cpuOut)
                        Debug.WriteLine("Absolute jump to $" + registers.PC.ToString("X4"));
                }
                else if (instr == 0xE0)
                {
                    registers.PC++;
                    byte offset = cart.Read8(registers.PC);
                    cart.Write8(0xFF00 + offset, registers.A);
                    registers.PC++;
                    if (cpuOut)
                        Debug.WriteLine("Register a=0x" + registers.A.ToString("X2") + " copied to $FF" + offset.ToString("X2"));
                }
                else if (instr == 0xF0)
                {
                    registers.PC++;
                    byte offset = cart.Read8(registers.PC);
                    registers.A = cart.Read8(0xFF00 + offset);
                    registers.PC++;
                    if (cpuOut)
                        Debug.WriteLine("$FF" + offset.ToString("X2") + "=0x" + registers.A.ToString("X2") + " copied to register a");
                }
                else if(instr == 0xF3)
                {
                    interruptsEnabled = false;
                    registers.PC++;
                    if (cpuOut)
                        Debug.WriteLine("Interrupts disabled");
                }
                else if(instr == 0xFF)
                {
                    registers.PC = 0x0038;
                    if (cpuOut)
                        Debug.WriteLine("Jump to reset vector $0038");
                }
                else
                {
                    cpuOut = true;
                    Debug.WriteLine("Unimplemented instr 0x" + instr.ToString("X2") + " @ $" + registers.PC.ToString("x4") + ", moving to $" + (registers.PC + 1).ToString("X4"));
                    //Console.ReadLine();
                    registers.PC++;
                }
            }
        }
    }
}
