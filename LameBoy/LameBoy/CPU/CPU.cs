using System;
using LameBoy.Graphics;
using System.Diagnostics;
using System.Threading;

namespace LameBoy
{
    public class CPU
    {
        Registers registers = new Registers { PC = 0x100 };

        //bool interruptsEnabled = true;
        Cart cart;
        GPU gpu;
        byte instr;
        bool debugOut = false;
        bool running;

        public CPU(GPU gpu)
        {
            this.gpu = gpu;
            //Thread sdlThread = new Thread(new ThreadStart(sdlt.Render));
            running = true;
        }

        public void SetCart(Cart NewCart)
        {
            cart = NewCart;
            gpu.SetCart(cart);
        }

        public void SetScale(int scale)
        {
            gpu.SetScale(scale);
        }

        public void VblankInterrupt()
        {
            gpu.SetCPUExecutionState(true);
            registers.Immediate16 = 0x0040;
            var opcode = OpcodeTable.Table[0xCD];
            opcode.Execute(ref registers, cart.RAM);
            gpu.SetCPUExecutionState(false);
        }

        //Main interpreter loop
        public void Execute()
        {
            while (running)
            {
                gpu.SetCPUExecutionState(true);
                instr = cart.Read8(registers.PC);
                var opcode = OpcodeTable.Table[instr];
                registers.Immediate8 = cart.Read8(registers.PC + 1);
                registers.Immediate16 = cart.Read16(registers.PC + 1);
                if (debugOut)
                {
                    string disasm = opcode.Disassembly;
                    if (disasm.Contains("X4"))
                        disasm = String.Format(disasm, registers.Immediate16);
                    else if (disasm.Contains("X2"))
                        disasm = String.Format(disasm, registers.Immediate8);
                    Console.WriteLine("PC: ${0:X4} Disasm: {1} Opcode: {2:X2}", registers.PC, disasm, instr);
                }
                if (opcode.Disassembly.Contains("UNIMP"))
                {
                    //debugOut = true;
                    Console.WriteLine("Unimplemented opcode: {0:X2}", instr);
                    string disasm = opcode.Disassembly;
                    if (disasm.Contains("X4"))
                        disasm = String.Format(disasm, registers.Immediate16);
                    else if (disasm.Contains("X2"))
                        disasm = String.Format(disasm, registers.Immediate8);
                    Console.WriteLine("PC: ${0:X4} Disasm: {1} Opcode: {2:X2}", registers.PC, disasm, instr);
                    Console.ReadLine();
                }
                registers.PC += opcode.Length;
                registers.PC++;
                opcode.Execute(ref registers, cart.RAM);
                gpu.SetCPUExecutionState(false);
                if (gpu.GetYCounter() == 154)
                {
                    VblankInterrupt();
                }
            }
        }

        public void Terminate()
        {
            running = false;
        }
    }
}
