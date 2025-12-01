using System;
using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    
    public Transform orientation;
    
    //public ParticleSystem particl;
    
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //particl.Play(); 
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //particl.Stop();
        }
    }
}
