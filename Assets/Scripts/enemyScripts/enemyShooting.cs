using System.Collections;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    [SerializeField] private float timeBeforeShots = 2f;
    [SerializeField] private float range = 7f;
    [SerializeField] private bool isBurst = false;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    private GameObject objective;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objective = GameObject.FindGameObjectWithTag("objective");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToObjective = Vector2.Distance(transform.position, objective.transform.position);

        if (distanceToPlayer <= range || distanceToObjective <= range)
        {
            timer += Time.deltaTime;

            if (timer > timeBeforeShots)
            {
                timer = 0;
                if (isBurst==true)
                {
                    StartCoroutine(burst());
                }
                else
                {
                    shoot();
                }
            }
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    private IEnumerator burst()
    {
        shoot();
        yield return new WaitForSeconds(0.3f);
        shoot();
        yield return new WaitForSeconds(0.3f);
        shoot();
        StopCoroutine(burst());
    }
}
