namespace LameBoy
{
    public struct Registers
    {
        public byte A,
            B,
            C,
            D,
            E,
            F,
            H,
            L,
            Flags;
        public ushort SP,
            PC;

        public ushort AF { get { return (ushort)(A << 8 | F); } set { A = (byte)(value >> 8); F = (byte)(value & 0xff); } }
        public ushort BC { get { return (ushort)(B << 8 | C); } set { B = (byte)(value >> 8); C = (byte)(value & 0xff); } }
        public ushort DE { get { return (ushort)(D << 8 | E); } set { D = (byte)(value >> 8); E = (byte)(value & 0xff); } }
        public ushort HL { get { return (ushort)(H << 8 | L); } set { H = (byte)(value >> 8); L = (byte)(value & 0xff); } }

        public ushort Immediate16_1, Immediate16_2;
        public byte Immediate8_1, Immediate8_2;
    }
}