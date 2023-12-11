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
    public string levelToCheck, displayName;

    public bool levelUnlocked;

    private bool levelLoading;

    private void Start()
    {
        if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1 || levelToCheck == "")
        {
            mapPointActive.SetActive(true);
            mapPointInactive.SetActive(false);
            levelUnlocked = true;
        }
        else
        {
            mapPointActive.SetActive(false);
            mapPointInactive.SetActive(true);
            levelUnlocked = false;
        }

        if (PlayerPrefs.GetString("CurrentLevel") == levelName)
        {
            PlayerController.instance.transform.position = transform.position;

            LevelSelectReset.instance.respawnPosition = transform.position;
        }
        else
        {
            UIManager.instance.fadeFromBlack = false;
        }


    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canLoadLevel && levelUnlocked && !levelLoading)
        {
            StartCoroutine("LevelLoadWaiter");
            levelLoading = true;


        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = true;

            LsUiManager.instance.lNamePanel.SetActive(true);
            LsUiManager.instance.lNameText.text = displayName;

            if (PlayerPrefs.HasKey(levelName + "_coins"))
            {
                LsUiManager.instance.coinsText.text = PlayerPrefs.GetInt(levelName + "_coins").ToString();
            }
            else
            {
                LsUiManager.instance.coinsText.text = "0";
            }
            {
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = false;

            LsUiManager.instance.lNamePanel.SetActive(false);
        }
    }

    public IEnumerator LevelLoadWaiter()
    {
        PlayerController.instance.stopMovement = true;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName);
        PlayerPrefs.SetString("CurrentLevel", levelName);
    }

}
