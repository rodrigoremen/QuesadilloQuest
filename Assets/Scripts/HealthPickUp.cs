using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount;
    public bool isFullHeal;
    public GameObject healthEffect;
    public int healthSound;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {

            Destroy(gameObject);
            Instantiate(healthEffect, other.transform.position + new Vector3(0f, 1f, 0f), other.transform.rotation);

            if (isFullHeal)
            {
                HealthManager.instance.ResetHealth();
            }
            else
            {
                HealthManager.instance.AddHealth(healAmount);
            }
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(healthSound);
        }
    }
}
