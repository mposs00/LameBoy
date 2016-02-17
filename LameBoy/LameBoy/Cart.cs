using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy
{
    public enum CartType
    {
        ROM,
        MBC1,
        MBC1_RAM,
        MBC1_RAM_BATTERY,
        MBC2,
        MBC2_BATTERY,
        ROM_RAM,
        ROM_RAM_BATTERY,
        MMM01,
        MMM01_RAM,
        MMM01_RAM_BATTERY,
        MBC3_TIMER_BATTERY,
        MBC3_TIMER_RAM_BATTERY,
        MBC3,
        MBC3_RAM,
        MBC3_RAM_BATTERY,
        MBC4,
        MBC4_RAM,
        MBC4_RAM_BATTERY,
        MBC5,
        MBC5_RAM,
        MBC5_RAM_BATTERY,
        MBC5_RUMBLE,
        MBC5_RUMBLE_RAM,
        MBC5_RUMBLE_RAM_BATTERY,
        CAMERA,
        BANDAI,
        HUC3,
        HUC1_RAM_BATTERY,
        UNKNOWN
    }

    public class Cart
    {
        string romName;
        byte[] ROM;

        public Cart(string romName)
        {
            this.romName = romName;
            ROM = File.ReadAllBytes(romName);
        }

        public CartType GetCartType()
        {
            switch (ROM[0x147])
            {
                case 0x00:
                    return CartType.ROM;
                case 0x01:
                    return CartType.MBC1;
                case 0x02:
                    return CartType.MBC1_RAM;
                case 0x03:
                    return CartType.MBC1_RAM_BATTERY;
                case 0x05:
                    return CartType.MBC2;
                case 0x06:
                    return CartType.MBC2_BATTERY;
                case 0x08:
                    return CartType.ROM_RAM;
                case 0x09:
                    return CartType.ROM_RAM_BATTERY;
                case 0x0B:
                    return CartType.MMM01;
                case 0x0C:
                    return CartType.MMM01_RAM;
                case 0x0D:
                    return CartType.MMM01_RAM;
                case 0x0F:
                    return CartType.MBC3_TIMER_BATTERY;
                case 0x10:
                    return CartType.MBC3_TIMER_RAM_BATTERY;
                case 0x11:
                    return CartType.MBC3;
                case 0x12:
                    return CartType.MBC3_RAM;
                case 0x13:
                    return CartType.MBC3_RAM_BATTERY;
                case 0x15:
                    return CartType.MBC4;
                case 0x16:
                    return CartType.MBC4_RAM;
                case 0x17:
                    return CartType.MBC4_RAM_BATTERY;
                case 0x19:
                    return CartType.MBC5;
                case 0x1A:
                    return CartType.MBC5_RAM;
                case 0x1B:
                    return CartType.MBC5_RAM_BATTERY;
                case 0x1C:
                    return CartType.MBC5_RUMBLE;
                case 0x1D:
                    return CartType.MBC5_RUMBLE_RAM;
                case 0x1E:
                    return CartType.MBC5_RUMBLE_RAM_BATTERY;
                case 0xFC:
                    return CartType.CAMERA;
                case 0xFD:
                    return CartType.BANDAI;
                case 0xFE:
                    return CartType.HUC3;
                case 0xFF:
                    return CartType.HUC1_RAM_BATTERY;
                default:
                    return CartType.UNKNOWN;
            }
        }

        public byte Read8(int addr)
        {
            if(GetCartType() == CartType.ROM)
            {
                return ROM[addr];
            }
            return 0x00;
        }
    }
}
