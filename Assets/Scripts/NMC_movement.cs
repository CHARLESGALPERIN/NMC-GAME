using UnityEngine;

public class NMC_movement : MonoBehaviour
{
    float speed_x;
    float speed_y;
    public float speed_g;
    Rigidbody2D rb;
    private bool isFacingRight = true;

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
        speed_x = Input.GetAxisRaw("Horizontal") * speed_g;
        speed_y = Input.GetAxisRaw("Vertical") * speed_g;
        rb.linearVelocity = new Vector2(speed_x, speed_y);
        Flip();
        if (speed_x != 0 || speed_y != 0)
        {
            anim_mc.SetBool("isRunning", true);
        }
        else
        {
            anim_mc.SetBool("isRunning", false);
        }
    }

    private void Flip()
    {
        if (isFacingRight && speed_x < 0f || !isFacingRight && speed_x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
