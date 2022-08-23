using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTransitionState : MonoBehaviour
{
    public Animator transition;

    public void PlayBarsIn()
    {
        transition.ResetTrigger("BarsOut");
        transition.SetTrigger("BarsIn");
    }

    public void PlayBarsOut()
    {
        transition.ResetTrigger("BarsIn");
        transition.SetTrigger("BarsOut");
    }
}
