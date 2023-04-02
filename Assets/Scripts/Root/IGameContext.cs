using strange.extensions.injector.api;

public interface IGameContext
{
    public ICrossContextInjectionBinder InjectionBinder { get; set; }
}