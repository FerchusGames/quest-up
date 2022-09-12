using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class LevelTimer : MonoBehaviour
    {
        public LevelSO _levelSO = null;

        private float _levelDuration = default;

        public void StartLevelTimer()
        {
            _levelDuration = _levelSO.LevelDuration;
            //Timer.OnTimerEnd(_levelDuration, () => StartCoroutine(GoToLevel(1)));
        }
    }

}
