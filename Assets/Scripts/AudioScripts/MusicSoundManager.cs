using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public static AudioSource MusicSource;

    private void Start()
    {
        MusicSource = GetComponent<AudioSource>();
    }
    public static void PlaySoundEffect(AudioClip MusicSound)
    {
        //Plays All Sounds With Given Preferences

        //AudioSources.Play(MusicSound, PlayerPrefs.GetFloat("Music"));
    }


}
