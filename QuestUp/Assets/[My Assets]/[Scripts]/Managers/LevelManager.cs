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

        private void Awake()
        {
            if (Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void StartLevelTimer()
        {
            float levelDuration = CurrentLevelSO.LevelDuration;
            //Timer.OnTimerEnd(_levelDuration, () => StartCoroutine(GoToLevel(1)));
        }
    }
}
