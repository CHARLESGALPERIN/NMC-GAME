using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyBulletScript : MonoBehaviour
{
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private float bulletDamage;

    private GameObject player;
    private GameObject objective;
    private Rigidbody2D rb;
    public float force;
    private float bulletTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        objective = GameObject.FindGameObjectWithTag("objective");

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToObjective = Vector2.Distance(transform.position, objective.transform.position);

        if(distanceToObjective>distanceToPlayer)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

            float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
        }
        else
        {
            Vector3 direction = objective.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

            float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            iDamageable iDamageable = collision.gameObject.GetComponent<iDamageable>();
            if (iDamageable != null)
            {
                //deal damage
                iDamageable.Damage(bulletDamage);
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if(bulletTimer>3)
        {
            Destroy(gameObject);
        }
        
    }
}
