using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    public Vector3 offset;
    Vector3 lastPosition = Vector3.zero;
    Quaternion lookRotation;
    RaycastHit hit;
    private float turretHealth = 100.0f;
    public GameObject bullet;
    public GameObject gun;
    public Transform bulletPosition;
    public ParticleSystem muzzle;
    public ParticleSystem fire;
    public float fireRate = 10.0f;
    public float maxDistance = 1.0f;
    private float nextFire = 0.0f;    

    void Start()
    {
        gun.SetActive(true);
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;

        if(target)
        {            
            if (lastPosition != target.transform.position) // last known position doesn't equal the position of the target
            {
                lookRotation = Quaternion.LookRotation(target.transform.position - transform.position + offset);
            }

            if (transform.rotation != lookRotation) // rotation doesn't equal the rotation needed to get the target
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, speed * Time.deltaTime);
            }
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // distance between turret and target

            if(shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }

            if(closestEnemy != null && shortestDistance <= maxDistance)
            {
                target = closestEnemy.transform;
            }
            else
            {
                target = null;
            }

            if (enemy != closestEnemy)
            {
                return;
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
                {
                    Shoot();
                }
            }
        }
    }
    
    bool SetTarget(GameObject _target)
    {
        if(!target)
        {
            return false;
        }

        return true;
    }

    void Shoot()
    {        
        nextFire = Time.time + 1f / fireRate;
        Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
        muzzle.Play();
    }

    private void OnDrawGizmosSelected() // visualise turret radius
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}