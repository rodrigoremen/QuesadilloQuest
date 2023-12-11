using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;
    public Animator animator;
    public GameObject victoryZone;
    public int bossMusic, bossDeath, bossHurt, bossDeathShout;
    public enum BossState // Estados del jefe
    {

        phase1,
        phase2,
        phase3,
        end,
    };
    public BossState currentState = BossState.phase1; // Estado actual del jefe, se encuera en la fase de phase1ducción

    private void Awake() // Se instancia el BossController
    {
        instance = this;
    }

    void Start()
    {

    }

    public void OnEnable()
    {
        AudioManager.instance.PlayMusic(bossMusic); // Se reproduce la música del jefe
    }

    void Update()
    {
        if (GameManager.instance.isRespawn) // Si el jugador muere
        {
            currentState = BossState.phase1; // Se reinicia el estado del jefe
            animator.SetBool("Phase1", false); // Se reinicia la animación de la fase 1
            animator.SetBool("Phase2", false); // Se reinicia la animación de la fase 2
            animator.SetBool("Phase3", false); // Se reinicia la animación de la fase 3

            AudioManager.instance.PlayMusic(AudioManager.instance.levelMusic); // Se reproduce la música del nivel
            gameObject.SetActive(false); // Se desactiva el jefe

            BossActivator.instance.gameObject.SetActive(true); // Se activa el BossActivator
            BossActivator.instance.entrance.SetActive(true); // Se activa la entrada

            GameManager.instance.isRespawn = false; // Se reinicia la variable de respawn
        }
    }
    public void DamageBoss() // Función para dañar al jefe
    {
        AudioManager.instance.PlaySFX(bossHurt); // Se reproduce el sonido de daño
        if (currentState != BossState.end) // Si el estado no es el final
        {
            animator.SetTrigger("Hurt"); // Se reproduce la animación de daño
        }

        currentState++; // Se aumenta el estado del jefe

        switch (currentState) // Se cambia el estado del jefe
        {
            case BossState.phase1:
                animator.SetBool("Phase1", true);
                break;
            case BossState.phase2:
                animator.SetBool("Phase2", true);
                animator.SetBool("Phase1", false);
                break;
            case BossState.phase3:
                animator.SetBool("Phase1", false);
                animator.SetBool("Phase2", false);
                animator.SetBool("Phase3", true);
                break;
            case BossState.end:
                Debug.Log("Boss defeated! Initiating end sequence.");
                animator.SetBool("Phase3", false);
                animator.SetTrigger("End");
                StartCoroutine(EndBoss());
                break;
        }
    }


    IEnumerator EndBoss() // Corrutina para terminar el jefe
    {
        AudioManager.instance.PlaySFX(bossDeath);
        AudioManager.instance.PlaySFX(bossDeathShout);
        AudioManager.instance.PlayMusic(AudioManager.instance.levelMusic);

        yield return new WaitForSeconds(2.0f);
        victoryZone.SetActive(true);
    }
}
