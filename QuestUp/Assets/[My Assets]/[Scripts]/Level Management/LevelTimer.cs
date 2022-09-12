using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public LevelSO _levelSO = null;

    [SerializeField] private LoadSceneAdditive _loadSceneAdditive = null;
    [SerializeField] private TransitionAnimations _transitionAnimations = null;
    [SerializeField] private GameObject _intermissionCanvas = null;

    private float _levelDuration = 0f;

    private void Start()
    {
        StartLevelTimer();
    }

    public void StartLevelTimer()
    {
        _levelDuration = _levelSO.LevelDuration;
        Timer.OnTimerEnd(_levelDuration, () => StartCoroutine(GoToLevel()));
    }
   

    IEnumerator GoToLevel()
    {
        _transitionAnimations.PlayBarsIn();

        yield return new WaitForSeconds(1);

        _loadSceneAdditive.Level1();
        _intermissionCanvas.SetActive(false);
        _transitionAnimations.PlayBarsOut();

        yield break;
    }

}
