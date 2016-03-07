using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy.Graphics
{
    public static class Palette
    {
        public static byte blankR = 255;
        public static byte blankG = 255;
        public static byte blankB = 255;
        public static byte lightR = 196;
        public static byte lightG = 196;
        public static byte lightB = 196;
        public static byte darkR = 127;
        public static byte darkG = 127;
        public static byte darkB = 127;
        public static byte solidR = 0;
        public static byte solidG = 0;
        public static byte solidB = 0;

        public static void SetColors(byte[] blank, byte[] light, byte[] dark, byte[] solid)
        {
            blankR = blank[0];
            blankG = blank[1];
            blankB = blank[2];
            lightR = light[0];
            lightG = light[1];
            lightB = light[2];
            darkR = dark[0];
            darkG = dark[1];
            darkB = dark[2];
            solidR = solid[0];
            solidG = solid[1];
            solidB = solid[2];
        }

    }
}
