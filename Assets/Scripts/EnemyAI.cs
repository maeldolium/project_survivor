using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 720f;
    private GameObject player;
    private float damageCoolDown = 1f;
    private float nextDamageTime;

    private Rigidbody _rbEnemy;
    private Vector3 _movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialisation de l'ennemi
        _rbEnemy = GetComponent<Rigidbody>();

        // Trouver le joueur
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Calcul de la direction
        _movementDirection = (player.transform.position - _rbEnemy.transform.position).normalized;

        // Rotation en fonction de la direction
        Quaternion rotate = Quaternion.LookRotation(_movementDirection);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rotate,
            rotationSpeed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        // Mouvement de l'ennemi
        _rbEnemy.MovePosition(_rbEnemy.position + _movementDirection * speed * Time.fixedDeltaTime);   
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time >= nextDamageTime && collision.gameObject.CompareTag("Player")){ 
            Health targetHealth = collision.gameObject.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(1);
            }
            nextDamageTime = Time.time + damageCoolDown;
        }
    }
}
