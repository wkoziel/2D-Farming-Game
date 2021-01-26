using UnityEngine.Audio;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;
    public static SoundManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }
    public void MuteAll()
    {
        foreach (var sound in sounds)
        {
            sound.source.mute = !sound.source.mute;
        }
    }
    public void Play(string name)
    {
        Sound s = new Sound();
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        try
        {
            if (Time.timeScale == 0)
                return;
            s.source.Play();
        }
        catch (Exception e)
        {

        }

    }
    public void Stop(string name)
    {
        Sound s = new Sound();
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        try
        {
            s.source.Stop();
        }
        catch (Exception e)
        {

        }

    }

    public bool SoundIsPlaying(string name) {
        Sound s = new Sound();
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        if (s.source.isPlaying)
            return true;
        else
            return false;
    }
}