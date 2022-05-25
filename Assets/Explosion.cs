using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Explosion : MonoBehaviour
{
    public AudioClip explosionSound;
    public ParticleSystem explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {

            AudioMixer mixer = Resources.Load("SoundEffects") as AudioMixer;
            AudioSoundManager.PlaySoundEffect(explosionSound);
            explosion.Play();
        
        }
    }

}
