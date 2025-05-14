using UnityEngine;
using Pathfinding;
using System.IO;

public class enemy_script : MonoBehaviour
{
    public Transform enemyGFX;
    private Animator anim_mc;
    public float speed;
    Vector3 previous_pos;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_mc = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceTraveled = transform.position - previous_pos;
        Vector3 direction = distanceTraveled.normalized;
        speed = distanceTraveled.magnitude / Time.fixedDeltaTime;
        previous_pos = transform.position;
        if (speed > 0.01f)
        {
            anim_mc.SetBool("isRunning", true);
        }
        else
        {
            anim_mc.SetBool("isRunning", false);
        }

        if (direction.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
