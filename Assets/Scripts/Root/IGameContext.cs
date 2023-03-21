using strange.extensions.injector.api;

namespace Root
{
    public interface IGameContext
    {
        public ICrossContextInjectionBinder ContextInjectionBinder { get; set; }
    }
}