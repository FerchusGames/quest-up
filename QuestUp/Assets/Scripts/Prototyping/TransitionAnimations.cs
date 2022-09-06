using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimations : MonoBehaviour
{
    public Animator animator;

    public void PlayBarsIn()
    {
        animator.ResetTrigger("BarsOut");
        animator.SetTrigger("BarsIn");
    }

    public void PlayBarsOut()
    {
        animator.ResetTrigger("BarsIn");
        animator.SetTrigger("BarsOut");
    }
}
