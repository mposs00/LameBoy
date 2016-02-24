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
            //I don't know any better way to do this
            //Can you convert each bit into a bool?
            //That would be fantastic
            if ((conv & 0x80) == 0x80)
                S = true;
            else
                S = false;
            if ((conv & 0x40) == 0x40)
                Z = true;
            else
                Z = false;
            if ((conv & 0x20) == 0x20)
                F5 = true;
            else
                F5 = false;
            if ((conv & 0x10) == 0x10)
                HC = true;
            else
                HC = false;
            if ((conv & 0x08) == 0x08)
                F3 = true;
            else
                F3 = false;
            if ((conv & 0x04) == 0x04)
                PV = true;
            else
                PV = false;
            if ((conv & 0x02) == 0x02)
                N = true;
            else
                N = false;
            if ((conv & 0x01) == 0x01)
                CA = true;
            else
                CA = false;
        }

        private byte flagsToByte()
        {
            byte result = 0x00;
            if (S)
                result |= 0x80;
            if (Z)
                result |= 0x40;
            if (F5)
                result |= 0x20;
            if (HC)
                result |= 0x10;
            if (F3)
                result |= 0x08;
            if (PV)
                result |= 0x04;
            if (N)
                result |= 0x02;
            if (CA)
                result |= 0x01;
            return result;
        }
    }
}