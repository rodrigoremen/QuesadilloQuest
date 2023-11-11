using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int currentHealth, maxHealth;
    public float invincibilityLength = 2f;
    private float invincibilityCounter;
    public Sprite[] healthBarImages;
    public int hurtSound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            for(int i = 0; i < PlayerController.instance.PlayerPieces.Length; i++)
            {
                if (Mathf.Floor(invincibilityCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.PlayerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.PlayerPieces[i].SetActive(false);
                }
                
                if (invincibilityCounter <= 0)
                {
                    PlayerController.instance.PlayerPieces[i].SetActive(true);
                }
            }

           
        }
    }

    // Hacer daño al jugador
    public void HurtPlayer()
    {
        
        if (invincibilityCounter <= 0)
        {
            currentHealth--;
            // Se comprueba si el jugador ha muerto
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                PlayerController.instance.KnockBack();
                AudioManager.instance.PlaySFX(hurtSound);
                invincibilityCounter = invincibilityLength;
            }
        }
        UpdateUI();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UIManager.instance.healthImage.enabled = true;
        UpdateUI();
    }

    public void AddHealth(int amountToHeal)
    {
        currentHealth+= amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        UIManager.instance.healthText.text = currentHealth.ToString();

        switch(currentHealth)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healthBarImages[4];
                break;
            case 4:
                UIManager.instance.healthImage.sprite = healthBarImages[3];
                break;
            case 3:
                UIManager.instance.healthImage.sprite = healthBarImages[2];
                break;
            case 2:
                UIManager.instance.healthImage.sprite = healthBarImages[1];
                break;
            case 1:
                UIManager.instance.healthImage.sprite = healthBarImages[0];
                break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }

    public void PlayerKilled()
    {
        currentHealth = 0;

        UpdateUI();
    }
}
