using Framework.framework.resources.api;
using Framework.framework.resources.impl;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root.Commands;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Root
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour view) : base(view)
        {
        }

        public GameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            commandBinder.Bind(ContextEvent.START).To<StartCommand>();
           
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Bind<IUIRoot>().To<UIRoot>();
            injectionBinder.Bind<IResourceSystemService>().To<ResourceSystemService>().CrossContext().ToSingleton();
            injectionBinder.Bind<IResourcesLoader>().To<ResourcesLoader>().CrossContext().ToSingleton();
            injectionBinder.Bind<IPanelSystem>().To<PanelSystem>().CrossContext().ToSingleton();
        }
    }
}