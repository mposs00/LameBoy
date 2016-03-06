using System;
using System.Collections;
using System.Linq;
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
        
        private byte[,] DecodeSprite(byte[] sprite)
        {

            //TODO: Fix endianness (IMPORTANT)
            BitArray spriteBits = new BitArray(sprite);
            byte[,] lines = new byte[8, 8];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int highBitPos = (x + 8 + (y * 16));
                    int lowBitPos = x + (y * 16);
                    byte high = (byte)(Convert.ToByte(spriteBits.Get(highBitPos)) << 1);
                    byte low = Convert.ToByte(spriteBits.Get(lowBitPos));
                    byte color = (byte)(high | low);
                    lines[y, x] = color;
                    lines[x, 1] = (byte)((Convert.ToByte(spriteBits.Get(x + 24)) << 1) | (Convert.ToByte(spriteBits.Get(x + 16))));
                }
            }
            return lines;
        }

        private void PushFrame()
        {
            sdlt.rt.SetPixels(frame);
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
                    PushFrame();
                }
                else
                {
                    //Render the scene here
                    byte[] sprite = new byte[16];
                    for(int i = 0; i < 16; i++)
                    {
                        sprite[i] = cart.Read8(0x587C + i);
                    }

                    byte[,] testSprite = DecodeSprite(sprite);
                    for (int y = 0; y < 144; y++)
                    {
                        for (int x = 0; x < 160; x++)
                        {
                            if(y < 8 && x < 8)
                            {
                                frame[x, y] = testSprite[y, x];
                            }
                            else
                            {
                                frame[x, y] = 0;
                            }
                        }
                    }

                    PushFrame();
                }
            }
        }
    }
}
