using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevSelLevelEntry : MonoBehaviour
{
    public bool canLoadLevel;
    public string levelName;
    public GameObject mapPointActive, mapPointInactive;
    public string levelToCheck;

    private void Start()
    {
        if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1 || levelToCheck == "")
        {
            mapPointActive.SetActive(true);
            mapPointInactive.SetActive(false);
        }else{
            mapPointActive.SetActive(false);
            mapPointInactive.SetActive(true);
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canLoadLevel)
        {
            SceneManager.LoadScene(levelName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = false;
        }
    }
}
