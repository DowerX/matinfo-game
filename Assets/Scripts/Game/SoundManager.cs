using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {


    [Header("Sounds:")]
    public Sound[] sounds;
    //private List<AudioSource> sourcesSFX = new List<AudioSource>();
    private List<AudioSource> sourcesMUSIC = new List<AudioSource>();
    //private List<AudioSource> sourcesVOICE = new List<AudioSource>();


    [Range(0f, 1.5f)]
    [Header("Global settings:")]
    public float volume = 1;



    private void Start()
    {
        //Play music
        Play(0);
    }

    public void Play(int _id)
    {
        AudioSource source = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        if (sounds[_id].music)
        {
            sourcesMUSIC.Add(source);
        }
        //else if (sounds[_id].sfx)
        //{
        //    sourcesSFX.Add(source);
        //}
        //else if (sounds[_id].voice)
        //{
        //    sourcesVOICE.Add(source);
        //}

        source.playOnAwake = false;
        source.clip = sounds[_id].audio;
        source.loop = sounds[_id].loop;
        source.volume = sounds[_id].volume * volume;
        source.pitch = sounds[_id].pitch;
        source.Play();
    }

    public void ChangeVolume(float _volume, string _group)
    {
        volume = _volume;
        if(_group == "music")
        {
            foreach (AudioSource _source in sourcesMUSIC)
            {
                _source.volume = volume;
            }
        }
        //else if (_group == "sfx")
        //{
        //    foreach (AudioSource _source in sourcesSFX)
        //    {
        //        _source.volume = volume;
        //    }
        //}
        //else if (_group == "voice")
        //{
        //    foreach (AudioSource _source in sourcesVOICE)
        //    {
        //        _source.volume = volume;
        //    }
        //}
    }
}

[System.Serializable]
public class Sound
{
    public bool loop = false;

    [Space]
    [Header("Group")]
    //public bool sfx;
    public bool music;
    //public bool voice;

    [Space]
    public AudioClip audio;

    [Space]
    [Range(0f, 1f)]
    public float volume = 0.1f;
    public float pitch = 1f;
}
