using System;
using System.Runtime.InteropServices;
using static SDL2.SDL;

namespace LameBoy.Graphics
{
    public class SDLRuntime : IRenderRuntime
    {
        GameBoy owner;
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
        public byte[,] Pixels { get; set; }
        public int Scale { get; set; } = 5;

        bool renderCalled = false, running = false;

        public SDLRuntime(GameBoy owner)
        {
            this.owner = owner;
        }

        public void Initialize()
        {
            int success = SDL_Init(SDL_INIT_EVERYTHING);
            if (success < 0)
                throw new SDLException();

            Window = SDL_CreateWindow("LameBoy", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 800, 720, SDL_WindowFlags.SDL_WINDOW_BORDERLESS);
            if (Window == null)
                throw new SDLException();

            Surface = SDL_GetWindowSurface(Window);
            Renderer = SDL_GetRenderer(Window);

            running = true;
            MainLoop();
        }

        void MainLoop()
        {
            while(running)
            {
                if (renderCalled)
                {
                    Draw();
                    renderCalled = false;
                }
            }
            CleanupSDL();
        }

        void Draw()
        {
            //while(CPUexecuting){ }
            while (owner.GPU.drawing) { }

            SDL_Surface surf = (SDL_Surface)Marshal.PtrToStructure(Surface, typeof(SDL_Surface));

            if (Pixels == null)
                return;

            for (int y = 0; y < 144; y++)
            {
                for(int x = 0; x < 160; x++)
                {
                    byte r, g, b;
                    if (Pixels[x, y] == 0)
                    {
                        r = Palette.blankR;
                        g = Palette.blankG;
                        b = Palette.blankB;
                    }
                    else if (Pixels[x, y] == 1)
                    {
                        r = Palette.lightR;
                        g = Palette.lightG;
                        b = Palette.lightB;
                    }
                    else if (Pixels[x, y] == 2)
                    {
                        r = Palette.darkR;
                        g = Palette.darkG;
                        b = Palette.darkB;
                    }
                    else
                    {
                        r = Palette.solidR;
                        g = Palette.solidG;
                        b = Palette.solidB;
                    }
                    var rect = new SDL_Rect { x = x * Scale, y = y * Scale, w = Scale, h = Scale };
                    SDL_FillRect(Surface, ref rect, SDL_MapRGBA(surf.format, r, g, b, 255));
                }
            }
            SDL_UpdateWindowSurface(Window);
        }

        public void Render()
        {
            renderCalled = true;
        }

        public void Destroy()
        {
            running = false;
        }

        void CleanupSDL()
        {
            SDL_FreeSurface(Surface);
            SDL_DestroyWindow(Window);
            SDL_Quit();
        }
    }
}
