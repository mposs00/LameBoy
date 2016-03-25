using System;

namespace LameBoy.Graphics
{
    [Serializable]
    public class SDLException : Exception
    {
        public SDLException()
        {

        }
        public SDLException(string message) : base(message)
        {

        }
        public SDLException(string message, Exception inner) : base(message, inner)
        {

        }
        protected SDLException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            base.GetObjectData(info, context);
            if (info != null)
                info.AddValue("SDL Error", SDL2.SDL.SDL_GetError());
        }
    }
}
