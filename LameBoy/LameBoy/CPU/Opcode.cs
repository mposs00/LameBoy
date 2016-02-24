namespace LameBoy
{
    public struct Opcode
    {
        public readonly string Disassembly;
        public readonly byte Length;
        public delegate void Exec(ref Registers reg, Memory RAM);
        public readonly Exec Execute;

        public Opcode(string disasm, byte operands, Exec exe)
        {
            Disassembly = disasm;
            Length = operands;
            Execute = exe;
        }
    }
}