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

        public ICrossContextInjectionBinder InjectionBinder { get; set; }

        public GameContext()
        {
            InjectionBinder = injectionBinder;
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            commandBinder.Bind(ContextEvent.START).To<StartCommand>();
        }

        public override void Launch()
        {
            InitSystem();
            BindCustomSystem();
            OnInit();
            base.Launch();
        }

        private void InitSystem()
        {
            injectionBinder.Bind<Framework.framework.system.impl.System>().To<Framework.framework.system.impl.System>();
            _system = injectionBinder.GetInstance<Framework.framework.system.impl.System>();
            _system.Init(this);
            injectionBinder.Unbind<Framework.framework.system.impl.System>();
        }

        private void BindCustomSystem()
        {
            _system.BindSystem<IPanelSystem, PanelSystem>();
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Bind<IGameContext>().To<GameContext>().ToSingleton();
            injectionBinder.Bind<IUIRoot>().To<UIRoot>().ToSingleton();
            injectionBinder.Bind<IResourceSystemService>().To<ResourceSystemService>().ToSingleton();
            injectionBinder.Bind<IResourcesLoader>().To<ResourcesLoader>().ToSingleton();
        }

        private void OnInit()
        {
            _system.OnInit();
        }
    }
}