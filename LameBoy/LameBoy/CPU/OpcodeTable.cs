namespace LameBoy
{
    static class OpcodeTable
    {
        private static void SetFlags(ref Registers regs, bool Z, bool S, bool HC, bool CA)
        {
            regs.Z = Z;
            regs.S = S;
            regs.HC = HC;
            regs.CA = CA;
        }

        private static bool CheckHalfCarryAdd(ref byte reg, byte add)
        {
            return (((reg & 0x0F) + (add & 0x0F)) & 0x10) == 0x10;
        }

        private static bool CheckHalfCarrySubtract(ref byte reg, byte sub)
        {
            return (((reg & 0xF0) - (sub & 0xF0)) & 0x08) == 0x08;
        }

        private static bool CheckCarryAdd(ref ushort reg, ushort add)
        {
            return (((reg & 0xF0) - (add & 0xF0)) & 0x100) == 0x100;
        }

        private static bool CheckCarrySubtract()
        {
            return false; //TODO
        }

        public static bool[] ByteToBits(byte start)
        {
            bool[] bits = new bool[8];
            for(int i = 0; i < 8; i++)
            {
                int mask = 1 << i;
                bits[i] = (start & mask) == mask;
            }
            return bits;
        }

        public static byte BitsToByte(bool[] bits)
        {
            byte result = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bits[i])
                {
                    result |= (byte) (1 << i);
                }
            }
            return result;
        }

        private static void DecodeCB(byte opcode, ref Registers regs)
        {
            int instrType = (opcode & 0xC0) >> 6;
            int argument = (opcode & 0x38) >> 3;
            int register = (opcode & 0x7);

            bool[] bits = new bool[0];

            if(instrType == 0)
            {
                //Rotate/Shift
            }
            else if(instrType == 1)
            {
                //Test bit
                if (register == 0)
                {
                    //B
                    bits = ByteToBits(regs.B);
                    regs.Z = !bits[argument];
                }
                if (register == 1)
                {
                    //C
                    bits = ByteToBits(regs.C);
                }
                if (register == 2)
                {
                    //D
                    bits = ByteToBits(regs.D);
                }
                if (register == 3)
                {
                    //E
                    bits = ByteToBits(regs.E);
                }
                if (register == 4)
                {
                    //H
                    bits = ByteToBits(regs.H);
                }
                if (register == 5)
                {
                    //L
                    bits = ByteToBits(regs.L);
                }
                if (register == 6)
                {
                    //HL
                    bits = ByteToBits(regs.B);
                }
                if (register == 7)
                {
                    //A
                    bits = ByteToBits(regs.A);
                }
                regs.Z = !bits[argument];
            }
            else if(instrType == 2)
            {
                //Reset bit
                if(register == 0)
                {
                    //B
                    bits = ByteToBits(regs.B);
                    bits[argument] = false;
                    regs.B = BitsToByte(bits);
                }
                if (register == 1)
                {
                    //C
                    bits = ByteToBits(regs.C);
                    bits[argument] = false;
                    regs.C = BitsToByte(bits);
                }
                if (register == 2)
                {
                    //D
                    bits = ByteToBits(regs.D);
                    bits[argument] = false;
                    regs.D = BitsToByte(bits);
                }
                if (register == 3)
                {
                    //E
                    bits = ByteToBits(regs.E);
                    bits[argument] = false;
                    regs.E = BitsToByte(bits);
                }
                if (register == 4)
                {
                    //H
                    bits = ByteToBits(regs.H);
                    bits[argument] = false;
                    regs.H = BitsToByte(bits);
                }
                if (register == 5)
                {
                    //L
                    bits = ByteToBits(regs.L);
                    bits[argument] = false;
                    regs.L = BitsToByte(bits);
                }
                if (register == 6)
                {
                    //HL
                    bits = ByteToBits(regs.B);
                    bits[argument] = false;
                    regs.B = BitsToByte(bits);
                }
                if (register == 7)
                {
                    //A
                    bits = ByteToBits(regs.A);
                    bits[argument] = false;
                    regs.A = BitsToByte(bits);
                }
            }
            else if(instrType == 3)
            {
                //Set bit
                if (register == 0)
                {
                    //B
                    bits = ByteToBits(regs.B);
                    bits[argument] = true;
                    regs.B = BitsToByte(bits);
                }
                if (register == 1)
                {
                    //C
                    bits = ByteToBits(regs.C);
                    bits[argument] = true;
                    regs.C = BitsToByte(bits);
                }
                if (register == 2)
                {
                    //D
                    bits = ByteToBits(regs.D);
                    bits[argument] = true;
                    regs.D = BitsToByte(bits);
                }
                if (register == 3)
                {
                    //E
                    bits = ByteToBits(regs.E);
                    bits[argument] = true;
                    regs.E = BitsToByte(bits);
                }
                if (register == 4)
                {
                    //H
                    bits = ByteToBits(regs.H);
                    bits[argument] = true;
                    regs.H = BitsToByte(bits);
                }
                if (register == 5)
                {
                    //L
                    bits = ByteToBits(regs.L);
                    bits[argument] = true;
                    regs.L = BitsToByte(bits);
                }
                if (register == 6)
                {
                    //HL
                    bits = ByteToBits(regs.B);
                    bits[argument] = true;
                    regs.B = BitsToByte(bits);
                }
                if (register == 7)
                {
                    //A
                    bits = ByteToBits(regs.A);
                    bits[argument] = true;
                    regs.A = BitsToByte(bits);
                }
            }
        }

        //DO NOT INCREMENT PC HERE! DO NOT INCREMENT PC HERE!
        public static readonly Opcode[] Table =
        {
/*0x00*/    new Opcode("NOP",             0, 1,    (ref Registers regs, Memory mem) => { }),
            new Opcode("LD BC, 0x{0:X4}", 2, 3,    (ref Registers regs, Memory mem) => { regs.BC = regs.Immediate16; }),
            new Opcode("LD (BC), A",      0, 1, 8, (ref Registers regs, Memory mem) => { mem[regs.BC] = regs.A; }),
            new Opcode("INC BC",          0, 1, 8, (ref Registers regs, Memory mem) => { regs.BC++; }),
            new Opcode("INC B",           0, 1,    (ref Registers regs, Memory mem) => { regs.B++; SetFlags(ref regs, regs.B == 0x00, false, CheckHalfCarryAdd(ref regs.B, 0x01), regs.CA); }),
            new Opcode("DEC B",           0, 1,    (ref Registers regs, Memory mem) => { regs.B--; SetFlags(ref regs, regs.B == 0x00, true, CheckHalfCarrySubtract(ref regs.B, 0x01), regs.CA); }),
            new Opcode("LD B, 0x{0:X2}",  1, 2,    (ref Registers regs, Memory mem) => { regs.B = regs.Immediate8; }),
            new Opcode("RLC A",           0, 1,    (ref Registers regs, Memory mem) => { SetFlags(ref regs, false, false, false, ((regs.A & 0x80) == 0x80)); regs.A = (byte)((regs.A << 1) | (regs.A >> 7)); }),
            new Opcode("LD (${0:X4}), SP",2, 3, 20,(ref Registers regs, Memory mem) => { mem.Write16(regs.Immediate16, regs.SP); }),
            new Opcode("ADD HL, BC",      0, 1, 8, (ref Registers regs, Memory mem) => { regs.HL += regs.BC; }),
            new Opcode("LD A, (BC)",      0, 1, 8, (ref Registers regs, Memory mem) => { regs.A = mem[regs.BC]; }),
            new Opcode("DEC BC",          0, 1, 8, (ref Registers regs, Memory mem) => { regs.BC--; }),
            new Opcode("INC C",           0, 1,    (ref Registers regs, Memory mem) => { regs.C++; SetFlags(ref regs, regs.C == 0x00, false, CheckHalfCarryAdd(ref regs.C, 0x01), regs.CA); }),
            new Opcode("DEC C",           0, 1,    (ref Registers regs, Memory mem) => { regs.C--; SetFlags(ref regs, regs.C == 0x00, true, CheckHalfCarrySubtract(ref regs.C, 0x01), regs.CA); }),
            new Opcode("LD C, 0x{0:X2}",  1, 2,    (ref Registers regs, Memory mem) => { regs.C = regs.Immediate8; }),
            new Opcode("RRC A",           0, 1,    (ref Registers regs, Memory mem) => { regs.A = (byte)((regs.A >> 1) | (regs.A << 7)); }),
/*0x10*/    new Opcode("STOP",            0, 2,    (ref Registers regs, Memory mem) => { /*do nothing because the CPU should handle this*/ }),
            new Opcode("LD DE, 0x{0:X4}", 2, 3,    (ref Registers regs, Memory mem) => { regs.DE = regs.Immediate16; }),
            new Opcode("LD (DE), A",      0, 1, 8, (ref Registers regs, Memory mem) => { mem[regs.DE] = regs.A; }),
            new Opcode("INC DE",          0, 1, 8, (ref Registers regs, Memory mem) => { regs.DE++; }),
            new Opcode("INC D",           0, 1,    (ref Registers regs, Memory mem) => { regs.D++; }),
            new Opcode("DEC D",           0, 1,    (ref Registers regs, Memory mem) => { regs.D--; }),
            new Opcode("LD D, 0x{0:X2}",  1, 2,    (ref Registers regs, Memory mem) => { regs.D = regs.Immediate8; }),
            new Opcode("RL A",            0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/ }),
            new Opcode("JR ${0:X2}",      1, 2, 12,(ref Registers regs, Memory mem) => { regs.PC = (ushort)(regs.PC + (sbyte)regs.Immediate8); }),
            new Opcode("ADD HL, DE",      0, 1, 8, (ref Registers regs, Memory mem) => { regs.HL += regs.DE; }),
            new Opcode("LD A, (DE)",      0, 1, 8, (ref Registers regs, Memory mem) => { regs.A = mem[regs.DE]; }),
            new Opcode("DEC DE",          0, 1, 8, (ref Registers regs, Memory mem) => { regs.DE--; }),
            new Opcode("INC E",           0, 1,    (ref Registers regs, Memory mem) => { regs.E++; }),
            new Opcode("DEC E",           0, 1,    (ref Registers regs, Memory mem) => { regs.E--; }),
            new Opcode("LD E, 0x{0:X2}",  1, 1, 8, (ref Registers regs, Memory mem) => { regs.E = mem[regs.Immediate8]; }),
            new Opcode("RR A",            0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x20*/    new Opcode("JR NZ, ${0:X2}",  1, 2, 8, (ref Registers regs, Memory mem) => { if(regs.Z) return; if(regs.Immediate8 >= 128) regs.PC -= (ushort) (256 - regs.Immediate8); else regs.PC += regs.Immediate8; }),
            new Opcode("LD HL, 0x{0:X4}", 2, 3,    (ref Registers regs, Memory mem) => { regs.HL = regs.Immediate16; }),
            new Opcode("LD (HL+), A",     0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC HL",          0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC H",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC H",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, 0x{0:X2}",  0, 2, 8, (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("RLA",             0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JR 0x{0:X2}",     0, 2, 12,(ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD HL, DE",      0, 1, 8, (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, (DE)",      0, 1, 8, (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC DE",          0, 1, 8, (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC E",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC E",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, 0x{0:X2}",  1, 2,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("RRA",             0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x30*/    new Opcode("JR NC,r8",        1, 2, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD SP,0x{0:X4}",  2, 3, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LDD (HL), A",     0, 2,    (ref Registers regs, Memory mem) => { mem.Write8(regs.HL, regs.A); regs.HL--; }),
            new Opcode("INC SP",          0, 1, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL),0x{0:X2}",1, 3,    (ref Registers regs, Memory mem) => { mem.Write8(regs.HL, regs.Immediate8); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, 0x{0:X2}",  1, 2,    (ref Registers regs, Memory mem) => { regs.A = regs.Immediate8; }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x40*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x50*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x60*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x70*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x80*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x90*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xA0*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR A",           0, 1,    (ref Registers regs, Memory mem) => { regs.A = 0x00; SetFlags(ref regs, true, false, false, false); }), //x ^ x always equals 0
/*0xB0*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xC0*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JP ${0:X4}",      2, 4,    (ref Registers regs, Memory mem) => { regs.PC = regs.Immediate16; }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CB Prefix",           0, 1,    (ref Registers regs, Memory mem) => { DecodeCB(regs.Immediate8, ref regs); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xD0*/    new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xE0*/    new Opcode("LD $FF00+{0:X2}, A", 1, 3, (ref Registers regs, Memory mem) => { mem.Write8(0xFF00 + regs.Immediate8, regs.A); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD $FF00+C, A",   0, 2,    (ref Registers regs, Memory mem) => { mem.Write8(0xFF00 + regs.C, regs.A);}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD ${0:X4}, A",   2, 4,    (ref Registers regs, Memory mem) => { mem.Write8(regs.Immediate16, regs.A); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xF0*/    new Opcode("LD A, $FF{0:X2}", 1, 3,    (ref Registers regs, Memory mem) => { regs.A = mem.Read8(0xFF00 + regs.Immediate8); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DI",              0, 1,    (ref Registers regs, Memory mem) => { regs.Interrupts = false; }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP A, {0:X2}",    1, 2,    (ref Registers regs, Memory mem) => { SetFlags(ref regs, regs.A - regs.Immediate8 == 0, true, CheckHalfCarrySubtract(ref regs.A, regs.Immediate8), CheckCarrySubtract()); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
        };
    }
}
