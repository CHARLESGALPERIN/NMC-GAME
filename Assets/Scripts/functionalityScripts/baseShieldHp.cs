using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class baseShieldHp : MonoBehaviour, iDamageable
{
    [SerializeField] GameObject shieldObject;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool canRegen = true;
    public float currentHealth;
    public Slider slider;
    public float delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    void Update()
    {
        delay += Time.deltaTime;
        if (currentHealth < maxHealth && canRegen == true && delay>3)
        {
            delay = 0;
            currentHealth++;
            slider.value = currentHealth;
            if(currentHealth>5)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        slider.value = currentHealth;

        //Prevent natural regeneration
        StartCoroutine(noRegen());
        
        //turn off shield
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private IEnumerator noRegen()
    {
        //Delay shield from healing naturally
        canRegen = false;
        yield return new WaitForSeconds(3);
        canRegen = true;
    }
}
