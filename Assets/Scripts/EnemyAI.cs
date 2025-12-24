using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 720f;
    private GameObject player;

    private Vector3 spawn = new Vector3(10, 0, 15);

    private Rigidbody _rbEnemy;
    private Vector3 _movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rbEnemy = GetComponent<Rigidbody>();

        _rbEnemy.transform.position = spawn;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _movementDirection = (player.transform.position - _rbEnemy.transform.position).normalized;

        Quaternion rotate = Quaternion.LookRotation(_movementDirection);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rotate,
            rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rbEnemy.MovePosition(_rbEnemy.position + _movementDirection * speed * Time.fixedDeltaTime);   
    }
}
