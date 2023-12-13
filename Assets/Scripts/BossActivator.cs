using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject boss, entrance;
    public static BossActivator instance;


    public void Awake() // Se instancia el BossActivator
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boss.SetActive(true); // Activando el jefe
            entrance.SetActive(false); // Desactivando la entrada
            gameObject.SetActive(false); // Desactivando el BossActivator
            AudioManager.instance.StopMusic(); // Stop the music
        }
    }
}
