using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTransition : MonoBehaviour
{
    public string sceneName; // Variable pública para el nombre de la escena

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el objeto que colisiona tiene la etiqueta "Player"
        {
            StartCoroutine(LoadSceneAfterDelay(5));
        }
    }

    IEnumerator LoadSceneAfterDelay(int seconds)
    {
        PlayerController.instance.stopMovement = true;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName); // Usa la variable pública para el nombre de la escena
    }
}