using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float direction;
    Vector3 previous_pos;
    private bool isFacingRight = false;

    private Animator anim_mc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim_mc = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceTraveled = transform.position - previous_pos;
        Vector3 direction = distanceTraveled.normalized;
        speed = distanceTraveled.magnitude / Time.fixedDeltaTime;
        previous_pos = transform.position;
        if (speed != 0)
        {
            anim_mc.SetBool("isRunning", true);
        }
        else
        {
            anim_mc.SetBool("isRunning", false);
        }
        if (!isFacingRight && direction.x > 0f || isFacingRight && direction.x < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
