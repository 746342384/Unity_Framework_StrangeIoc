using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace Framework.framework.animator
{
    public class AnimationController : MonoBehaviour, PlayerInput.IUIActions
    {
        public Animator animator;
        public List<AnimationClip> animationClips;
        public int defaultClipIndex = 0;

        public int TargetIndex;

        private PlayableGraph playableGraph;
        private AnimationMixerPlayable mixerPlayable;
        private int currentClipIndex;
        private Dictionary<int, float> clipNormalizeTimes;

        private PlayerInput PlayerInput;

        void Start()
        {
            PlayerInput = new PlayerInput();
            PlayerInput.UI.SetCallbacks(this);
            PlayerInput.Enable();
            
            currentClipIndex = defaultClipIndex;
            clipNormalizeTimes = new Dictionary<int, float>();

            // 创建PlayableGraph
            playableGraph = PlayableGraph.Create("AnimationGraph");
            var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", animator);

            // 创建AnimationMixerPlayable，并连接到PlayableGraph的输出节点
            mixerPlayable = AnimationMixerPlayable.Create(playableGraph, animationClips.Count);
            playableOutput.SetSourcePlayable(mixerPlayable);

            // 创建AnimationClipPlayable实例，并连接到AnimationMixerPlayable
            for (int i = 0; i < animationClips.Count; i++)
            {
                var clipPlayable = AnimationClipPlayable.Create(playableGraph, animationClips[i]);
                playableGraph.Connect(clipPlayable, 0, mixerPlayable, i);
                clipNormalizeTimes[i] = 0f;
            }

            // 设置默认动画权重
            SetCurrentClipWeight(defaultClipIndex);

            // 播放PlayableGraph
            playableGraph.Play();
        }

        void Update()
        {
            // 更新当前动画的normalizedTime
            UpdateNormalizedTime();

            // 按需在此处添加其他功能和按键映射
        }

        private void UpdateNormalizedTime()
        {
            AnimationClipPlayable currentClip = (AnimationClipPlayable)mixerPlayable.GetInput(currentClipIndex);
            clipNormalizeTimes[currentClipIndex] = (float)currentClip.GetTime() / currentClip.GetAnimationClip().length;

            if (clipNormalizeTimes[currentClipIndex] >= 1f && !currentClip.GetAnimationClip().isLooping)
            {
                TransitionToClip(defaultClipIndex);
            }
        }

        public float GetClipNormalizedTime(int clipIndex)
        {
            if (clipNormalizeTimes.ContainsKey(clipIndex))
            {
                return clipNormalizeTimes[clipIndex];
            }

            return 0f;
        }

        public void TransitionToClip(int clipIndex)
        {
            StartCoroutine(TransitionBetweenClips(currentClipIndex, clipIndex));
        }

        private IEnumerator TransitionBetweenClips(int fromClipIndex, int toClipIndex)
        {
            AnimationClipPlayable fromClip = (AnimationClipPlayable)mixerPlayable.GetInput(fromClipIndex);
            AnimationClipPlayable toClip = (AnimationClipPlayable)mixerPlayable.GetInput(toClipIndex);

            // 重置即将播放的动画剪辑的播放位置
            toClip.SetTime(0);

            float currentWeight = mixerPlayable.GetInputWeight(fromClipIndex);
            float targetWeight = 1f - currentWeight;
            float duration = 0.5f; // 过渡时间，您可以根据需要调整此值
            float startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                float weight = Mathf.Lerp(currentWeight, targetWeight, t);
                mixerPlayable.SetInputWeight(fromClipIndex, weight);
                mixerPlayable.SetInputWeight(toClipIndex, 1f - weight);
                yield return null;
            }

            mixerPlayable.SetInputWeight(fromClipIndex, targetWeight);
            mixerPlayable.SetInputWeight(toClipIndex, currentWeight);

            // 更新当前播放的动画剪辑
            currentClipIndex = toClipIndex;
        }

        private void SetCurrentClipWeight(int clipIndex)
        {
            for (int i = 0; i < mixerPlayable.GetInputCount(); i++)
            {
                mixerPlayable.SetInputWeight(i, i == clipIndex ? 1f : 0f);
            }
        }

        private void OnDisable()
        {
            // 销毁PlayableGraph
            playableGraph.Destroy();
        }

        public void OnK(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            TransitionToClip(TargetIndex);
        }
    }
}