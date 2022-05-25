using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class M16 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject objM16;
    public Transform bulletPos;
    public float fireRate = 5f;
    public ParticleSystem muzzle;
    // Ammo
    public TextMeshProUGUI Text;
    public int ammoCount = 100;
    public int currentAmmoCount;
    public bool canShoot;
    public bool canBurst;

    private float nextTimeToFire = 0f;
    public AudioSource gunsound;


    void Start()
    {
        objM16.SetActive(false);
        currentAmmoCount = ammoCount;
        canShoot = true;
        canBurst = true;
        AudioMixer mixer = Resources.Load("SoundEffects") as AudioMixer;

    }

    private void OnEnable()
    {
        canBurst = true;
    }

    private void FixedUpdate()
    {


    }

    void Update()
    {
        Text.text = "Ammo:" + currentAmmoCount;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot == true && canBurst == true)
        {
            Shoot();
        }

        if (currentAmmoCount == 0)
        {
            canShoot = false;
        }
        if(currentAmmoCount >= 0)
        {
            canShoot = true;
        }
    }

    void Shoot()
    {

            canBurst = false;
            muzzle.Play();
            gunsound.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            currentAmmoCount -= 1;
            Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
            StartCoroutine(BurstFire());
    }

    IEnumerator BurstFire()
    {

        yield return new WaitForSeconds(0.15f);
        muzzle.Play();
        currentAmmoCount -= 1;
        gunsound.Play();
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        yield return new WaitForSeconds(0.15f);
        muzzle.Play();
        currentAmmoCount -= 1;
        gunsound.Play();
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        yield return new WaitForSeconds(0.8f);
        canBurst = true;
    }
}
