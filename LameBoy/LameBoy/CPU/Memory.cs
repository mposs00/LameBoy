using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ushort Read16(int addr)
        {
            byte upper = mem[addr + 1];
            byte lower = mem[addr];
            ushort result = (ushort)((upper << 8) + (lower & 0xFF));
            return result;
        }

        public void Write16(int addr, ushort data)
        {
            byte upper = (byte)((data & 0xFF00) >> 8);
            byte lower = (byte)(data & 0xFF);
            mem[addr + 1] = upper;
            mem[addr] = lower;
        }

        public void CopyInto(Memory destin)
        {
            Array.Copy(mem, destin.mem, Length);
        }

        public int Length
        {
            get { return mem.Length; }
        }
    }
}
