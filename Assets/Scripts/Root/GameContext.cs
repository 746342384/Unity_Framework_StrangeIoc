using Framework.framework.resources.api;
using Framework.framework.resources.impl;
using Framework.framework.system.api;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root.Commands;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.api;

namespace Root
{
    public class GameContext : MVCSContext, IGameContext
    {
        private Framework.framework.system.impl.System _system;

        public GameContext()
        {
            ContextInjectionBinder = injectionBinder;
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            commandBinder.Bind(ContextEvent.START).To<StartCommand>();
        }

        public override void Launch()
        {
            base.Launch();

            BindSystem<PanelSystem, IPanelSystem>();
            OnInit();
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Bind<IGameContext>().To<GameContext>().ToSingleton();
            injectionBinder.Bind<IUIRoot>().To<UIRoot>();
            injectionBinder.Bind<IResourceSystemService>().To<ResourceSystemService>().ToSingleton();
            injectionBinder.Bind<IResourcesLoader>().To<ResourcesLoader>().ToSingleton();
            injectionBinder.Bind<IPanelSystem>().To<PanelSystem>().ToSingleton();

            injectionBinder.Bind<Framework.framework.system.impl.System>().To<Framework.framework.system.impl.System>();
            _system = injectionBinder.GetInstance<Framework.framework.system.impl.System>();
            injectionBinder.Unbind<Framework.framework.system.impl.System>();
        }

        private void BindSystem<TSystem, TSystemImpl>() where TSystemImpl : ISystem
        {
            _system.BindSystem<TSystem, TSystemImpl>();
        }

        private void OnInit()
        {
            _system.OnInit();
        }

        public ICrossContextInjectionBinder ContextInjectionBinder { get; set; }
    }
}