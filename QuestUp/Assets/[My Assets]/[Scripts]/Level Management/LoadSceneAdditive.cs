using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class LoadSceneAdditive : MonoBehaviour
    {
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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(previousLevel))
            {
                SceneManager.UnloadSceneAsync(previousLevel);
            }
        }

        #region Prototyping
        public void Level1()
        {
            NextLevel(2, 1);
        }

        public void Level2()
        {
            NextLevel(1, 2);
        }
        #endregion
    }
}
