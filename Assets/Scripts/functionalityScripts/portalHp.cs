using UnityEngine;
using UnityEngine.UI;

public class portalHp : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 50f;
    public float currentHealth;
    public gameStatus gameManager;
    public Slider slider;
    private bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    void Update()
    {

    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        slider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.portalsLeftToDestroy -= 1; ;
            Debug.Log("PORTAL DEAD");
            Destroy(gameObject);
        }
    }
}
