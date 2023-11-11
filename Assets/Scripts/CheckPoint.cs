using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject cpON, cpOFF;
    public int checkpointSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform.position);
            // se desactivan todos los checkpoints
            CheckPoint[] checkpoints = FindObjectsOfType<CheckPoint>();
            for (int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i].cpOFF.SetActive(true);
                checkpoints[i].cpON.SetActive(false);
            }

            cpOFF.SetActive(false);
            cpON.SetActive(true);

            // Reproduce el efecto de sonido cuando se activa un checkpoint
            AudioManager.instance.PlaySFX(checkpointSound);
        }
    }
}