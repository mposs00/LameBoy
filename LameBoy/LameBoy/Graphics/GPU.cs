using System;
using System.Threading;
using SDL2;

namespace LameBoy.Graphics
{
    public class GPU
    {
        SDLThread sdlt;
        Cart cart;
        byte[,] frame;

        public GPU(IntPtr Handle, IntPtr pgHandle)
        {
            sdlt = new SDLThread(Handle, pgHandle, this);
            Thread sdlThread = new Thread(new ThreadStart(sdlt.Render));
            sdlThread.Start();
            frame = new byte[160,144];
        }

        public void SetCart(Cart NewCart)
        {
            cart = NewCart;
        }

        public void UpdateYCounter(byte count)
        {
            if(cart != null)
            {
                cart.Write8(0xFF44, count);
            }
        }

        public void RenderScene()
        {
            while (true)
            {
                if(cart == null)
                {
                    //This just fills the frame buffer with junk, to test it
                    for (int y = 0; y < 144; y++)
                    {
                        for (int x = 0; x < 160; x++)
                        {
                            frame[x, y] = (byte)((x + y) % 4);
                        }
                    }
                    sdlt.rt.SetPixels(frame);
                }
                else
                {
                    //Render the scene here
                }
            }
        }
    }
}
