using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SplashLogo : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(Splash());
    }

    private IEnumerator Splash()
    {
        animator.Play("Logo-Fade");
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Game");    
    }
}