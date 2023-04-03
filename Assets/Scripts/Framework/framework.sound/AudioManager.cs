using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum AudioGroupType
    {
        Music,
        UI,
        SFX,
    }

    private class AudioGroup
    {
        public AudioGroupType groupType;
        public AudioSourcePool audioSourcePool;
        public AudioMixerGroup audioMixerGroup;
    }

    private class AudioSourcePool
    {
        public int defaultPoolSize;
        public List<AudioSource> audioSources;
    }

    private List<AudioGroup> audioGroups = new();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeAudioGroups();
    }

    private void InitializeAudioGroups()
    {
        foreach (AudioGroupType groupType in Enum.GetValues(typeof(AudioGroupType)))
        {
            AddAudioGroupIfNotExist(groupType);
        }

        var audioMixer = Resources.Load<AudioMixer>("AudioMixer");

        if (audioMixer != null)
        {
            foreach (var group in audioGroups)
            {
                var groupName = group.groupType.ToString();
                group.audioMixerGroup = audioMixer.FindMatchingGroups(groupName)[0];
            }
        }

        foreach (var group in audioGroups)
        {
            for (var i = 0; i < group.audioSourcePool.defaultPoolSize; i++)
            {
                CreateAudioSourceInPool(group);
            }
        }
    }

    private void AddAudioGroupIfNotExist(AudioGroupType groupType, int defaultPoolSize = 3)
    {
        if (audioGroups.Find(g => g.groupType == groupType) == null)
        {
            audioGroups.Add(new AudioGroup
            {
                groupType = groupType,
                audioSourcePool = new AudioSourcePool
                    { defaultPoolSize = defaultPoolSize, audioSources = new List<AudioSource>() }
            });
        }
    }

    private AudioSource CreateAudioSourceInPool(AudioGroup group)
    {
        var audioSourceObject =
            new GameObject($"AudioSource_{group.groupType}_{group.audioSourcePool.audioSources.Count + 1}");
        audioSourceObject.transform.SetParent(transform);
        var newAudioSource = audioSourceObject.AddComponent<AudioSource>();
        newAudioSource.playOnAwake = false;
        newAudioSource.outputAudioMixerGroup = group.audioMixerGroup;
        group.audioSourcePool.audioSources.Add(newAudioSource);
        return newAudioSource;
    }

    public void ConfigureAudioSourceSettings(AudioGroupType groupType, Action<AudioSource> configureSettings)
    {
        var group = audioGroups.Find(g => g.groupType == groupType);
        if (group != null)
        {
            foreach (var audioSource in group.audioSourcePool.audioSources)
            {
                configureSettings(audioSource);
            }
        }
    }

    public void ConfigureSpecificAudioSourceSettings(AudioGroupType groupType, int index,
        Action<AudioSource> configureSettings)
    {
        var group = audioGroups.Find(g => g.groupType == groupType);
        if (group != null && index >= 0 && index < group.audioSourcePool.audioSources.Count)
        {
            var audioSource = group.audioSourcePool.audioSources[index];
            configureSettings(audioSource);
        }
    }

    public AudioSource Play(AudioClip audioClip, AudioGroupType groupType, bool loop = false, float volume = 1f,
        bool stopCurrent = true)
    {
        var group = audioGroups.Find(g => g.groupType == groupType);
        if (group != null)
        {
            var availableAudioSource = group.audioSourcePool.audioSources.Find(s => !s.isPlaying);
            if (availableAudioSource == null)
            {
                availableAudioSource = CreateAudioSourceInPool(group);
            }

            if (availableAudioSource != null)
            {
                if (stopCurrent)
                {
                    StopAll(groupType);
                }

                availableAudioSource.volume = volume;
                availableAudioSource.loop = loop;
                availableAudioSource.clip = audioClip;
                availableAudioSource.Play();
            }

            return availableAudioSource;
        }

        return null;
    }

    public void StopAll(AudioGroupType groupType)
    {
        var group = audioGroups.Find(g => g.groupType == groupType);
        if (group != null)
        {
            foreach (var audioSource in group.audioSourcePool.audioSources)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }

    public void Stop(AudioClip audioClip, AudioGroupType groupType)
    {
        var group = audioGroups.Find(g => g.groupType == groupType);
        if (group != null)
        {
            var audioSource = group.audioSourcePool?.audioSources?.Find(s => s.clip == audioClip && s.isPlaying);
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }

    public void Pause(AudioClip audioClip, AudioGroupType groupType)
    {
        var group = GetAudioGroup(groupType);
        if (group != null)
        {
            foreach (var audioSource in group.audioSourcePool.audioSources)
            {
                if (audioSource.clip == audioClip && audioSource.isPlaying)
                {
                    audioSource.Pause();
                    break;
                }
            }
        }
    }

    public void Resume(AudioClip audioClip, AudioGroupType groupType)
    {
        var group = GetAudioGroup(groupType);
        if (group != null)
        {
            foreach (var audioSource in group.audioSourcePool.audioSources)
            {
                if (audioSource.clip == audioClip && !audioSource.isPlaying)
                {
                    audioSource.UnPause();
                    break;
                }
            }
        }
    }

    private AudioGroup GetAudioGroup(AudioGroupType groupType)
    {
        foreach (var group in audioGroups)
        {
            if (group.groupType == groupType)
            {
                return group;
            }
        }

        return null;
    }
}