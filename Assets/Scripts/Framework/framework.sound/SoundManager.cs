using Framework.framework.system.impl;
using UnityEngine;

namespace Framework.framework.sound
{
    public class SoundManager : SystemBase, ISoundManager
    {
        private AudioManager _audioManager;

        public override void OnInit()
        {
            base.OnInit();
            var obj = new GameObject("[AudioManager]");
            _audioManager = obj.AddComponent<AudioManager>();
        }

        public void PlayMusic(AudioClip clip)
        {
            _audioManager.Play(clip, AudioManager.AudioGroupType.Music, true);
        }

        public void StopMusic(AudioClip clip)
        {
            _audioManager.Stop(clip, AudioManager.AudioGroupType.Music);
        }
    }
}