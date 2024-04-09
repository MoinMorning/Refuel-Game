using UnityEngine;
using System;
using UnityEngine.Audio;

/*Handles all of the game sounds*/
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        // Adds AudioSources to the gameObject
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        
    }

    // Play main theme on Start
    void Start(){
        Play("Theme");
    }

    // Update is called once per frame
    // Play Sound file
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
