using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake(){

        DontDestroyOnLoad(gameObject);

        if (AudioManager.instance == null)
            AudioManager.instance = this;
        else {
            Destroy(gameObject);
            return;
        }
            

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound soundToPlay = Array.Find(sounds, s => s.name == name);
        if(soundToPlay == null) {
            Debug.LogWarning("The sound " + name + " could not be found");
        }
        soundToPlay.source.Play();
    }

}
