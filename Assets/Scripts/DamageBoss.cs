using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) // Si el objeto que colisiona tiene la etiqueta "Player"
        {
            BossController.instance.DamageBoss(); // Se llama a la función DamageBoss del BossController
        }
    }
}
