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
    }
}