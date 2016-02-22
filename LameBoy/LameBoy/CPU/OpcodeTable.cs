namespace LameBoy
{
    static class OpcodeTable
    {
        //DO NOT INCREMENT PC HERE! DO NOT INCREMENT PC HERE!
        public static readonly Opcode[] Table =
{
/*0x00*/    new Opcode("NOP",             0, (ref Registers regs, Memory mem) => { }),
            new Opcode("LD BC, {0}",      1, (ref Registers regs, Memory mem) => { regs.BC = regs.Immediate16_1; }),
            new Opcode("LD (BC), A",      0, (ref Registers regs, Memory mem) => { mem[regs.BC] = regs.A; }),
            new Opcode("INC BC",          0, (ref Registers regs, Memory mem) => { regs.BC++; }),
            new Opcode("INC B",           0, (ref Registers regs, Memory mem) => { regs.B++; }),
            new Opcode("DEC B",           0, (ref Registers regs, Memory mem) => { regs.B--; }),
            new Opcode("LD B, {0}",       1, (ref Registers regs, Memory mem) => { regs.B = regs.Immediate8_1; }),
            new Opcode("RLC A",           0, (ref Registers regs, Memory mem) => { regs.A = (byte)((regs.A << 1) | (regs.A >> 7)); }),
            new Opcode("LD ({0}), SP",    1, (ref Registers regs, Memory mem) => { mem.Write16(regs.Immediate16_1, regs.SP); }),
            new Opcode("ADD HL, BC",      0, (ref Registers regs, Memory mem) => { regs.HL += regs.BC; }),
            new Opcode("LD A, (BC)",      0, (ref Registers regs, Memory mem) => { regs.A = mem[regs.BC]; }),
            new Opcode("DEC BC",          0, (ref Registers regs, Memory mem) => { regs.BC--; }),
            new Opcode("INC C",           0, (ref Registers regs, Memory mem) => { regs.C++; }),
            new Opcode("DEC C",           0, (ref Registers regs, Memory mem) => { regs.C--; }),
            new Opcode("LD C, {0}",       1, (ref Registers regs, Memory mem) => { regs.C = regs.Immediate8_1; }),
            new Opcode("RRC A",           0, (ref Registers regs, Memory mem) => { regs.A = (byte)((regs.A >> 1) | (regs.A << 7)); }),
/*0x10*/    new Opcode("STOP",            0, (ref Registers regs, Memory mem) => { /*do nothing because the CPU should handle this*/ }),
            new Opcode("LD DE, {0}",      1, (ref Registers regs, Memory mem) => { regs.DE = regs.Immediate16_1; }),
            new Opcode("LD (DE), A",      0, (ref Registers regs, Memory mem) => { mem[regs.DE] = regs.A; }),
            new Opcode("INC DE",          0, (ref Registers regs, Memory mem) => { regs.DE++; }),
            new Opcode("INC D",           0, (ref Registers regs, Memory mem) => { regs.D++; }),
            new Opcode("DEC D",           0, (ref Registers regs, Memory mem) => { regs.D--; }),
            new Opcode("LD D, {0}",       1, (ref Registers regs, Memory mem) => { regs.D = regs.Immediate8_1; }),
            new Opcode("RL A",            0, (ref Registers regs, Memory mem) => { /*TODO*/ }),
            new Opcode("JR {0}",          1, (ref Registers regs, Memory mem) => { regs.PC = (ushort)(regs.PC + (sbyte)regs.Immediate8_1); }),
            new Opcode("ADD HL, DE",      0, (ref Registers regs, Memory mem) => { regs.HL += regs.DE; }),
            new Opcode("LD A, (DE)",      0, (ref Registers regs, Memory mem) => { regs.A = mem[regs.DE]; }),
            new Opcode("DEC DE",          0, (ref Registers regs, Memory mem) => { regs.DE--; }),
            new Opcode("INC E",           0, (ref Registers regs, Memory mem) => { regs.E++; }),
            new Opcode("DEC E",           0, (ref Registers regs, Memory mem) => { regs.E--; }),
            new Opcode("LD E, {0}",       1, (ref Registers regs, Memory mem) => { regs.E = mem[regs.Immediate8_1]; }),
            new Opcode("RR A",            0, (ref Registers regs, Memory mem) => { /*TODO*/}),
/*0x20*/    
        };
    }
}
