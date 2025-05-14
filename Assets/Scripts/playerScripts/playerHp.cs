using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class playerHp : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 3f;
    
    public float currentHealth;
    public gameStatus gameManager;
    private bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    public void Damage(float damageAmount)
    {
            currentHealth -= damageAmount;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Debug.Log("DEAD");
        }
    }
}
