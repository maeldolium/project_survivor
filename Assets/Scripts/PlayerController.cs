using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")] // Organisation inspector
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;

    private Rigidbody _rb;
    private Vector3 _movementDirection;
    private GameObject closestenemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // 1. Initialisation des touches
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 2. Calcul de la direction
        _movementDirection = new Vector3(h, 0, v).normalized;

        // 3. Trouver l'ennemie le plus proche
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if(distance <= closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null)
        {
            Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized;
            directionToEnemy.y = 0;

            Quaternion rotate = Quaternion.LookRotation(directionToEnemy);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotate,
                rotationSpeed * Time.deltaTime );
        }

        else if(_movementDirection.magnitude >= 0.1f)
        {

        // 4. On crée une rotation
        // Rotation cible basée sur le vecteur direction
        Quaternion rotate = Quaternion.LookRotation(_movementDirection);

        // On tourne progressivement dans la direction du mouvement
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rotate,
            rotationSpeed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        // Déplacement du joueur
        _rb.MovePosition(_rb.position + _movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
