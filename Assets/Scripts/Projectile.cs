using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 10f;
    private Rigidbody projectile;

    public GameObject closestEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectile = GetComponent<Rigidbody>();

        if(closestEnemy)
        {
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
            projectile.linearVelocity = direction * speed;
        }
        else
        {
            projectile.linearVelocity = transform.forward * speed;
        }


        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Health targetHealth = other.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
