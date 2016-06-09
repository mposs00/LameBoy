namespace LameBoy.Graphics
{
    public interface IRenderThread
    {
        byte[,] Pixels { get; set; }
        int Scale { get; set; }

        void Render();
        void Terminate();
    }
}
