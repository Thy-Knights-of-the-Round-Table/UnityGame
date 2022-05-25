using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    // Gun
    public GameObject bullet;
    public GameObject objPistol;
    public Transform bulletPos;
    public float fireRate = 15f;
    public ParticleSystem muzzle;
    // Ammo
    public TextMeshProUGUI Text;
    public int ammoCount = 1;
    public int currentAmmoCount;
    public bool canShoot;

    private float nextTimeToFire = 0f;

    public AudioSource gunsound;

    void Start()
    {
        objPistol.SetActive(true);
        currentAmmoCount = ammoCount;
        canShoot = true;
        AudioMixer mixer = Resources.Load("SoundEffects") as AudioMixer;
    }

    private void FixedUpdate()
    {
  

    }

    void Update()
    {
		if (Text)   Text.text = "Ammo:\u221E"; // Infinite Symbol

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot == true)
        {
            gunsound.Play();
            Shoot();
        }

        if(currentAmmoCount == 0)
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
        muzzle.Play();
        nextTimeToFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation, transform.parent);
    }

}
