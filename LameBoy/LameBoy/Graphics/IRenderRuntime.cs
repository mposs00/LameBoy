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
