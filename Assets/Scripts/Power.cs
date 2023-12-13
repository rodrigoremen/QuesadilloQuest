using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
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

            //transform.localScale *= 4f;

           // other.GetComponent<Health>().MoreSize(5f);
            other.GetComponent<ThridPersonMovement>().jumpForce *= 2f;
            other.GetComponent<ThridPersonMovement>().transform.localScale*=1.2f;
             tronco.SetActive(true);
            Destroy(gameObject);
        }
    }
}
