using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy.Graphics
{
    public interface IRenderThread
    {
        IRenderRuntime Runtime { get; }
        void Render();
        void Terminate();
    }
}
