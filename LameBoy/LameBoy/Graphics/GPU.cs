using System;

namespace LameBoy
{
    class GPU
    {
        Memory frameBuffer;

        //Makes a GPU for a 160x144 screen, with an RGBA framebuffer
        public GPU()
        {
            frameBuffer = new Memory(160 * 144 * 4);
        }
    }
}
