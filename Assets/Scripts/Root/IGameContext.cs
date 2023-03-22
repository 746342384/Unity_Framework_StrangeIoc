using strange.extensions.injector.api;

namespace Root
{
    public interface IGameContext
    {
        public ICrossContextInjectionBinder InjectionBinder { get; set; }
    }
}