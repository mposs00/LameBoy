using System;
using System.IO;

namespace LameBoy
{
    public enum CartType
    {
        ROM                     = 0x00,
        MBC1                    = 0x01,
        MBC1_RAM                = 0x02,
        MBC1_RAM_Battery        = 0x03,
        MBC2                    = 0x05,
        MBC2_Battery            = 0x06,
        ROM_RAM                 = 0x08,
        ROM_RAM_Battery         = 0x09,
        MMM01                   = 0x0B,
        MMM01_RAM               = 0x0C,
        MMM01_RAM_Battery       = 0x0D,
        MBC3_Timer_Battery      = 0x0F,
        MBC3_Timer_RAM_Battery  = 0x10,
        MBC3                    = 0x11,
        MBC3_RAM                = 0x12,
        MBC3_RAM_Battery        = 0x13,
        MBC4                    = 0x15,
        MBC4_RAM                = 0x16,
        MBC4_RAM_Battery        = 0x17,
        MBC5                    = 0x19,
        MBC5_RAM                = 0x1A,
        MBC5_RAM_Battery        = 0x1B,
        MBC5_Rumble             = 0x1C,
        MBC5_Rumble_RAM         = 0x1D,
        MBC5_Rumble_RAM_Battery = 0x1E,
        Camera                  = 0xFC,
        Bandai                  = 0xFD,
        HUC3                    = 0xFE,
        HUC1_RAM_Battery        = 0xFF,
        Unknown
    }

    public class Cart
    {
        string romName;
        byte[] ROM;
        byte[] RAM;

        public Cart(string romName)
        {
            this.romName = romName;
            RAM = new byte[0xFFFF + 1];
            ROM = File.ReadAllBytes(romName);
            Array.Copy(ROM, 0, RAM, 0, ROM.Length);
        }

        public CartType GetCartType()
        {
            if (Enum.IsDefined(typeof(CartType), (int) ROM[0x147]))
                return (CartType)ROM[0x147];
            else
                //Better to just throw an exception, but whatever.
                return CartType.Unknown;
        }

        public byte Read8(int addr)
        {
            if(GetCartType() == CartType.ROM)
            {
                return RAM[addr];
            }
            return 0x00;
        }

        public short Read16(int addr)
        {
            byte upper = Read8(addr + 1);
            byte lower = Read8(addr);
            short result = (short)((upper << 8) + (lower & 0xFF));
            return result;
        }

        public void Write8(int addr, byte data)
        {
            if(GetCartType() == CartType.ROM)
            {
                RAM[addr] = data;
            }
        }

        public void Write16(int addr, short data)
        {
            if(GetCartType() == CartType.ROM)
            {
                byte upper = (byte) ((data & 0xFF00) >> 8);
                byte lower = (byte)(data & 0xFF);
                Write8(addr + 1, upper);
                Write8(addr, lower);
            }
        }
    }
}
