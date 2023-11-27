using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string levelSelect;
    public string firstLevel;
    public GameObject continueButton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Continue"))
        {
            continueButton.SetActive(true);
        }


    }

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetInt("Continue", 0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
