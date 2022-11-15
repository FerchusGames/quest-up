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

            _keepPlaying = true;
            LevelCount = 1;
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
            TransitionManager.Instance.TransitionToNextLevel("GameOverScreen");
        }

        public void NextLevel()
        {
            LevelCount++;
            HazardManager.Instance.SetCurrentLevelValues();
            TransitionManager.Instance.TransitionToNextLevel("Intermission");
        }
    }
}
