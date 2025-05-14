using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class baseGeneratorHp : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 100f;
    public float currentHealth;
    public Slider slider;
    public gameStatus gameManager;
    
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
            gameManager.gameOver();
            Debug.Log("DEAD");
        }
    }
}
