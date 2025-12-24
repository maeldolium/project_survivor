using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 10f;
    private Rigidbody projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectile = GetComponent<Rigidbody>();

        projectile.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
