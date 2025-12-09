using UnityEngine;

public class TakeDamageScript : MonoBehaviour
{
    [SerializeField] 
    private int EnemyHealth; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;

        if (EnemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
