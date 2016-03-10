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

        private static void Push(ushort data, ref Memory mem, ref Registers regs)
        {
            mem.Write16(regs.SP, data);
            regs.SP -= 2;
        }

        private static ushort Pop(ref Memory mem, ref Registers regs)
        {
            ushort data = mem.Read8(regs.SP);
            regs.SP += 2;
            return data;
        }

        private static bool[] ByteToBits(byte start)
        {
            bool[] bits = new bool[8];
            for(int i = 0; i < 8; i++)
            {
                int mask = 1 << i;
                bits[i] = (start & mask) == mask;
            }
            return bits;
        }

        private static byte BitsToByte(bool[] bits)
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

        private static void DecodeCB(byte opcode, ref Registers regs, ref Memory mem)
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
                    bits = ByteToBits(mem.Read8(regs.HL));
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
                    bits = ByteToBits(mem.Read8(regs.HL));
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
                    bits = ByteToBits(mem.Read8(regs.HL));
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
/*0x00*/    new Opcode("NOP",             0, 4,    (ref Registers regs, Memory mem) => { }),
            new Opcode("LD BC, 0x{0:X4}", 2, 12,   (ref Registers regs, Memory mem) => { regs.BC = regs.Immediate16; }),
            new Opcode("LD (BC), A",      0, 8,    (ref Registers regs, Memory mem) => { mem[regs.BC] = regs.A; }),
            new Opcode("INC BC",          0, 8,    (ref Registers regs, Memory mem) => { regs.BC++; }),
            new Opcode("INC B",           0, 4,    (ref Registers regs, Memory mem) => { regs.B++; SetFlags(ref regs, regs.B == 0x00, false, CheckHalfCarryAdd(ref regs.B, 0x01), regs.CA); }),
            new Opcode("DEC B",           0, 4,    (ref Registers regs, Memory mem) => { regs.B--; SetFlags(ref regs, regs.B == 0x00, true, CheckHalfCarrySubtract(ref regs.B, 0x01), regs.CA); }),
            new Opcode("LD B, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { regs.B = regs.Immediate8; }),
            new Opcode("RLC A",           0, 4,    (ref Registers regs, Memory mem) => { SetFlags(ref regs, false, false, false, ((regs.A & 0x80) == 0x80)); regs.A = (byte)((regs.A << 1) | (regs.A >> 7)); }),
            new Opcode("LD (${0:X4}), SP",2, 20,   (ref Registers regs, Memory mem) => { mem.Write16(regs.Immediate16, regs.SP); }),
            new Opcode("ADD HL, BC",      0, 8,    (ref Registers regs, Memory mem) => { regs.HL += regs.BC; }),
            new Opcode("LD A, (BC)",      0, 8,    (ref Registers regs, Memory mem) => { regs.A = mem[regs.BC]; }),
            new Opcode("DEC BC",          0, 8,    (ref Registers regs, Memory mem) => { regs.BC--; }),
            new Opcode("INC C",           0, 4,    (ref Registers regs, Memory mem) => { regs.C++; SetFlags(ref regs, regs.C == 0x00, false, CheckHalfCarryAdd(ref regs.C, 0x01), regs.CA); }),
            new Opcode("DEC C",           0, 4,    (ref Registers regs, Memory mem) => { regs.C--; SetFlags(ref regs, regs.C == 0x00, true, CheckHalfCarrySubtract(ref regs.C, 0x01), regs.CA); }),
            new Opcode("LD C, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { regs.C = regs.Immediate8; }),
            new Opcode("RRC A",           0, 4,    (ref Registers regs, Memory mem) => { regs.A = (byte)((regs.A >> 1) | (regs.A << 7)); }),
/*0x10*/    new Opcode("STOP",            0, 4,    (ref Registers regs, Memory mem) => { /*do nothing because the CPU should handle this*/ }),
            new Opcode("LD DE, 0x{0:X4}", 2, 12,   (ref Registers regs, Memory mem) => { regs.DE = regs.Immediate16; }),
            new Opcode("LD (DE), A",      0, 8,    (ref Registers regs, Memory mem) => { mem[regs.DE] = regs.A; }),
            new Opcode("INC DE",          0, 8,    (ref Registers regs, Memory mem) => { regs.DE++; }),
            new Opcode("INC D",           0, 4,    (ref Registers regs, Memory mem) => { regs.D++; }),
            new Opcode("DEC D",           0, 4,    (ref Registers regs, Memory mem) => { regs.D--; }),
            new Opcode("LD D, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { regs.D = regs.Immediate8; }),
            new Opcode("RL A",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/ }),
            new Opcode("JR ${0:X2}",      1, 12,   (ref Registers regs, Memory mem) => { regs.PC = (ushort)(regs.PC + (sbyte)regs.Immediate8); }),
            new Opcode("ADD HL, DE",      0, 8,    (ref Registers regs, Memory mem) => { regs.HL += regs.DE; }),
            new Opcode("LD A, (DE)",      0, 8,    (ref Registers regs, Memory mem) => { regs.A = mem[regs.DE]; }),
            new Opcode("DEC DE",          0, 8,    (ref Registers regs, Memory mem) => { regs.DE--; }),
            new Opcode("INC E",           0, 1,    (ref Registers regs, Memory mem) => { regs.E++; }),
            new Opcode("DEC E",           0, 4,    (ref Registers regs, Memory mem) => { regs.E--; }),
            new Opcode("LD E, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { regs.E = mem[regs.Immediate8]; }),
            new Opcode("RR A",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x20*/    new Opcode("JR NZ, ${0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { if(regs.Z) return; if(regs.Immediate8 >= 128) regs.PC -= (ushort) (256 - regs.Immediate8); else regs.PC += regs.Immediate8; }),
            new Opcode("LD HL, 0x{0:X4}", 2, 12,   (ref Registers regs, Memory mem) => { regs.HL = regs.Immediate16; }),
            new Opcode("LD (HL+), A",     0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC HL",          0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC H",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC H",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, 0x{0:X2}",  0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("RLA",             0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JR 0x{0:X2}",     0, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD HL, DE",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, (DE)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC DE",          0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC E",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC E",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("RRA",             0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x30*/    new Opcode("JR NC,r8",        1, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD SP,0x{0:X4}",  2, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LDD (HL), A",     0, 8,    (ref Registers regs, Memory mem) => { mem.Write8(regs.HL, regs.A); regs.HL--; }),
            new Opcode("INC SP",          0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC (HL)",        0, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC (HL)",        0, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL),0x{0:X2}",1, 12,   (ref Registers regs, Memory mem) => { mem.Write8(regs.HL, regs.Immediate8); }),
            new Opcode("SCF",             0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JR C, 0x{0:X2}",  1, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD HL, SP",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, (HL-)",     0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC SP",          0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("INC A",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("DEC A",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, 0x{0:X2}",  1, 8,    (ref Registers regs, Memory mem) => { regs.A = regs.Immediate8; }),
            new Opcode("CCF",             0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x40*/    new Opcode("LD B, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD B, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD C, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x50*/    new Opcode("LD D, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD D, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD E, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x60*/    new Opcode("LD H, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD H, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD L, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x70*/    new Opcode("LD (HL), B",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), C",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), D",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), E",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), H",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), L",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("HALT",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD (HL), A",      0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, B",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, C",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, D",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, E",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, H",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, L",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, (HL)",      0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD A, A",         0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x80*/    new Opcode("ADD A, B",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, C",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, D",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, E",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, H",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, L",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, (HL)",     0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADD A, A",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, B",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, C",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, D",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, E",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, H",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, L",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, (HL)",     0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("ADC A, A",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x90*/    new Opcode("SUB B",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB C",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB D",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB E",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB H",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB L",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB (HL)",        0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SUB A",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, B",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, C",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, D",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, E",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, H",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, L",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, (HL)",     0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("SBC A, A",        0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xA0*/    new Opcode("AND B",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND C",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND D",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND E",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND H",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND L",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND (HL)",        0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("AND A",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR B",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR C",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR D",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR E",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR H",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR L",           0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR (HL)",        0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("XOR A",           0, 4,    (ref Registers regs, Memory mem) => { regs.A = 0x00; SetFlags(ref regs, true, false, false, false); }), //x ^ x always equals 0
/*0xB0*/    new Opcode("OR B",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR C",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR D",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR E",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR H",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR L",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR (HL)",         0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("OR A",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP B",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP C",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP D",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP E",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP H",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP L",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP (HL)",         0, 8,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CP A",            0, 4,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xC0*/    new Opcode("RET NZ",          0, 20,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("POP BC",          0, 12,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JP NZ, ${0:X4}",  0, 16,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("JP ${0:X4}",      2, 16,   (ref Registers regs, Memory mem) => { regs.PC = regs.Immediate16; }),
            new Opcode("CALL NZ, ${0:X4}",0, 24,   (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("RET",             0, 16,   (ref Registers regs, Memory mem) => { regs.PC = Pop(ref mem, ref regs); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CB Prefix",       0, 1,    (ref Registers regs, Memory mem) => { DecodeCB(regs.Immediate8, ref regs, ref mem); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("CALL ${0:X4}",    0, 24,   (ref Registers regs, Memory mem) => { regs.PC += 3; Push(regs.PC, ref mem, ref regs); regs.PC = regs.Immediate16; }), //Don't change length on call/ret, it screws everything up
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
/*0xE0*/    new Opcode("LD $FF00+{0:X2}, A", 1, 12,(ref Registers regs, Memory mem) => { mem.Write8(0xFF00 + regs.Immediate8, regs.A); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD $FF00+C, A",   0, 2,    (ref Registers regs, Memory mem) => { mem.Write8(0xFF00 + regs.C, regs.A);}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("LD ${0:X4}, A",   2, 16,   (ref Registers regs, Memory mem) => { mem.Write8(regs.Immediate16, regs.A); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0xF0*/    new Opcode("LD A, $FF{0:X2}", 1, 12,   (ref Registers regs, Memory mem) => { regs.A = mem.Read8(0xFF00 + regs.Immediate8); }),
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
            new Opcode("CP A, {0:X2}",    1, 8,    (ref Registers regs, Memory mem) => { SetFlags(ref regs, regs.A - regs.Immediate8 == 0, true, CheckHalfCarrySubtract(ref regs.A, regs.Immediate8), CheckCarrySubtract()); }),
            new Opcode("UNIMP",           0, 1,    (ref Registers regs, Memory mem) => { /*TODO*/}),
        };
    }
}
