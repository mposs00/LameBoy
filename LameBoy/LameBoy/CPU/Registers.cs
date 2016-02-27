namespace LameBoy
{
    public struct Registers
    {
        public bool Interrupts;

        public byte A,
            B,
            C,
            D,
            E,
            H,
            L;
        public ushort SP,
            PC;
        public bool S, //Sign
            Z, //Zero
            F5, //Copy of bit 5 (undocumented)
            HC, //Half carry
            F3, //Copy of bit 3 (undocumented)
            PV, //Parity or overflow
            N, //Subtract
            CA; //Carry

        public byte F { get { return flagsToByte(); } set { byteToFlags(value); } }

        public ushort AF { get { return (ushort)(A << 8 | F); } set { A = (byte)(value >> 8); F = (byte)(value & 0xff); } }
        public ushort BC { get { return (ushort)(B << 8 | C); } set { B = (byte)(value >> 8); C = (byte)(value & 0xff); } }
        public ushort DE { get { return (ushort)(D << 8 | E); } set { D = (byte)(value >> 8); E = (byte)(value & 0xff); } }
        public ushort HL { get { return (ushort)(H << 8 | L); } set { H = (byte)(value >> 8); L = (byte)(value & 0xff); } }

        public ushort Immediate16;
        public byte Immediate8;

        private void byteToFlags(byte conv)
        {
            S =  (conv & 0x80) == 0x80;
            Z =  (conv & 0x40) == 0x40;
            F5 = (conv & 0x20) == 0x20;
            HC = (conv & 0x10) == 0x10;
            F3 = (conv & 0x08) == 0x08;
            PV = (conv & 0x04) == 0x04;
            N =  (conv & 0x02) == 0x02;
            CA = (conv & 0x01) == 0x01;
        }

        private byte flagsToByte()
        {
            return (byte)(
                (S  ? 0x80 : 0) |
                (Z  ? 0x40 : 0) |
                (F5 ? 0x20 : 0) |
                (HC ? 0x10 : 0) |
                (F3 ? 0x08 : 0) |
                (PV ? 0x04 : 0) |
                (N  ? 0x02 : 0) |
                (CA ? 0x01 : 0));
        }
    }
}