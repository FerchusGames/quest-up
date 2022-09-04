using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public LevelSO levelSO;

    [SerializeField] TransitionAnimations transitionAnimations;
    [SerializeField] GameObject transitionContent;

    float levelDuration;

    private void Start()
    {
        StartLevelTimer();
    }

    public void StartLevelTimer()
    {
        levelDuration = levelSO.levelDuration;
        Timer.OnTimerEnd(levelDuration, () => GoToIntermission());
    }
    
    private void GoToIntermission()
    {
        transitionAnimations.PlayBarsIn();

        Timer.OnTimerEnd(1, () => transitionAnimations.PlayBarsOut());
    }

}
