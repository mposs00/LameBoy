
namespace LameBoy
{
    public enum State
    {
        //CPU is actively executing on its own accord
        Running  = 1,

        //CPU is not executing, but its state is saved and it can be executed manually
        Paused   = 2,
        
        //CPU received call to stop and will stop on next cycle
        Stopping = 4,
        
        //CPU is stopped and ready to be disposed; CPU loop thread is dead
        Stopped  = 0
    }
}