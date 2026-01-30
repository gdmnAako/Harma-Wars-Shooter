using System;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] public GameObject bullet; 
    
    public Transform player;

    public float shootCD = 2f;
    public float shootSpeed = 75f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootCD)
        {
            ShootPlayer();
            timer = 0f;
        }
    }

    void ShootPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullets = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody rb = bullets.GetComponent<Rigidbody>();

        rb.linearVelocity = direction * shootSpeed; 
    }
}
