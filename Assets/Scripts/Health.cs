using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(float damage)
    {
        
        currentHealth = Mathf.Max(currentHealth - damage, 0); 
        Debug.Log(currentHealth);
    }

    public void RecoverHealth(float amount)
    {
        
        currentHealth = Mathf.Min(currentHealth + amount, 100); ;
        Debug.Log(currentHealth);
    }
    public void MoreSize(float size)
    {
        transform.localScale *= 4f;

    }
}
