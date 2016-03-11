using System;
using LameBoy.Graphics;
using System.IO;
using System.Text;
using System.Threading;

namespace LameBoy
{
    public class CPU
    {
        Registers registers = new Registers { PC = 0x100 };

        Cart cart;
        GPU gpu;
        byte instr;
        bool debugOut = true;
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
            StringBuilder sb = new StringBuilder();
            while (running)
            {
                while (gpu.drawing) { }

                gpu.SetCPUExecutionState(true);
                instr = cart.Read8(registers.PC);
                var opcode = OpcodeTable.Table[instr];
                registers.Immediate8 = cart.Read8(registers.PC + 1);
                registers.Immediate16 = cart.Read16(registers.PC + 1);

                //debug output
                if (debugOut)
                {
                    string disasm = opcode.Disassembly;
                    if (disasm.Contains("X4"))
                        disasm = String.Format(disasm, registers.Immediate16);
                    else if (disasm.Contains("X2"))
                        disasm = String.Format(disasm, registers.Immediate8, "{0:X2}");
                    if (disasm.Contains("X2"))
                        disasm = String.Format(disasm, registers.A);
                    sb.Clear();
                    sb.Append("PC: $");
                    sb.Append(registers.PC.ToString("X4"));
                    sb.Append(" Disasm: ");
                    sb.Append(disasm);
                    sb.Append(" Opcode: ");
                    sb.Append(instr.ToString("X2"));
                    sb.Append("\n");
                    File.AppendAllText(@"C:\Users\Denton\Desktop\log.txt", sb.ToString());
                }
                if (opcode.Disassembly.Contains("UNIMP"))
                {
                    string disasm = opcode.Disassembly;
                    if (disasm.Contains("X4"))
                        disasm = String.Format(disasm, registers.Immediate16);
                    else if (disasm.Contains("X2"))
                        disasm = String.Format(disasm, registers.Immediate8);
                    //debugOut = true;
                    Console.WriteLine("Unimplemented opcode: {0:X2}", instr);
                    Console.WriteLine("PC: ${0:X4} Disasm: {1} Opcode: {2:X2}", registers.PC, disasm, instr);
                    Console.ReadLine();
                }

                registers.PC += opcode.Length;
                registers.PC++;
                opcode.Execute(ref registers, cart.RAM);
                gpu.SetCPUExecutionState(false);
                if (gpu.GetYCounter() == 154 && registers.Interrupts)
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
