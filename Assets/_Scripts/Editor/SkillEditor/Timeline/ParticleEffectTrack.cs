using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Editor.SkillEditor.Timeline
{
    [TrackColor(0, 0.45f, 0.87f)]
    [TrackClipType(typeof(ParticleEffectPlayableAsset))]
    public class ParticleEffectTrack : ControlTrack
    {
    }

    public class ParticleEffectPlayableAsset : ControlPlayableAsset
    {
        public ExposedReference<GameObject> ControlledObject;
        public ExposedReference<Transform> Parent;
    }

    public class CustomControlPlayable : PrefabControlPlayable
    {
        private ScriptPlayable<PrefabControlPlayable> _prefabControlPlayable;

        // 你可以添加自定义属性和方法
        public GameObject ControlledObject { get; set; }
        public Transform Parent { get; set; }

        // 实现PlayableBehaviour中的方法
        public override void OnGraphStart(Playable playable)
        {
            _prefabControlPlayable = Create(playable.GetGraph(), ControlledObject, Parent);
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            _prefabControlPlayable.Play();
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            _prefabControlPlayable.Pause();
        }

        public override void OnGraphStop(Playable playable)
        {
            _prefabControlPlayable.Destroy();
        }
    }
}