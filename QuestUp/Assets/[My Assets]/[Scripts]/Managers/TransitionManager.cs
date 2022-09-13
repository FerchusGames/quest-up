using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class TransitionManager : MonoBehaviour
    {
        public static TransitionManager Instance { get; private set; }

        [SerializeField] private TransitionAnimations _transitionAnimations;

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void NextLevel(string nextLevel)
        {
            _transitionAnimations.TriggerTransition(() =>
            {
                LoadLevel(nextLevel);
            });
        }

        private void LoadLevel(string nextLevel)
        {
            SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Single);
        }
    }
}
