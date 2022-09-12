using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void NextLevel(int previousLevel, int nextLevel)
        {
            LoadLevel(nextLevel);
            UnloadLevel(previousLevel);
        }

        private void LoadLevel(int nextLevel)
        {
            SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
        }

        private void UnloadLevel(int previousLevel)
        {
            if (previousLevel != 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(previousLevel))
            {
                SceneManager.UnloadSceneAsync(previousLevel);
            }
        }
    }
}
