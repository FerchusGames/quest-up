using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestUp
{
    public class LoadTransitionOnStart : MonoBehaviour
    {
        public static LoadTransitionOnStart Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            { 
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
        }
    }
}
