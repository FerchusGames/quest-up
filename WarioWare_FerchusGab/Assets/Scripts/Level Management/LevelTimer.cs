using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public LevelSO levelSO;

    [SerializeField] LoadSceneAdditive loadSceneAdditive;
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
        Timer.OnTimerEnd(levelDuration, () => StartCoroutine(GoToLevel()));
    }
   

    IEnumerator GoToLevel()
    {
        transitionAnimations.PlayBarsIn();

        yield return new WaitForSeconds(1);

        loadSceneAdditive.Level1();
        transitionContent.SetActive(false);
        transitionAnimations.PlayBarsOut();

        yield break;
    }

}
