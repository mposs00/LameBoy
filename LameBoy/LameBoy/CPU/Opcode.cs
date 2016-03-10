namespace LameBoy
{
    public struct Opcode
    {
        public readonly string Disassembly;
        public readonly byte Length;
        public delegate void Exec(ref Registers reg, Memory RAM);
        public readonly Exec Execute;
        public readonly byte T, M;

        public Opcode(string disasm, byte operands, byte t, byte m, Exec exe)
        {
            Disassembly = disasm;
            Length = operands;
            Execute = exe;
            T = t;
            M = m;
        }

        public Opcode(string disasm, byte operands, byte t, Exec exe) :
            this(disasm, operands, t, (byte)(t / 4), exe)
        { }
    }
}