namespace LameBoy.Graphics
{
    public interface IRenderThread
    {
        IRenderRuntime Runtime { get; }
        void Render();
        void Terminate();
    }
}
