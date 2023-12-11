using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectReset : MonoBehaviour
{

    public static LevelSelectReset instance;

    public Vector3 respawnPosition;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.gameObject.SetActive(false);
            PlayerController.instance.transform.position = respawnPosition;
            PlayerController.instance.gameObject.SetActive(true);
        }
    }
}