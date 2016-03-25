using LameBoy.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LameBoy
{
    public class GameBoy
    {
        public CPU CPU { get; private set; }
        public GPU GPU { get; private set; }
        public Cart Cart { get; private set; }
        public IRenderThread RenderThread { get; private set; }

        public bool Powered { get; private set; }

        Thread cpuThread, gpuThread, rtThread;

        public GameBoy()
        {
            GPU = new GPU(this);
            CPU = new CPU(GPU);
        }

        public void LoadCart(Cart cart)
        {
            Cart = cart;
            CPU.GameCart = Cart;
        }

        public void HookRenderer(IRenderThread rt)
        {
            if (RenderThread != null) UnhookRenderer();

            RenderThread = rt;

            if(Powered) StartRenderThread();
        }

        public void UnhookRenderer()
        {
            if (RenderThread == null) return;

            RenderThread.Terminate();
            RenderThread = null;
        }

        private void StartRenderThread()
        {
            rtThread = new Thread(new ThreadStart(RenderThread.Render));
            rtThread.Start();
        }

        public void Start()
        {
            if (Powered) return;

            cpuThread = new Thread(new ThreadStart(CPU.ThreadStart));
            cpuThread.Start();

            gpuThread = new Thread(new ThreadStart(GPU.RenderScene));
            gpuThread.Start();

            if (RenderThread != null) StartRenderThread();

            CPU.Resume();

            Powered = true;
        }

        public void Shutdown()
        {
            if (!Powered) return;

            if (RenderThread != null) RenderThread.Terminate();
            GPU.Terminate();
            CPU.Terminate();

            Powered = false;
        }
    }
}
