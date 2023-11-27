using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.gameObject.SetActive(false);
            PlayerController.instance.transform.position = Vector3.zero;
            PlayerController.instance.gameObject.SetActive(true);
        }
    }
}