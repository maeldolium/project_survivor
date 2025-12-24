using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    float timer;
    float fireRate = 3f;

    [SerializeField] private Vector3 offset = new Vector3(0, 0, (float)0.5);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
    }
}
