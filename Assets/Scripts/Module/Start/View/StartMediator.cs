using System;
using Framework.framework.resources.api;
using Framework.framework.sound;
using Framework.framework.ui.mediator.impl;
using UnityEngine;

namespace Module.Start.View
{
    public class StartMediator : UGameMediator<StartView>
    {
        private AudioClip _clip;
        [Inject] public ISoundManager SoundManager { get; set; }
        [Inject] public IResourceSystemService ResourceSystemService { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.Button.onClick.AddListener(() => { Dispatcher.Dispatch(StartEvent.Start); });
            View.Dispatcher.AddListener("OnEnable", OnEnabled);
        }

        private async void OnEnabled()
        {
            const string path = "Assets/ResPackage/Common/Audio/Music/BRPG_Assault_FULL_Loop.wav";
            _clip = await ResourceSystemService.LoadAsync<AudioClip>(path);
            SoundManager.PlayMusic(_clip);
        }

        private void OnDisable()
        {
            SoundManager.StopMusic(_clip);
        }
    }
}