using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    public string PlayerPref;
    public AudioMixer _AudioMixer;
    public Slider _Slider;
    private static float _VolumeValue;
    void Start()
    {
        
        LoadPreferences();

    }


    public void ChangeVolume()
    {
        _AudioMixer.SetFloat(PlayerPref , _Slider.value);
        SavePreferences();
    }

    private void SavePreferences()
    {
        PlayerPrefs.SetFloat(PlayerPref, _Slider.value);
    }
    private void LoadPreferences()
    {
        if (!PlayerPrefs.HasKey(PlayerPref))
        {
            PlayerPrefs.SetFloat(PlayerPref, 0.75f);
        }
        else
        {
            _Slider.value = PlayerPrefs.GetFloat(PlayerPref, _Slider.value);

        }
    }

}
