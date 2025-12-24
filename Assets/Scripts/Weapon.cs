using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    float timer;
    float fireRate = 3f;

    private GameObject closestEnemy;

    [SerializeField] private Vector3 offset = new Vector3(0, 0, (float)0.5);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if(distance <= closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        timer += Time.deltaTime;
        if (closestEnemy && timer > fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();

        if(projectileScript != null)
        {
            projectileScript.closestEnemy = closestEnemy;
        }
    }
}
