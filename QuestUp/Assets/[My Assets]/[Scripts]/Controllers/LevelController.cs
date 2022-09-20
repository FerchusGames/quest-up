using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class LevelController : MonoBehaviour
    {
        public static LevelController Instance { get; private set; }
        [field: SerializeField] public LevelSO CurrentLevelSO { get; private set; }
        [field: SerializeField] public int TimeLeft { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartLevelTimer();
        }

        private void StartLevelTimer()
        {
            TimeLeft = CurrentLevelSO.LevelDuration;
            StartCoroutine("Countdown");
        }

        private IEnumerator Countdown()
        {
            int timerSeconds = TimeLeft;
            for (int i = 0; i < timerSeconds; i++)
            {
                yield return new WaitForSeconds(1);
                TimeLeft--;
            }
            TransitionManager.Instance.NextLevel("Intermission");
        }
    }
}
