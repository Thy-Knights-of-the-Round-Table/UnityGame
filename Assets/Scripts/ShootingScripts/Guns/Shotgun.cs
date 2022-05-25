using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Shotgun : MonoBehaviour
{
    public GameObject player;
    public GameObject objShotgun;
    public float fireRate = 15f;
    public ParticleSystem muzzle;
    // Ammo
    public TextMeshProUGUI Text;
    public int ammoCount = 100;
    public int currentAmmoCount;
    public bool canShoot;
    //
    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    public Transform barrelPos;
    List<Quaternion> pellets;
    private bool canShotgun;

    private float nextTimeToFire = 0f;

    public AudioSource gunsound;

    void Awake()
    {
        pellets = new List<Quaternion>(new Quaternion[pelletCount]);
 
    }

    void Start()
    {
        objShotgun.SetActive(false);
        currentAmmoCount = ammoCount;
        canShoot = true;
        canShotgun = true;
        AudioMixer mixer = Resources.Load("SoundEffects") as AudioMixer;

    }


    void Update()
    {
        Text.text = "Ammo:" + currentAmmoCount;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot == true && canShotgun == true)
        {
            gunsound.Play();
            Shoot();
        }

        if (currentAmmoCount <= 0)
        {
            canShoot = false;
            currentAmmoCount = 0;
        }
        if (currentAmmoCount > 0)
        {
            canShoot = true;
        }
    }

    void Shoot()
    {
    
            muzzle.Play();
            currentAmmoCount -= 1;
            nextTimeToFire = Time.time + 1f / fireRate;
            int i = 0;
            GameObject p = new GameObject();
            foreach (Quaternion quat in pellets.ToArray())
            {
                pellets[i] = Random.rotation;
                p = (GameObject)Instantiate(pellet, barrelPos.position, barrelPos.rotation);
                Destroy(p, 1);
                p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                i++;
            }
        
    }

 


}
