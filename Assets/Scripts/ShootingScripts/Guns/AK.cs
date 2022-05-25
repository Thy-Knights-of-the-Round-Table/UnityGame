using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class AK : MonoBehaviour
{
    public GameObject bullet;
    public GameObject objAK;
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
        objAK.SetActive(false);
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
            gunsound.Play();
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
        nextTimeToFire = Time.time + 1f / fireRate;
        //Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);  
    }
}
