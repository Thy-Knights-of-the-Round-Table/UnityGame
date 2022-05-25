using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sniper : MonoBehaviour
{

    public GameObject bullet;
    public GameObject objSniper;
    public Transform bulletPos;
    public float fireRate = 15f;
    public ParticleSystem muzzle;
    // Ammo
    public TextMeshProUGUI Text;
    public int ammoCount = 100;
    public int currentAmmoCount;
    public bool canShoot;

    private float nextTimeToFire = 0f;

    public AudioSource gunsound;
    void Start()
    {
        objSniper.SetActive(false);
        currentAmmoCount = ammoCount;
        canShoot = true;
        AudioMixer mixer = Resources.Load("SoundEffects") as AudioMixer;

    }

    private void FixedUpdate()
    {


    }

    void Update()
    {
        Text.text = "Ammo:" + currentAmmoCount;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot == true)
        {
            Shoot();
        }

        if (currentAmmoCount == 0)
        {
            canShoot = false;
        }
        if (currentAmmoCount > 0)
        {
            canShoot = true;
        }
    }

    void Shoot()
    {
        currentAmmoCount -= 1;
        muzzle.Play();
        gunsound.Play();
        nextTimeToFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
    }


}