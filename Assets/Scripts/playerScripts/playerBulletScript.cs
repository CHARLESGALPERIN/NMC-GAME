using UnityEngine;
using UnityEngine.InputSystem;

public class playerBulletScript : MonoBehaviour
{
    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] public float bulletSpeed;
    [SerializeField] private float expireAfter;
    [SerializeField] private float bulletDamage;

    private Rigidbody2D rb;
    private Vector2 worldPosition;
    private float bulletTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        Vector3 direction = worldPosition - (Vector2)transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((whatDestroysBullet.value&(1<<collision.gameObject.layer))>0)
        {
            iDamageable iDamageable = collision.gameObject.GetComponent<iDamageable>();
            if (iDamageable != null)
            {
                //deal damage
                iDamageable.Damage(bulletDamage);
            }

            //Destroy bullet
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer > expireAfter)
        {
            Destroy(gameObject);
        }
    }
}
