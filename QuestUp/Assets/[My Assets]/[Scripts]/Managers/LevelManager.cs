using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [field: SerializeField] public LevelSO CurrentLevelSO { get; private set; }
        [field: SerializeField] public int TimeLeft { get; private set; }   

        private void Awake()
        {
            if (Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            StartLevelTimer();
        }

        public void StartLevelTimer()
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
        }
    }
}
