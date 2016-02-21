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

        public void Initialize()
        {
            int success = SDL_Init(SDL_INIT_EVERYTHING);
            if (success < 0)
                throw new SDLException();

            Window = SDL_CreateWindow("LameBoy", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 160, 144, SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
            if (Window == null)
                throw new SDLException();

            Surface = SDL_GetWindowSurface(Window);
        }

        public void Render()
        {
            IntPtr testSurf = SDL_CreateRGBSurface(SDL_PIXELFORMAT_RGB888, 160, 144, 1, 255, 0, 255, 255);
            var rect = new SDL_Rect { x = 0, y = 0, w = 160, h = 144 };
            SDL_BlitSurface(testSurf, ref rect, Surface, ref rect);
            SDL_UpdateWindowSurface(Window);
            SDL_FreeSurface(testSurf);
        }

        public void Destroy()
        {
            SDL_FreeSurface(Surface);
            SDL_DestroyWindow(Window);
            SDL_Quit();
        }
    }
}
