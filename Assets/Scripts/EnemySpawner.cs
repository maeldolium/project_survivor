using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float timer;
    private float spawnRate = 3f;
    private float spawnRadius = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= spawnRate)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Vector2 randomCircle = Random.insideUnitSphere * spawnRadius;

        Vector3 spawnPosition = transform.position + new Vector3(randomCircle.x, 0, randomCircle.y);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
