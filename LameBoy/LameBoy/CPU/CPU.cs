using System;
using LameBoy.Graphics;
using System.Diagnostics;
using System.Threading;

namespace LameBoy
{
    class CPU
    {
        Registers registers = new Registers { PC = 0x100 };

        //bool interruptsEnabled = true;
        Cart cart;
        GPU gpu;
        byte instr;
        bool debugOut = false;

        public CPU(IntPtr Handle, IntPtr pgHandle)
        {
            gpu = new GPU(Handle, pgHandle);
            Thread GPUThread = new Thread(new ThreadStart(gpu.RenderScene));
            GPUThread.Start();
            //Thread sdlThread = new Thread(new ThreadStart(sdlt.Render));
        }

        public void SetCart(Cart NewCart)
        {
            cart = NewCart;
            gpu.SetCart(cart);
        }

        //Main interpreter loop
        public void exec()
        {
            while (true)
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
                if (opcode.Disassembly == "UNIMP")
                {
                    debugOut = true;
                    Console.WriteLine("Unimplemented opcode: {0:X2}", instr);
                    Console.ReadLine();
                }
                registers.PC += opcode.Length;
                registers.PC++;
                opcode.Execute(ref registers, cart.RAM);
                gpu.SetCPUExecutionState(false);
            }
        }
    }
}
