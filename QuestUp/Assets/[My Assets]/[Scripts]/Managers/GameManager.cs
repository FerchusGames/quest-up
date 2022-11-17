using UnityEngine;

namespace QuestUp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [field: SerializeField] public int LevelCount { get; private set; }

        public bool KeepPlaying { get; private set; }

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

            KeepPlaying = true;
            LevelCount = 1;
        }

        private void Update()
        {
            if (HealthManager.Instance.CurrentHealth <= 0 && KeepPlaying)
            {
                GameOverScreen();
                KeepPlaying = false;
            }
        }

        private void GameOverScreen()
        {
            TransitionManager.Instance.TransitionToNextLevel("GameOverScreen");
        }

        public void NextLevel()
        {
            LevelCount++;
            HazardManager.Instance.DespawnSequences();
            HazardManager.Instance.SetCurrentLevelValues();
            TransitionManager.Instance.TransitionToNextLevel("Intermission");
        }
    }
}
