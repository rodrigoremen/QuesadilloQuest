using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

  public Animator animator;

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      animator.SetTrigger("hit");

      StartCoroutine(GameManager.instance.LevelEndWaiter());
    }
  }
}
