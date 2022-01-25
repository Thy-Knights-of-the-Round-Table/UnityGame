using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    void Start()
    {
        objM16.SetActive(false);
        currentAmmoCount = ammoCount;
        canShoot = true;
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
    }

    void Shoot()
    {

       
            currentAmmoCount -= 1;
            muzzle.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            canBurst = false;
            Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
            StartCoroutine(BurstFire());
    }

    IEnumerator BurstFire()
    {

        yield return new WaitForSeconds(0.1f);
        muzzle.Play();
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        muzzle.Play();
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        yield return new WaitForSeconds(0.8f);
        canBurst = true;
    }
}