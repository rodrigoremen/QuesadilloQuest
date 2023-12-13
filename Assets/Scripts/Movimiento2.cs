using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    [SerializeField] private GameObject tronco;
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
            //tronco.SetActive(true);
            tronco.SetActive(true);
            Destroy(gameObject);
            // esto es solo una prueba 
            // transform.localScale *= 2f;
            //GetComponent<ThridPersonMovement>().speed *= 2f;
        }
    }
}
