using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameBoy.Graphics
{
    public interface IRenderRuntime
    {
        int Scale { get; set; }
        byte[,] Pixels { get; set; }

        void Initialize();
        void Render();
        void Destroy();
    }
}
