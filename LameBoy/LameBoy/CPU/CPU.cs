using System;
using System.Diagnostics;

namespace LameBoy
{
    class CPU
    {
        Registers registers = new Registers { PC = 0x100 };

        //bool interruptsEnabled = true;
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
                instr = cart.Read8(registers.PC);
                var opcode = OpcodeTable.Table[instr];
                registers.Immediate8 = cart.Read8(registers.PC + 1);
                registers.Immediate16 = cart.Read16(registers.PC + 1);
                Console.WriteLine("PC: ${0:X4} Disasm: {1} Direct8: {2:X2} Direct16: {3:X4} Opcode: {4:X2}", registers.PC, opcode.Disassembly, registers.Immediate8, registers.Immediate16, instr);
                if (opcode.Disassembly == "UNIMP")
                {
                    Console.WriteLine("Unimplemented opcode: {0:X2}", instr);
                    Console.ReadLine();
                }
                registers.PC += opcode.Length;
                registers.PC++;
                opcode.Execute(ref registers, cart.RAM);
                //Console.ReadLine();
            }
        }
    }
}
