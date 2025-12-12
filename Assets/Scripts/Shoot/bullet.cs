using System;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public ParticleSystem explosion; 
    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.CompareTag("Enemy"))
        {

            ParticleSystem playPart = Instantiate(explosion, transform.position, Quaternion.identity);
            
            Destroy(collision.gameObject);
            Destroy(gameObject);

            
            Destroy(playPart.gameObject, 2f);
            
           
            
        }
        
    }
}
