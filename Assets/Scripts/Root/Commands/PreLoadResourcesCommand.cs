using Base.UI;
using Framework.framework.repository;
using framework.framework.ui.api;
using strange.extensions.command.impl;

namespace Root.Commands
{
    public class PreLoadResourcesCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }
        [Inject] public IRepositoryManager RepositoryManager { get; set; }

        public override async void Execute()
        {
            await PanelSystem.PreLoadPanel();
            await RepositoryManager.LoadRepositories();
            // await PanelSystem.OpenPanelAsync(PanelNames.StartPanel);
        }
    }
}