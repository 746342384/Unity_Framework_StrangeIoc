using System.Threading.Tasks;
using Framework.framework.addressable.api;
using Framework.framework.context;
using Framework.framework.coroutine.api;
using Framework.framework.coroutine.impl;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.resources.api;
using Framework.framework.resources.impl;
using Framework.framework.sound;
using Framework.framework.system.impl;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Module.Game;
using Module.Main;
using Module.Main.Commands;
using Module.Main.View;
using Module.Start;
using Module.Start.Commands;
using Module.Start.View;
using Root.Commands;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.api;

public class GameContext : MVCSContext, IGameContext
{
    public static GameContext Instance;
    private SystemServices _systemServices;
    public ICrossContextInjectionBinder InjectionBinder { get; set; }

    public GameContext()
    {
        Instance = this;
        InjectionBinder = injectionBinder;
    }

    protected override void mapBindings()
    {
        base.mapBindings();
        commandBinder.Bind(ContextEvent.START).To<StartCommand>();
        commandBinder.Bind(StartEvent.Update).To<UpdateResourcesCommand>();
        commandBinder.Bind(StartEvent.PreLoadResources).To<PreLoadResourcesCommand>();
        commandBinder.Bind(StartEvent.Start).To<GameStartCommand>();
        commandBinder.Bind(MainEvent.Back).To<BackStartPanelCommand>();
        mediationBinder.Bind<StartView>().To<StartMediator>();
        mediationBinder.Bind<MainView>().To<MainMediator>();
        mediationBinder.Bind<GameView>().To<GameMediator>();
    }

    public override async void Launch()
    {
        InitSystemServices();
        BindCustomSystemServices();
        await OnSystemServicesInitAsync();
        base.Launch();
    }

    private void InitSystemServices()
    {
        injectionBinder.Bind<SystemServices>().To<SystemServices>();
        _systemServices = injectionBinder.GetInstance<SystemServices>();
        _systemServices.Init(this);
        injectionBinder.Unbind<SystemServices>();
    }

    private void BindCustomSystemServices()
    {
        _systemServices.BindSystem<IPanelSystem, PanelSystem>();
        var coroutineSystem = injectionBinder.GetInstance<ICoroutineSystem>();
        _systemServices.AddSystem(coroutineSystem);
        _systemServices.BindSystem<ISoundManager, SoundManager>();
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        this.UseDataConfigLoader();

        injectionBinder.Bind<ILog>().To<UnityLog>().ToSingleton();
        injectionBinder.Bind<IUIRoot>().To<UIRoot>().ToSingleton();
        injectionBinder.Bind<ICoroutineSystem>().To<CoroutineSystem>().ToSingleton();
        injectionBinder.Bind<IRepositoryManager>().To<RepositoryManager>().ToSingleton();
        injectionBinder.Bind<IResourceSystemService>().To<ResourceSystemService>().ToSingleton();
        injectionBinder.Bind<IAddressableDownload>().To<AddressableDownload>().ToSingleton();
        injectionBinder.Bind<IResourcesLoader>().To<AddressableLoader>().ToSingleton();
    }

    private void OnSystemServicesInit()
    {
        _systemServices.OnInit();
    }

    private async Task OnSystemServicesInitAsync()
    {
        OnSystemServicesInit();
        await _systemServices.OnInitAsync();
    }

    public T GetService<T>()
    {
        return (T)GetComponent<T>();
    }
}