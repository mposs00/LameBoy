using System;
using System.Linq;

namespace LameBoy
{
    public class Memory
    {
        byte[] mem;

        public Memory(int size)
        {
            mem = new byte[size];
        }

        public Memory(byte[] arr)
        {
            mem = arr;
        }

        public byte this[int addr]
        {
            get { return mem[addr]; }
            set { mem[addr] = value; }
        }

        public byte Read8(int addr)
        {
            return mem[addr];
        }

        public ushort Read16(int addr)
        {
            byte upper = Read8(addr + 1);
            byte lower = Read8(addr);
            ushort result = (ushort)((upper << 8) + (lower & 0xFF));
            return result;
        }

        public void Write8(int addr, byte data)
        {
            mem[addr] = data;
        }

        public void Write16(int addr, ushort data)
        {
            byte upper = (byte)((data & 0xFF00) >> 8);
            byte lower = (byte)(data & 0xFF);
            Write8(addr + 1, upper);
            Write8(addr, lower);
        }

        public void CopyInto(Memory destin)
        {
            Array.Copy(mem, destin.mem, Length);
        }

        public int Length
        {
            get { return mem.Length; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Memory))
                return false;
            return ((Memory)obj).mem == mem || ((Memory)obj).mem.SequenceEqual(mem);
        }

        public override int GetHashCode()
        {
            return mem.GetHashCode();
        }
    }
}
