using UnityEngine;

public class coverHp : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 5f;
    public float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            AstarPath.active.Scan();
        }
    }
}
