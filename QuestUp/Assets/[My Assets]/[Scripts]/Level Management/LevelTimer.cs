using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class LevelTimer : MonoBehaviour
    {
        public LevelSO _levelSO = null;

        [SerializeField] private LoadSceneAdditive _loadSceneAdditive = null;
        [SerializeField] private TransitionAnimations _transitionAnimations = null;
        [SerializeField] private GameObject _intermissionCanvas = null;

        private float _levelDuration = default;

        public void StartLevelTimer(int levelIndex)
        {
            _levelDuration = _levelSO.LevelDuration;
            Timer.OnTimerEnd(_levelDuration, () => StartCoroutine(GoToLevel(1)));
        }

        IEnumerator GoToLevel(int levelIndex)
        {
            _transitionAnimations.PlayBarsIn();

            yield return new WaitForSeconds(1); 

            _loadSceneAdditive.NextLevel(2, 1); // ! Need to get level index
            _intermissionCanvas.SetActive(false);
            _transitionAnimations.PlayBarsOut();

            yield break;
        }
    }

}
