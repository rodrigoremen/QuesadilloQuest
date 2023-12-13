using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            other.GetComponent<Health>().RecoverHealth(10f);
            
            Destroy(gameObject);
            // esto es solo una prueba 
            // transform.localScale *= 2f;
            //GetComponent<ThridPersonMovement>().speed *= 2f;
        }
    }
}
