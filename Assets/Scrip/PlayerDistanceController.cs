using UnityEngine;

public class PlayerDistanceController : MonoBehaviour
{
    public string monsterTag = "Enemy"; // Tag-ul asociat monștrului
    public float desiredDistance = 2.0f; // Distanța dorită între jucător și monstru
    public float moveSpeed = 5.0f; // Viteza de deplasare a jucătorului

    private Rigidbody rb;
    private Vector3 lastValidPosition; // Ultima poziție validă a jucătorului

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastValidPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Găsim toate obiectele cu tag-ul "Monster"
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(monsterTag);

        // Asumăm că avem doar un monstru în scenă pentru exemplificare
        if (monsters.Length > 0)
        {
            // Distanta dintre jucător și monstru
            float distance = Vector3.Distance(transform.position, monsters[0].transform.position);

            // Dacă jucătorul este prea aproape de monstru
            if (distance < desiredDistance)
            {
                // Direcția de la jucător la monstru
                Vector3 directionToMonster = (transform.position - monsters[0].transform.position).normalized;

                // Calculăm poziția la care trebuie să fie jucătorul
                Vector3 targetPosition = monsters[0].transform.position + directionToMonster * desiredDistance;

                // Mișcăm jucătorul spre poziția țintă
                rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime));
            }
            else
            {
                // Actualizăm ultima poziție validă
                lastValidPosition = transform.position;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Dacă jucătorul intră în coliziune cu un obiect cu tag-ul "Monster" sau "Obstacle"
        if (collision.gameObject.CompareTag(monsterTag) || collision.gameObject.CompareTag("Obstacle"))
        {
            // Îl readucem pe jucător la ultima poziție validă
            rb.MovePosition(lastValidPosition);
        }
    }
}
