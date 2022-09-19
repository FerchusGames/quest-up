using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [field: SerializeField] public int LevelCount { get; private set; }
        private bool _keepPlaying = true;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            _keepPlaying = true;
        }

        private void Update()
        {
            if (HealthManager.Instance.CurrentHealth <= 0 && _keepPlaying)
            {
                GameOverScreen();
                _keepPlaying = false;
            }
        }

        private void GameOverScreen()
        {
            TransitionManager.Instance.NextLevel("GameOverScreen");
        }
    }
}
