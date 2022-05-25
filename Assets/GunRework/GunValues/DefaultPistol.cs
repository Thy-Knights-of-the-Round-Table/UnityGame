using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseGunClass, IGun
{
    public Pistol() : base()
    {
        GunName = "Pistol";
        GunCurrentAmmo = 12;
        GunMagSize = 12;
        GunMaxAmmo = 144;
        GunReserveAmmo = 144;
        GunFireRate = 5f;
        GunDamage = 10f;
    }

    public override void GetGun()
    {
        GunObject = Resources.Load<GameObject>("pistol");
        GunSound = Resources.Load<AudioClip>("PistolGunShot");
        PC = GunObject.GetComponent<ProjectileCreate>();
    }

    public override void Fire()
    {
        AudioSoundManager.PlaySoundEffect(GunSound);

        PC.FireGun(GunDamage);
        GunReserveAmmo--;

    }
    public override int returnAmmo()
    {
        return GunReserveAmmo;
    }
    public override int returnMaxAmmo()
    {
        return GunMaxAmmo;
    }


}