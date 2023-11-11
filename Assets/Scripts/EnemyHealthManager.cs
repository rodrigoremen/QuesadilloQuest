using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public int deathSound;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth --;
        if (currentHealth <= 0)
        {
            AudioManager.instance.PlaySFX(deathSound);
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
        }
        PlayerController.instance.Bounce();
    }
}
