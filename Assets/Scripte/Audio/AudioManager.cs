using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private void Awake()
    {
        foreach(Sounds s in sounds)
        {
          s.source =  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    public void Play(string name)
    {
      Sounds s =  Array.Find(sounds,sounds => sounds.name == name);  
        s.source.Play();
    }
    public void click()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
