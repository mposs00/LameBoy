using System;
using static SDL2.SDL;

namespace LameBoy.Graphics
{
    public class SDLRuntime
    {
        public IntPtr Window { get; private set; }
        public IntPtr Surface { get; private set; }
        public IntPtr Handle {
            get
            {
                SDL_SysWMinfo wminfo = new SDL_SysWMinfo { };
                SDL_GetWindowWMInfo(Window, ref wminfo);

                return wminfo.info.win.window;
            }
        }
        public IntPtr Renderer;
        public byte[] pixels;

        public void Initialize()
        {
            int success = SDL_Init(SDL_INIT_EVERYTHING);
            if (success < 0)
                throw new SDLException();

            Window = SDL_CreateWindow("LameBoy", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 160, 144, SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
            if (Window == null)
                throw new SDLException();

            Surface = SDL_GetWindowSurface(Window);
            Renderer = SDL_GetRenderer(Window);
        }

        public void SetPixels(byte[] source)
        {
            pixels = source;
        }

        public unsafe void Render()
        {
            SDL_Surface* surfPtr = (SDL_Surface*) Surface.ToPointer();
            SDL_Surface surf = *surfPtr;

            //This just fills the frame buffer with junk, to test it
            Random r = new Random();
            pixels = new byte[160 * 144];
            for (int y = 0; y <= 144; y++)
            {
                for (int x = 0; x <= 160; x++)
                {
                    pixels[(y * 144) + x] = (byte)(r.Next() % 2);
                }
            }

            //Todo: proper colors
            for (int y = 0; y <= 144; y++)
            {
                for(int x = 0; x <= 160; x++)
                {
                    byte color;
                    if (pixels[(y * 144) + x] == 0)
                        color = 0;
                    else
                        color = 255;
                    var rect = new SDL_Rect { x = x, y = y, w = 1, h = 1 };
                    SDL_FillRect(Surface, ref rect, SDL_MapRGBA(surf.format, color, color, color, 255));
                }
            }
            SDL_UpdateWindowSurface(Window);
        }

        public void Destroy()
        {
            SDL_FreeSurface(Surface);
            SDL_DestroyWindow(Window);
            SDL_Quit();
        }
    }
}
