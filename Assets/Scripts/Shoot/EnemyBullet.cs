using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{

    public ParticleSystem explosion; 
    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.CompareTag("Player"))
        {

            ParticleSystem playPart = Instantiate(explosion, transform.position, Quaternion.identity);
            
            
            // Destroy(collision.gameObject);
            // Destroy(gameObject);

            
            Destroy(playPart.gameObject, 1.9f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        
    }
}