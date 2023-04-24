using Framework.framework.system.api;
using UnityEngine;

namespace Framework.framework.sound
{
    public interface ISoundManager : ISystem
    {
        void PlayMusic(AudioClip clip);
        void StopMusic(AudioClip clip);
        void PlaySfx(AudioClip clip);
    }
}