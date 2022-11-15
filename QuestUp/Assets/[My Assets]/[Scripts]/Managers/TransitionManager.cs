using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class TransitionManager : MonoBehaviour
    {
        public static TransitionManager Instance { get; private set; }

        [SerializeField] private TransitionAnimations _transitionAnimations = null;

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

        public void TransitionToNextLevel(string nextLevel)
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
